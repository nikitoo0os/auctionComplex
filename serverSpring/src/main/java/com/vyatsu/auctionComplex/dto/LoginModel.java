package com.vyatsu.auctionComplex.dto;

import lombok.Getter;
import lombok.Setter;

public class LoginModel {

    @Getter
    @Setter
    private String token;

    @Getter
    @Setter
    private String usernameOrEmail;

    @Getter
    @Setter
    private String password;
}
