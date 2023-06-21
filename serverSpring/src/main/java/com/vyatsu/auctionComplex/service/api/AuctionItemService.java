package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import org.springframework.data.repository.query.Param;

import java.time.Instant;
import java.util.List;

public interface AuctionItemService {
    List<AuctionItem> getAllAuctionItems();

    AuctionItem getAuctionItemById(Long id);

    List<AuctionItem> getAuctionItemsByAuctioneer(Long id);

    AuctionItem getAuctionItemByAuctionChatId(Long chatId);

    List<String> getAllCategories();
    List<AuctionItem> getFilterAuctionItems(Double investmentVolume, String time, String category);
}
