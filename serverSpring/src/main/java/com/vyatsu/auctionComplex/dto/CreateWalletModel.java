package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class CreateWalletModel {

    @Getter
    @Setter
    private String token;

    @Getter
    @Setter
    private String address;

    @Getter
    @Setter
    private int confirmCode;

}
