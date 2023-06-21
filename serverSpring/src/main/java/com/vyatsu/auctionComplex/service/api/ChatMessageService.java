package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.dto.ChatMessageModel;
import com.vyatsu.auctionComplex.entity.api.ChatMessage;
import com.vyatsu.auctionComplex.entity.api.User;

import java.util.List;

public interface ChatMessageService {
    List<ChatMessage> getChatMessagesByAuctionChatId(Long id);

    List<Object[]> getMessagesByAuctionChatId(Long id);
}
