using Amazon.S3.Model;
using Amazon.S3;
using System;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using auctionComplex.Classes;
using Amazon.Util;
using Amazon.Runtime;
using Amazon;
using auctionComplex.Resources;
using System.Linq;
using System.IO;
using Amazon.S3.Transfer;
using auctionComplex.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace auctionComplex.Services
{
    internal class AttachmentService
    {
        private static List<string> Values = new List<string>();
        private static string AWSAccessKey, AWSAccessSecretKey, AWSEndpointUrl, AWSRegion, AWSBucketName;

        private static BasicAWSCredentials credentials;
        private static AmazonS3Config s3Config;

        public static List<Attachment> GetAllAttachments()
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Attachments.ToList();
            }
        }

        public static Attachment GetAttachmentById(int attachmentId)
        {
            using (var db = new AuctionComplexContext())
            {
                return db.Attachments.FirstOrDefault(x => x.Id == attachmentId);
            }
        }

        public static Attachment GetObjectByKey(string objectKey)
        {
            Attachment attachment = new Attachment();

            GetConnectionAws();

            using (var s3 = new AmazonS3Client(credentials, s3Config))
            {
                MessageBox.Show(s3.ToString());

                var req = new ListObjectsRequest
                {
                    BucketName = AWSBucketName,
                    MaxKeys = 100
                };

                Task<ListObjectsResponse> res = s3.ListObjectsAsync(req);
                Task.WaitAll(res);

                foreach (var s3Object in res.Result.S3Objects)
                {
                    if (s3Object.Key == objectKey)
                    {
                        attachment.Key = s3Object.Key;
                        attachment.FileSize = s3Object.Size;
                        attachment.FileType = s3Object.StorageClass;
                        attachment.Timestamp = s3Object.LastModified;

                        return attachment;
                    }
                }
            }

            return attachment;
        }

        private static void GetConnectionAws()
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                Values.Add(value);
            }

            AWSAccessKey = Values[0];
            AWSAccessSecretKey = Values[1];
            AWSEndpointUrl = Values[2];
            AWSRegion = Values[3];
            AWSBucketName = Values[4];

            credentials = new BasicAWSCredentials(AWSAccessKey, AWSAccessSecretKey);

            s3Config = new AmazonS3Config
            {
                ServiceURL = AWSEndpointUrl
            };
        }

        public static void DownloadFile(string objectKey)
        {
            GetConnectionAws();
            try
            {
                using (var s3Client = new AmazonS3Client(AWSAccessKey, AWSAccessSecretKey))
                {
                    var getObjectRequest = new GetObjectRequest
                    {
                        BucketName = AWSBucketName,
                        Key = objectKey
                    };

                    using (var getObjectResponse = s3Client.GetObject(getObjectRequest))
                    {
                        using (var saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.FileName = Path.GetFileName(objectKey);
                            saveFileDialog.Filter = "All Files (*.*)|*.*";

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                using (var fileStream = File.Create(saveFileDialog.FileName))
                                {
                                    getObjectResponse.ResponseStream.CopyTo(fileStream);
                                }

                                Console.WriteLine("Object downloaded successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Download canceled by the user.");
                            }
                        }
                    }
                }
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error downloading object: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void DeleteAttachmentByKey(string objectKey)
        {
            using (var db = new AuctionComplexContext())
            {
                var attachment = db.Attachments.FirstOrDefault(x => x.Key == objectKey);

                DeleteObjectFromAwsByKey(objectKey);

                db.Attachments.Remove(attachment);
                db.SaveChanges();
            }
        }

        private static void DeleteObjectFromAwsByKey(string objectKey)
        {
            GetConnectionAws();

            using (var s3 = new AmazonS3Client(credentials, s3Config))
            {
                var deleteRequest = new DeleteObjectRequest
                {
                    BucketName = AWSBucketName,
                    Key = objectKey
                };

                var response = s3.DeleteObject(deleteRequest); 

                if (response.HttpStatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    MessageBox.Show("Объект успешно удалён");
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении объекта из облачного хранилища");
                }
            }
        }

        public static string UploadFileToAws(OpenFileDialog openFileDialog)
        {
            GetConnectionAws();
            using (var s3 = new AmazonS3Client(credentials, s3Config))
            {
                TransferUtility utility = new TransferUtility(s3);

                using (var db = new AuctionComplexContext())
                {
                    TransferUtilityUploadRequest request = new TransferUtilityUploadRequest
                    {
                        BucketName = AWSBucketName,

                        Key = GenerateS3Key(),
                        FilePath = openFileDialog.FileName
                    };
                    FileInfo fileInfo = new FileInfo(request.FilePath);

                    string fileNameWithoutExtension = openFileDialog.SafeFileName.Replace(fileInfo.Extension, "");
                    string fileExtensionWithoutDot = fileInfo.Extension.Replace(".", "");

                    Attachment attachment = new Attachment
                    {
                        Key = request.Key,
                        Name = fileNameWithoutExtension,
                        FileSize = fileInfo.Length / 1024,
                        FileType = fileExtensionWithoutDot,
                        Timestamp = DateTime.Now
                    };

                    db.Attachments.Add(attachment);
                    db.SaveChanges();

                    utility.Upload(request);
                    MessageBox.Show("Файл загружен успешно!");

                    return request.Key;
                }
            }
        }

        private static string GenerateS3Key()
        {
            string guid = Guid.NewGuid().ToString();

            string additionalInfo = "attachment";

            string s3Key = $"{additionalInfo}:{guid}";

            return s3Key;
        }

        internal static List<Attachment> GetFilterAttachmentsList(string filter)
        {
            DateTime currentTime = DateTime.Now;

            if (FilterUtils.IsDigits(filter))
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.Attachments
                        .Where(x => x.Id == Convert.ToInt32(filter))
                        .ToList();
                }
            }
            else if (FilterUtils.IsSymbols(filter))
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.Attachments
                        .Where(x => x.Name.Contains(filter))
                        .ToList();
                }
            }
            else
            {
                using (var db = new AuctionComplexContext())
                {
                    return db.Attachments.ToList();
                }
            }
        }
    }
}
