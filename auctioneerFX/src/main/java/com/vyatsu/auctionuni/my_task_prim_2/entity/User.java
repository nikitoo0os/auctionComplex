package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "users")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "first_name", length = 100)
    private String firstName;

    @Getter
    @Setter
    @Column(name = "second_name", length = 100)
    private String secondName;

    @Getter
    @Setter
    @Column(name = "email", length = 100)
    private String email;

    @Getter
    @Setter
    @Column(name = "username", length = 100)
    private String username;

    @Getter
    @Setter
    @Column(name = "password", length = 100)
    private String password;

    @Getter
    @Setter
    @Column(name = "is_admin", nullable = false)
    private Boolean isAdmin = false;

    @Getter
    @Setter
    @Column(name = "is_verify", nullable = false)
    private Boolean isVerify;

    @OneToMany(mappedBy = "user")
    @Getter
    @Setter
    private Set<Wallet> wallets = new LinkedHashSet<>();

    @OneToMany(mappedBy = "auctioneer")
    @Getter
    @Setter
    private Set<AuctionItem> userAuctionItems = new LinkedHashSet<>();

    @OneToMany(mappedBy = "winner")
    @Getter
    @Setter
    private Set<AuctionItem> winAuctionItems = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Getter
    @Setter
    private Set<Bid> bids = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Getter
    @Setter
    private Set<UserChat> userChats = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Getter
    @Setter
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();



    public User(int id, String first_name, String second_name, String email, String password, String username, boolean is_verified) {
        this.id = id;
        this.firstName = first_name;
        this.secondName = second_name;
        this.email = email;
        this.password = password;
        this.username = username;
        this.isVerify = is_verified;
    }

    public User() {

    }
}