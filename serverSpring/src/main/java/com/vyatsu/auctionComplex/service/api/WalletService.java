package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.Wallet;

import java.util.List;

public interface WalletService {
    List<Wallet> getWalletByUserId(int userId);
}
