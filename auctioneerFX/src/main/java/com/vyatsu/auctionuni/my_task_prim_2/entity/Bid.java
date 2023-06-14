package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;

@Entity
@Table(name = "bids")
public class Bid {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "investment_volume", nullable = false)
    private Double investmentVolume;

    @Getter
    @Setter
    @Column(name = "entry_percentage", nullable = false)
    private Double entryPercentage;

    @Getter
    @Setter
    @Column(name = "\"timestamp\"", nullable = false)
    private LocalDate timestamp;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"UserId\"")
    private User user;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"AuctionItemId\"")
    private AuctionItem auctionItem;

}