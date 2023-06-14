package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface AuctionItemRepository extends JpaRepository<AuctionItem, Long> {
    @Query("SELECT a FROM AuctionItem a WHERE a.auctioneer.id = ?1")
    List<AuctionItem> getAuctionItemsByAuctioneerId(Long id);
}
