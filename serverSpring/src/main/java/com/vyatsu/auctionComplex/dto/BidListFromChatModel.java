package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

public class BidListFromChatModel {

    @Getter
    @Setter
    private Integer id;

    @Getter
    @Setter
    private Double investmentVolume;

    @Getter
    @Setter
    private Double entryPercentage;

    @Getter
    @Setter
    private Instant timestamp;

    @Getter
    @Setter
    private String firstNameUser;
}
