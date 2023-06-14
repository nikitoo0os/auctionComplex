package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.Wallet;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface WalletRepository extends JpaRepository<Wallet, Long> {
    @Query("SELECT w FROM Wallet w WHERE w.user.id = ?1")
    List<Wallet> getWalletsByUserId(int userId);
}
