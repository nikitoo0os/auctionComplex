package com.vyatsu.auctionComplex.service.auth.impl;

import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.entity.auth.JwtSession;
import com.vyatsu.auctionComplex.repository.auth.TokenRepository;
import com.vyatsu.auctionComplex.service.auth.TokenService;
import io.jsonwebtoken.JwtBuilder;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.stereotype.Service;

import java.util.Date;

@Service
public class TokenServiceImpl implements TokenService {

    private final TokenRepository tokenRepository;

    public TokenServiceImpl(TokenRepository tokenRepository) {
        this.tokenRepository = tokenRepository;
    }

    @Override
    public String createSession(User user) {
        String secretKey = "404E635266556A586E3272357538782F413F4428472B4B6250645367566B5970";

        long expirationMillis = 7 * 24 * 60 * 60 * 1000;
        Date expiration = new Date(System.currentTimeMillis() + expirationMillis);

        JwtBuilder builder = Jwts.builder()
                .setSubject(user.getUsername())
                .setIssuedAt(new Date())
                .setExpiration(expiration)
                .signWith(SignatureAlgorithm.HS256, secretKey);

        String token = builder.compact();

        JwtSession session = new JwtSession();
        session.setToken(token);
        session.setUser(user);
        tokenRepository.save(session);

        return token;
    }

    @Override
    public User findUserByToken(String token) {
        return tokenRepository.findUserByToken(token);
    }

}
