package com.vyatsu.auctionComplex.dto;

import com.vyatsu.auctionComplex.entity.api.User;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

public class AuctionItemModel {

    @Getter
    @Setter
    private Integer id;

    @Getter
    @Setter
    private String title;

    @Getter
    @Setter
    private String description;

    @Getter
    @Setter
    private Double investmentSize;

    @Getter
    @Setter
    private String location;

    @Getter
    @Setter
    private String category;

    @Getter
    @Setter
    private Instant startDate;

    @Getter
    @Setter
    private Instant endDate;

    @Getter
    @Setter
    private User winner;

    @Getter
    @Setter
    private User auctioneer;

    @Getter
    @Setter
    private String isValid;
}
