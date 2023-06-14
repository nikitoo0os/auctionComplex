package com.vyatsu.auctionuni.my_task_prim_2.transfermanager;

import software.amazon.awssdk.auth.credentials.DefaultCredentialsProvider;
import software.amazon.awssdk.auth.credentials.ProfileCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3AsyncClient;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.transfer.s3.S3TransferManager;

import java.net.URI;
import java.net.URISyntaxException;

import static software.amazon.awssdk.transfer.s3.SizeConstant.MB;

public class S3ClientFactory {
    public static final S3TransferManager transferManager;

    static {
        try {
            transferManager = createCustomTm();
        } catch (URISyntaxException e) {
            throw new RuntimeException(e);
        }
    }

    public static final S3TransferManager transferManagerWithDefaults = createDefaultTm();
    public static final S3Client s3Client;
    public static final Region RU_MSK = Region.of("ru-msk");

    public S3ClientFactory() throws URISyntaxException {
    }

    private static S3TransferManager createCustomTm() throws URISyntaxException {
        ProfileCredentialsProvider credentialsProvider = ProfileCredentialsProvider.create();
        S3AsyncClient s3AsyncClient =
                S3AsyncClient.crtBuilder()
                        .credentialsProvider(credentialsProvider)
                        .endpointOverride(new URI("https://" + "hb.bizmrg.com"))
                        .region(RU_MSK)
                        .targetThroughputInGbps(20.0)
                        .minimumPartSizeInBytes(8 * MB)
                        .build();

        System.out.println(s3AsyncClient);

        S3TransferManager transferManager =
                S3TransferManager.builder()
                        .s3Client(s3AsyncClient)
                        .build();

        return transferManager;
    }

    private static S3TransferManager createDefaultTm(){
        S3TransferManager transferManager = S3TransferManager.create();
        return transferManager;
    }

    static {
        try {
            s3Client = S3Client.builder()
                    .endpointOverride(new URI("http://" + "hb.bizmrg.com"))
                    .credentialsProvider(DefaultCredentialsProvider.create())
                    .build();
        } catch (URISyntaxException e) {
            throw new RuntimeException(e);
        }
    }
}
