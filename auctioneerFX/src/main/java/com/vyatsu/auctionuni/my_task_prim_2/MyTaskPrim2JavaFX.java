package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.AuctionItem;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import software.amazon.awssdk.auth.credentials.ProfileCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.*;

import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.List;


public class MyTaskPrim2JavaFX extends Application{

    public AuctionItem auctionItem;

    public static final Region RU_MSK = Region.of("ru-msk");
    private static final String bucketName = "auction-complex-bucket";
    public static final String keyName = "java";

    public static final String connectionString = "jdbc:postgresql://localhost/auction_complex_m?user=postgres&password=1&ssl=false";
    @Override
    public void start(Stage stage) throws Exception {

        URI myURI = new URI("http://" + "hb.bizmrg.com");
        ProfileCredentialsProvider credentialsProvider = ProfileCredentialsProvider.create();
        Region region = Region.US_EAST_1;

        S3Client s3 = S3Client.builder()
                .endpointOverride(myURI)
                .credentialsProvider(credentialsProvider)
                .region(RU_MSK)
                .build();

        //listBucketObjects(s3, bucketName);
        //getURL(s3,bucketName,"auction_unique_idea_and_innovations (2).png");

        s3.close();

        Scene scene = new Scene(new Group());
        stage.setTitle("Интернет-аукцион уникальный идей и инноваций");
        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuctionItemsView.fxml"));
            pane = loader.load();
            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();

    }

    public void setAuctionItem(AuctionItem auctionItem){
        this.auctionItem = auctionItem;
    }

    public static void main(String[] args) throws URISyntaxException {
        launch(args);
    }

    public static void getURL(S3Client s3, String bucketName, String keyName ) {

        try {
            GetUrlRequest request = GetUrlRequest.builder()
                    .bucket(bucketName)
                    .key(keyName)
                    .build();

            URL url = s3.utilities().getUrl(request);
            System.out.println("The URL for  "+keyName +" is "+ url);

        } catch (S3Exception e) {
            //System.err.println(e.awsErrorDetails().errorMessage());
            System.exit(1);
        }
    }
    public static void listBucketObjects(S3Client s3, String bucketName ) {

        try {
            ListObjectsRequest listObjects = ListObjectsRequest
                    .builder()
                    .bucket(bucketName)
                    .build();

            ListObjectsResponse res = s3.listObjects(listObjects);
            List<S3Object> objects = res.contents();
            for (S3Object myValue : objects) {
                System.out.print("\n The name of the key is " + myValue.key());
                System.out.print("\n The object is " + calKb(myValue.size()) + " KBs");
                System.out.print("\n The owner is " + myValue.owner());
            }

        } catch (S3Exception e) {
            System.exit(1);
        }
    }
    private static long calKb(Long val) {
        return val/1024;
    }


}
