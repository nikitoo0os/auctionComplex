package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.Transaction;
import org.springframework.data.jpa.repository.JpaRepository;

public interface TransactionRepository extends JpaRepository<Transaction, Long> {
}
