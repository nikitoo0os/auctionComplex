package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class UserModel {

    @Getter
    @Setter
    private Integer id;

    @Getter
    @Setter
    private String firstName;

    @Getter
    @Setter
    private String secondName;

    @Getter
    @Setter
    private String email;

    @Getter
    @Setter
    private String username;

    @Getter
    @Setter
    private String password;

    @Getter
    @Setter
    private String token;

    @Getter
    @Setter
    private boolean isVerify;


}
