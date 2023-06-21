package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.time.Instant;
import java.util.List;

public interface AuctionItemRepository extends JpaRepository<AuctionItem, Long> {
    @Query("SELECT a FROM AuctionItem a WHERE a.auctioneer.id = ?1")
    List<AuctionItem> getAuctionItemsByAuctioneerId(Long id);

    @Query("SELECT ai FROM AuctionItem ai JOIN AuctionChat ac ON ai.id = ac.auctionItem.id WHERE ac.auctionItem.id = ?1")
    AuctionItem getAuctionItemByAuctionChat(Long chatId);

    @Query("SELECT DISTINCT ai.category FROM AuctionItem ai")
    List<String> findAllCategories();

//    @Query("SELECT ai FROM AuctionItem ai WHERE (:investmentVolume IS NULL OR ai.investmentSize >= :investmentVolume) " +
//            "AND (:time IS NULL OR ai.startDate <= (CURRENT_TIME + INTERVAL :time)) " +
//            "AND (:category IS NULL OR ai.category LIKE CONCAT(:category, '%'))")
//    public List<AuctionItem> getFilterAuctionItems(@Param("investmentVolume") Double investmentVolume,
//                                                   @Param("time") String time,
//                                                   @Param("category") String category);

}
