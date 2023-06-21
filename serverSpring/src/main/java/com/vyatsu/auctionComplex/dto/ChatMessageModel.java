package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class ChatMessageModel {

    @Getter
    @Setter
    private int id;

    @Getter
    @Setter
    private String firstName;

    @Getter
    @Setter
    private String secondName;

    @Getter
    @Setter
    private String text;

    @Getter
    @Setter
    private int auctionChatId;

    @Getter
    @Setter
    private String timestamp;
}
