package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import com.vyatsu.auctionComplex.repository.api.AuctionItemRepository;
import com.vyatsu.auctionComplex.service.api.AuctionItemService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AuctionItemServiceImpl implements AuctionItemService {
    private final AuctionItemRepository auctionItemRepository;

    public AuctionItemServiceImpl(AuctionItemRepository auctionItemRepository){
        this.auctionItemRepository = auctionItemRepository;
    }

    @Override
    public List<AuctionItem> getAllAuctionItems() {
        return auctionItemRepository.findAll();
    }

    @Override
    public AuctionItem getAuctionItemById(Long id) {
        return auctionItemRepository.findById(id).get();
    }

    @Override
    public List<AuctionItem> getAuctionItemsByAuctioneer(int id) {
        return auctionItemRepository.getAuctionItemsByAuctioneerId((long) id);
    }
}
