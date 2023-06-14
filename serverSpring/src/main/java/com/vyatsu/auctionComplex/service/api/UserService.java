package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.dto.UserModel;
import com.vyatsu.auctionComplex.entity.api.User;

public interface UserService {
    UserModel getUserDtoById(Long userId);
    User createUser(User user);

    User getUserByLoginAndPassword(String login, String password);

    User getUserById(int id);
}
