package com.vyatsu.auctionComplex.entity.api;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;
import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "attachments")
public class Attachment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    @Getter
    @Setter
    private Integer id;

    @Column(name = "key", length = 250)
    @Getter
    @Setter
    private String key;

    @Column(name = "file_size", nullable = false)
    @Getter
    @Setter
    private Double fileSize;

    @Column(name = "file_type", length = 250)
    @Getter
    @Setter
    private String fileType;

    @Column(name = "\"timestamp\"", nullable = false)
    @Getter
    @Setter
    private Instant timestamp;

    @Column(name = "name", length = 250)
    @Getter
    @Setter
    private String name;

    @OneToMany(mappedBy = "attachment")
    @JsonIgnore
    @Getter
    @Setter
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();

}