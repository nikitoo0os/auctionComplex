package com.vyatsu.auctionuni.my_task_prim_2.entity;

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
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "address", length = 48)
    private String address;

    @Getter
    @Setter
    @Column(name = "balance", nullable = false)
    private Double balance;

    @ManyToOne(fetch = FetchType.LAZY)
    @Getter
    @Setter
    @JoinColumn(name = "\"UserId\"")
    private User user;

    @OneToMany(mappedBy = "receiverWallet")
    @Getter
    @Setter
    private Set<Transaction> receiveTransactions = new LinkedHashSet<>();

    @OneToMany(mappedBy = "senderWallet")
    @Getter
    @Setter
    private Set<Transaction> sendTransactions = new LinkedHashSet<>();

}