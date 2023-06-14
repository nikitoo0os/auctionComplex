package com.vyatsu.auctionuni.my_task_prim_2.transfermanager;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import software.amazon.awssdk.core.ResponseBytes;
import software.amazon.awssdk.core.sync.RequestBody;
import software.amazon.awssdk.core.sync.ResponseTransformer;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.*;
import software.amazon.awssdk.transfer.s3.S3TransferManager;
import software.amazon.awssdk.transfer.s3.model.CompletedFileUpload;
import software.amazon.awssdk.transfer.s3.model.FileUpload;
import software.amazon.awssdk.transfer.s3.model.UploadFileRequest;
import software.amazon.awssdk.transfer.s3.progress.LoggingTransferListener;

import java.io.*;
import java.net.URISyntaxException;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public class UploadFile {
    private static final Logger logger = LoggerFactory.getLogger(UploadFile.class);
    public final String bucketName = "auction-complex-bucket";
    public final String key = UUID.randomUUID().toString();
    public String filePath;

    public UploadFile() {
        this.setUp();
    }

    public String uploadFile(S3TransferManager transferManager, String bucketName,
                             String key, String filePath) {

        PutObjectRequest putRequest = PutObjectRequest.builder()
                .bucket(bucketName)
                .key(this.key)
                .acl(ObjectCannedACL.PUBLIC_READ_WRITE)
                .contentType("UNSIGNED_PAYLOAD")
                .build();



        UploadFileRequest uploadFileRequest =
                UploadFileRequest.builder()
                        .putObjectRequest(putRequest)
                        .addTransferListener(LoggingTransferListener.create())
                        .source(Paths.get(filePath))
                        .build();

        System.out.println(uploadFileRequest);

        FileUpload fileUpload = transferManager.uploadFile(uploadFileRequest);
        System.out.println(fileUpload);

        CompletedFileUpload uploadResult = fileUpload.completionFuture().join();
        System.out.println(uploadResult);
        return uploadResult.response().eTag();
    }

    public String putS3Object() throws URISyntaxException {
        S3ClientFactory s3Client = new S3ClientFactory();
        S3Client s3 = s3Client.s3Client;
        System.out.println("S3: " + s3);

        try {
            Map<String, String> metadata = new HashMap<>();
            metadata.put("x-amz-meta-myVal", "test");
            PutObjectRequest putOb = PutObjectRequest.builder()
                    .bucket(this.bucketName)
                    .key(this.key)
                    .metadata(metadata)
                    .build();

            System.out.println("Найденный файЛ: " + new File(this.filePath));
            s3.putObject(putOb, RequestBody.fromFile(new File(this.filePath)));
            System.out.println("Successfully placed " + this.key +" into bucket "+ this.bucketName);

            return this.key;

        } catch (S3Exception e) {
            System.err.println(e.getMessage());
            System.exit(1);
            return null;
        }
    }

    public File getObjectFromAWS (String keyName) throws URISyntaxException {
        File myFile;
        S3ClientFactory s3Client = new S3ClientFactory();
        S3Client s3 = s3Client.s3Client;
        System.out.println("S3: " + s3);

        try {
            GetObjectRequest objectRequest = GetObjectRequest
                    .builder()
                    .key(keyName)
                    .bucket(this.bucketName)
                    .build();

            ResponseBytes<GetObjectResponse> objectBytes = s3.getObject(objectRequest, ResponseTransformer.toBytes());
            byte[] data = objectBytes.asByteArray();

            String path = "/data" + keyName;

            myFile = new File(path);
            System.out.println("Путь загрузки файла в " + myFile.getAbsolutePath());
            OutputStream os = new FileOutputStream(myFile);
            os.write(data);
            System.out.println("Successfully obtained bytes from an S3 object");
            os.close();

            return myFile;

        } catch (IOException ex) {
            ex.printStackTrace();
            return null;
        } catch (S3Exception e) {
            //System.err.println(e.awsErrorDetails().errorMessage());
            System.exit(1);
            return null;
        }
    }



    private void setUp(){
        S3ClientFactory.s3Client.createBucket(b -> b.bucket(bucketName));
        // get the file system path to the provided file to upload
        System.out.println("Второй путь в сет ап:" + filePath);

//        URL resource = UploadFile.class.getClassLoader().getResource(filePath);
//        System.out.println(resource);
//        filePath = resource.getPath();
    }

    public void cleanUp(){
        S3ClientFactory.s3Client.deleteObject(b -> b.bucket(bucketName).key(key));
        S3ClientFactory.s3Client.deleteBucket(b -> b.bucket(bucketName));
    }
}
