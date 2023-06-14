package com.vyatsu.auctionComplex.repository.auth;

import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.entity.auth.JwtSession;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface TokenRepository extends JpaRepository<JwtSession, Long> {
    @Query("SELECT u FROM JwtSession js JOIN User u ON u.id = js.user.id WHERE js.token = ?1")
    public User findUserByToken(String token);
}
