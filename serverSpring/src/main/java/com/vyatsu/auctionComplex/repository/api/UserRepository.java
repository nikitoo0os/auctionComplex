package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.Optional;

public interface UserRepository extends JpaRepository<User, Long> {
    @Query("SELECT u FROM User u WHERE (u.email = ?1 OR u.username = ?1) AND u.password = ?2")
    User getUserByLoginAndPassword(String login, String password);

    @Query("SELECT u FROM User u WHERE u.username = ?1")
    Optional<User> getUserByUsername(String username);
}
