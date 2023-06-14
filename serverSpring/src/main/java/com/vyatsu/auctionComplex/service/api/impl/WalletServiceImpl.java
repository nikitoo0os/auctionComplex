package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.Wallet;
import com.vyatsu.auctionComplex.repository.api.WalletRepository;
import com.vyatsu.auctionComplex.service.api.WalletService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class WalletServiceImpl implements WalletService {
    private final WalletRepository walletRepository;

    public WalletServiceImpl(WalletRepository walletRepository) {
        this.walletRepository = walletRepository;
    }

    @Override
    public List<Wallet> getWalletByUserId(int userId) {
        return walletRepository.getWalletsByUserId(userId);
    }
}
