package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import com.vyatsu.auctionComplex.repository.api.AuctionItemRepository;
import com.vyatsu.auctionComplex.service.api.AuctionItemService;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.util.List;
import java.util.stream.Collectors;

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
        AuctionItem auctionItem = auctionItemRepository.findById(id).get();
        boolean isValid = !auctionItem.getEndDate().isBefore(Instant.now());
        if(!isValid){
            auctionItem.setIsValid("completed");
            auctionItemRepository.save(auctionItem);
        }
        return auctionItem;
    }

    @Override
    public List<AuctionItem> getAuctionItemsByAuctioneer(Long id) {
        return auctionItemRepository.findAll()
                .stream()
                .filter(auctionItem -> auctionItem.getAuctioneer().getId().equals(Math.toIntExact(id)))
                .collect(Collectors.toList());
    }


    @Override
    public AuctionItem getAuctionItemByAuctionChatId(Long chatId) {
        return auctionItemRepository.getAuctionItemByAuctionChat(chatId);
    }

    @Override
    public List<String> getAllCategories() {
        return auctionItemRepository.findAllCategories();
    }

    @Override
    public List<AuctionItem> getFilterAuctionItems(Double investmentVolume, String time, String category) {
        //return auctionItemRepository.getFilterAuctionItems(investmentVolume, time, category);
        return null;
    }
}
