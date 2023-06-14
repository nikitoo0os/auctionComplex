package com.vyatsu.auctionComplex.service.auth;

import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.entity.auth.JwtSession;

public interface TokenService {
    public String createSession(User user);
    public User findUserByToken(String token);
}
