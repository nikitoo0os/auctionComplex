package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.Wallet;
import com.vyatsu.auctionComplex.repository.api.UserRepository;
import com.vyatsu.auctionComplex.repository.api.WalletRepository;
import com.vyatsu.auctionComplex.service.api.WalletService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class WalletServiceImpl implements WalletService {
    private final WalletRepository walletRepository;
    private final UserRepository userRepository;

    public WalletServiceImpl(WalletRepository walletRepository, UserRepository userRepository) {
        this.walletRepository = walletRepository;
        this.userRepository = userRepository;
    }

    @Override
    public List<Wallet> getWalletByUserId(int userId) {
        return walletRepository.getWalletsByUserId(userId);
    }

    @Override
    public void createWalletByUserId(String address, int userId) {
        Wallet wallet = new Wallet();
        wallet.setUser(userRepository.getUserById(userId));
        wallet.setAddress(address);
        wallet.setBalance(0.0);
        walletRepository.save(wallet);
    }

    @Override
    public void deleteWalletByWalletId(Long id) {
        walletRepository.deleteById(id);
    }
}
