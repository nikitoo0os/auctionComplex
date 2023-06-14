package com.vyatsu.auctionComplex.entity.api;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.math.BigDecimal;

@Entity
@Table(name = "transactions")
public class Transaction {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "amount", nullable = false)
    @Getter
    @Setter
    private BigDecimal amount;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "\"SenderWalletId\"")
    @Getter
    @Setter
    private Wallet senderWallet;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "\"ReceiverWalletId\"")
    @Getter
    @Setter
    private Wallet receiverWallet;

}