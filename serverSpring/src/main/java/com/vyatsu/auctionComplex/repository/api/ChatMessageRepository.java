package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.ChatMessage;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface ChatMessageRepository extends JpaRepository<ChatMessage, Long> {
    @Query("SELECT c FROM ChatMessage c WHERE c.auctionChat.id = ?1")
    List<ChatMessage> getChatMessagesByAuctionChatId(Long id);
}
