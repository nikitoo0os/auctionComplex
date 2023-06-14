package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.ChatMessage;

import java.util.List;

public interface ChatMessageService {
    List<ChatMessage> getChatMessagesByAuctionChatId(Long id);
}
