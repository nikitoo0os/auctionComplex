package com.vyatsu.auctionComplex.repository.api;

import com.vyatsu.auctionComplex.entity.api.UserChat;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserChatRepository extends JpaRepository<UserChat, Long> {
}
