package com.vyatsu.auctionuni.my_task_prim_2.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "attachments")
public class Attachment {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Getter
    @Setter
    @Column(name = "id", nullable = false)
    private Integer id;

    @Getter
    @Setter
    @Column(name = "key", length = 250)
    private String key;

    @Getter
    @Setter
    @Column(name = "file_size", nullable = false)
    private Double fileSize;

    @Getter
    @Setter
    @Column(name = "file_type", length = 250)
    private String fileType;

    @Getter
    @Setter
    @Column(name = "\"timestamp\"", nullable = false)
    private LocalDate timestamp;

    @Getter
    @Setter
    @Column(name = "name", length = 250)
    private String name;

    @Getter
    @Setter
    @OneToMany(mappedBy = "attachment")
    private Set<ChatMessage> chatMessages = new LinkedHashSet<>();

}