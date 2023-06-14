package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;

import java.util.List;

public interface AuctionItemService {
    List<AuctionItem> getAllAuctionItems();

    AuctionItem getAuctionItemById(Long id);

    List<AuctionItem> getAuctionItemsByAuctioneer(int id);
}
