package com.vyatsu.auctionComplex.entity.api;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Entity
@Table(name = "bids")
public class Bid {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "investment_volume", nullable = false)
    @Getter
    @Setter
    private Double investmentVolume;

    @Column(name = "entry_percentage", nullable = false)
    @Getter
    @Setter
    private Integer entryPercentage;

    @Column(name = "\"timestamp\"", nullable = false)
    @Getter
    @Setter
    private Instant timestamp;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "\"UserId\"")
    @Getter
    @Setter
    private User user;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "\"AuctionItemId\"")
    @Getter
    @Setter
    private AuctionItem auctionItem;

}