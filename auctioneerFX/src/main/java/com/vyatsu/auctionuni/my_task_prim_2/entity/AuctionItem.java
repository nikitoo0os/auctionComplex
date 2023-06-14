package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;

@Entity
@Table(name = "auction_items")
public class AuctionItem {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "title", length = 250)
    private String title;

    @Getter
    @Setter
    @Column(name = "description", length = 1000)
    private String description;

    @Getter
    @Setter
    @Column(name = "investment_size", nullable = false)
    private Double investmentSize;

    @Lob
    @Getter
    @Setter
    @Column(name = "location")
    private String location;

    @Lob
    @Getter
    @Setter
    @Column(name = "category")
    private String category;

    @Getter
    @Setter
    @Column(name = "start_date", nullable = false)
    private LocalDate startDate;

    @Getter
    @Setter
    @Column(name = "end_date")
    private LocalDate endDate;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "winner_id")
    private User winner;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @Getter
    @Setter
    @JoinColumn(name = "auctioneer_id", nullable = false)
    private User auctioneer;

    @Lob
    @Getter
    @Setter
    @Column(name = "is_valid")
    private String isValid;

    public AuctionItem(String title, String description, Double investmentSize, LocalDate startDate, LocalDate endDate, User auctioneer, String location) {
        this.title = title;
        this.description = description;
        this.investmentSize = investmentSize;
        this.startDate = startDate;
        this.endDate = endDate;
        this.auctioneer = auctioneer;
        this.location = location;
    }
    public AuctionItem(){}

    public AuctionItem(Integer id, String title, String description, Double investmentSize, LocalDate startDate, LocalDate endDate, User auctioneer, String location, String category) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.investmentSize = investmentSize;
        this.startDate = startDate;
        this.endDate = endDate;
        this.auctioneer = auctioneer;
        this.category = category;
        this.location = location;
    }
}