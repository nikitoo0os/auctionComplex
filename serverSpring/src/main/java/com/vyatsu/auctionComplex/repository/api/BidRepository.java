package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.Bid;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface BidRepository extends JpaRepository<Bid, Long> {
    @Query("SELECT b FROM Bid b WHERE b.auctionItem.id = ?1")
    List<Bid> getAuctionChatByAuctionItemId(Long id);

    @Query("SELECT b FROM Bid b WHERE b.auctionItem.id= ?1 ORDER BY b.investmentVolume / b.entryPercentage DESC")
    Bid getBestBidByAuctionItemId(Long id);
}
