package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.*;
import org.hibernate.annotations.Fetch;
import org.hibernate.annotations.FetchMode;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import java.util.Collection;
import java.util.LinkedHashSet;
import java.util.Set;

@Builder
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "users")
public class User implements UserDetails {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "first_name", length = 100)
    @Getter
    @Setter
    private String firstName;

    @Column(name = "second_name", length = 100)
    @Getter
    @Setter
    private String secondName;

    @Column(name = "email", length = 100)
    @Getter
    @Setter
    private String email;

    @Column(name = "username", length = 100)
    @Getter
    @Setter
    private String username;

    @Column(name = "password", length = 100)
    @Getter
    @Setter
    private String password;

    @Getter
    @Setter
    @Transient
    private String token;

    @Column(name = "is_admin", nullable = false)
    @Builder.Default
    @Getter
    @Setter
    private Boolean isAdmin = false;
    @Column(name = "is_verify", nullable = false)
    @Builder.Default
    @Getter
    @Setter
    private Boolean isVerify = false;

    @OneToMany(mappedBy = "user")
    @Builder.Default
    @Fetch(FetchMode.JOIN)
    @Getter
    @Setter
    private Set<Wallet> wallets = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Builder.Default
    @JsonIgnore
    @Getter
    @Setter
    private Set<UserChat> userChats = new LinkedHashSet<>();

    @OneToMany(mappedBy = "auctioneer")
    @Builder.Default
    @Fetch(FetchMode.JOIN)
    @JsonIgnore
    @Getter
    @Setter
    private Set<AuctionItem> userItems = new LinkedHashSet<>();

    @OneToMany(mappedBy = "winner")
    @Builder.Default
    @Fetch(FetchMode.JOIN)
    @JsonIgnore
    @Getter
    @Setter
    private Set<AuctionItem> winnerItems = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Builder.Default
    @Fetch(FetchMode.JOIN)
    @JsonIgnore
    @Getter
    @Setter
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();

    @OneToMany(mappedBy = "user")
    @Builder.Default
    @Fetch(FetchMode.JOIN)
    @JsonIgnore
    @Getter
    @Setter
    private Set<Bid> bids = new LinkedHashSet<>();

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return null;
    }

    @Override
    public boolean isAccountNonExpired() {
        return false;
    }

    @Override
    public boolean isAccountNonLocked() {
        return false;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return false;
    }

    @Override
    public boolean isEnabled() {
        return false;
    }
}