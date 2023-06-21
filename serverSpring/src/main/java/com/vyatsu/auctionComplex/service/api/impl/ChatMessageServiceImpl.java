package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.dto.ChatMessageModel;
import com.vyatsu.auctionComplex.entity.api.ChatMessage;
import com.vyatsu.auctionComplex.repository.api.ChatMessageRepository;
import com.vyatsu.auctionComplex.service.api.ChatMessageService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ChatMessageServiceImpl implements ChatMessageService {
    private final ChatMessageRepository chatMessageRepository;

    public ChatMessageServiceImpl(ChatMessageRepository chatMessageRepository) {
        this.chatMessageRepository = chatMessageRepository;
    }

    @Override
    public List<ChatMessage> getChatMessagesByAuctionChatId(Long id) {
        return chatMessageRepository.getChatMessagesByAuctionChatId(id);
    }

    @Override
    public List<Object[]> getMessagesByAuctionChatId(Long id) {
        return chatMessageRepository.getChatMessageByAuctionChatId(id);
    }
}
