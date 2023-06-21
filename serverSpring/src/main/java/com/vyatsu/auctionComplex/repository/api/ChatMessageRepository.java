package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.dto.ChatMessageModel;
import com.vyatsu.auctionComplex.entity.api.ChatMessage;
import com.vyatsu.auctionComplex.entity.api.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface ChatMessageRepository extends JpaRepository<ChatMessage, Long> {
    @Query("SELECT c FROM ChatMessage c WHERE c.auctionChat.id = ?1")
    List<ChatMessage> getChatMessagesByAuctionChatId(Long id);

//    @Query("select User.id, User.firstName, User.secondName, ChatMessage.text, ChatMessage.auctionChat.id, ChatMessage.timestamp from User join ChatMessage on User.id = ChatMessage.user.id where ChatMessage.auctionChat.id = ?1")
    @Query("SELECT u, cm FROM User u JOIN ChatMessage cm ON u.id = cm.user.id WHERE cm.auctionChat.id = ?1")
    List<Object[]> getChatMessageByAuctionChatId(Long id);
}
