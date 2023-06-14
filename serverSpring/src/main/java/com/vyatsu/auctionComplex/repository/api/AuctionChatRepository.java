package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.AuctionChat;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface AuctionChatRepository extends JpaRepository<AuctionChat, Long> {
    @Query("SELECT a FROM AuctionChat a WHERE a.auctionItem.id = ?1")
    AuctionChat getAuctionChatByAuctionItemId(Long id);
}
