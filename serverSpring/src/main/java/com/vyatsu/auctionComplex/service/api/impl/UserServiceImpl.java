package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.dto.UserModel;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.repository.api.UserRepository;
import com.vyatsu.auctionComplex.service.api.UserService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;

    public UserServiceImpl(UserRepository userRepository){
        super();
        this.userRepository = userRepository;
    }
    @Override
    public UserModel getUserDtoById(Long userId) {
        User user = userRepository.findById(userId).orElse(null);
        if (user != null) {
            ModelMapper modelMapper = new ModelMapper();
            return modelMapper.map(user, UserModel.class);
        }
        return null;
    }

    @Override
    public User createUser(User user) {
        user.setPassword(hashPassword(user.getPassword()));
        return userRepository.save(user);
    }

    @Override
    public User getUserByLoginAndPassword(String login, String password) {
        return userRepository.getUserByLoginAndPassword(login, hashPassword(password));
    }

    @Override
    public User getUserById(int id) {
        return userRepository.findById(Long.valueOf(id)).get();
    }

    public static String hashPassword(String password) {
        try {
            MessageDigest digest = MessageDigest.getInstance("SHA-256");
            byte[] hashBytes = digest.digest(password.getBytes(StandardCharsets.UTF_8));
            StringBuilder hexString = new StringBuilder();

            for (byte b : hashBytes) {
                String hex = Integer.toHexString(0xff & b);
                if (hex.length() == 1) {
                    hexString.append('0');
                }
                hexString.append(hex);
            }
            return hexString.toString();
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return null;
    }
}
