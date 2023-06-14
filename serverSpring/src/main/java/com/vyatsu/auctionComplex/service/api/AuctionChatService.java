package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.AuctionChat;

public interface AuctionChatService {
    AuctionChat getAuctionChatByAuctionId(Long id);
}
