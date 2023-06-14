package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Entity
@Table(name = "chat_messages")
public class ChatMessage {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "text", length = 250)
    @Getter
    @Setter
    private String text;

    @ManyToOne(fetch = FetchType.LAZY)
    @JsonIgnore
    @JoinColumn(name = "\"chat_id\"")
    @Getter
    @Setter
    private AuctionChat auctionChat;

    @ManyToOne(fetch = FetchType.LAZY)
    @JsonIgnore
    @JoinColumn(name = "\"UserId\"")
    @Getter
    @Setter
    private User user;

    @ManyToOne(fetch = FetchType.LAZY)
    @JsonIgnore
    @JoinColumn(name = "\"AttachmentId\"")
    @Getter
    @Setter
    private Attachment attachment;

    @Column(name = "\"timestamp\"", nullable = false)
    @Getter
    @Setter
    private Instant timestamp;

}