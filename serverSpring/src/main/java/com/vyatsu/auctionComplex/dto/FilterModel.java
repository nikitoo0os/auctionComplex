package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class FilterModel {

    @Getter
    @Setter
    private double investmentVolume;

    @Getter
    @Setter
    private String time;

    @Getter
    @Setter
    private String category;
}
