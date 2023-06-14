package com.vyatsu.auctionComplex.entity.auth;

import com.vyatsu.auctionComplex.entity.api.User;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.OffsetDateTime;

@Entity
@Table(name = "jwt_sessions")
public class JwtSession {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @Getter
    @Setter
    @JoinColumn(name = "user_id", nullable = false)
    private User user;

    @Size(max = 255)
    @NotNull
    @Getter
    @Setter
    @Column(name = "token", nullable = false)
    private String token;

    @Getter
    @Setter
    @Column(name = "created_at")
    private OffsetDateTime createdAt;


}