package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.AuctionChat;
import com.vyatsu.auctionComplex.repository.api.AuctionChatRepository;
import com.vyatsu.auctionComplex.service.api.AuctionChatService;
import org.springframework.stereotype.Service;

@Service
public class AuctionChatServiceImpl implements AuctionChatService {

    private final AuctionChatRepository auctionChatRepository;

    public AuctionChatServiceImpl(AuctionChatRepository auctionChatRepository) {
        this.auctionChatRepository = auctionChatRepository;
    }

    @Override
    public AuctionChat getAuctionChatByAuctionId(Long id) {
        return auctionChatRepository.getAuctionChatByAuctionItemId(id);
    }
}
