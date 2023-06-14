package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;

@Entity
@Table(name = "chat_messages")
public class ChatMessage {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "text", length = 250)
    private String text;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"AuctionChatId\"")
    private AuctionChat auctionChat;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"UserId\"")
    private User user;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"AttachmentId\"")
    private Attachment attachment;

    @Getter
    @Setter
    @Column(name = "\"timestamp\"", nullable = false)
    private LocalDate timestamp;

}