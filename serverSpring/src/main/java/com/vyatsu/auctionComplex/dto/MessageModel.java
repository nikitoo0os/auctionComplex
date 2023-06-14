package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class MessageModel {

    @Getter
    @Setter
    private int userId;
    @Getter
    @Setter
    private int chatId;

    @Getter
    @Setter
    private String text;
}
