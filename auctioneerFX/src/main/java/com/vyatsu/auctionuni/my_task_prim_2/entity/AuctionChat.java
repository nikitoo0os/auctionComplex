package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "auction_chats")
public class AuctionChat {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"AuctionItemId\"")
    private AuctionItem auctionItem;

    @OneToMany(mappedBy = "auctionChat")
    @Getter
    @Setter
    private Set<UserChat> userChats = new LinkedHashSet<>();

    @OneToMany(mappedBy = "auctionChat")
    @Getter
    @Setter
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();

}