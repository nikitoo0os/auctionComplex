package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.Attachment;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface AttachmentRepository extends JpaRepository<Attachment, Long> {
    @Query("SELECT a " +
            "FROM Attachment a " +
            "JOIN ChatMessage cm ON a.id = cm.attachment.id " +
            "JOIN AuctionChat ac ON cm.auctionChat.id = ac.id " +
            "WHERE ac.id = :auctionChatId")
    List<Attachment> getAttachmentsByAuctionChatId(@Param("auctionChatId") Long auctionChatId);
}

