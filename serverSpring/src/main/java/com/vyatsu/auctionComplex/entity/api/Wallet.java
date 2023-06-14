package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "wallets")
public class Wallet {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "address", length = 48)
    @Getter
    @Setter
    private String address;

    @Column(name = "balance", nullable = false)
    @Getter
    @Setter
    private Double balance;

    @ManyToOne(fetch = FetchType.LAZY)
    @JsonIgnore
    @JoinColumn(name = "\"UserId\"")
    @Getter
    @Setter
    private User user;

    @OneToMany(mappedBy = "receiverWallet")
    @JsonIgnore
    @Getter
    @Setter
    private Set<Transaction> receiveTransactions = new LinkedHashSet<>();

    @OneToMany(mappedBy = "senderWallet")
    @JsonIgnore
    @Getter
    @Setter
    private Set<Transaction> sendTransactions = new LinkedHashSet<>();

}