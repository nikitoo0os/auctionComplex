package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
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
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "\"auction_id\"")
    @JsonIgnore
    @Getter
    @Setter
    private AuctionItem auctionItem;

    @OneToMany(mappedBy = "auctionChat")
    @JsonIgnore
    @Getter
    @Setter
    private Set<UserChat> userChats = new LinkedHashSet<>();

    @OneToMany(mappedBy = "auctionChat")
    @JsonIgnore
    @Getter
    @Setter
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();

}