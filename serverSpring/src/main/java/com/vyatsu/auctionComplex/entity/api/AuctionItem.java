package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;
import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "auction_items")
public class AuctionItem {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "title", length = 250)
    @Getter
    @Setter
    private String title;

    @Column(name = "description", length = 1000)
    @Getter
    @Setter
    private String description;

    @Column(name = "investment_size", nullable = false)
    @Getter
    @Setter
    private Double investmentSize;

    @Column(name = "location")
    @Getter
    @Setter
    private String location;

    @Column(name = "category")
    @Getter
    @Setter
    private String category;

    @Column(name = "start_date", nullable = false)
    @Getter
    @Setter
    private Instant startDate;

    @Column(name = "end_date")
    @Getter
    @Setter
    private Instant endDate;

    @ManyToOne()
    @JsonIgnore
    @JoinColumn(name = "winner_id")
    @Getter
    @Setter
    private User winner;

    @ManyToOne()
    @JsonIgnore
    @JoinColumn(name = "auctioneer_id", nullable = false)
    @Getter
    @Setter
    private User auctioneer;

    @Column(name = "is_valid")
    @Getter
    @Setter
    private String isValid;

    @OneToMany(mappedBy = "auctionItem")
    @JsonIgnore
    @Getter
    @Setter
    private Set<AuctionChat> auctionChats = new LinkedHashSet<>();

    @OneToMany(mappedBy = "auctionItem")
    @JsonIgnore
    @Getter
    @Setter
    private Set<Bid> bids = new LinkedHashSet<>();

}