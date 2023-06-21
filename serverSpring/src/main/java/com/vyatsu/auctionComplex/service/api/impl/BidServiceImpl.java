package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.Bid;
import com.vyatsu.auctionComplex.repository.api.BidRepository;
import com.vyatsu.auctionComplex.service.api.BidService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class BidServiceImpl implements BidService {
    private final BidRepository bidRepository;

    public BidServiceImpl(BidRepository bidRepository) {
        this.bidRepository = bidRepository;
    }

    @Override
    public List<Bid> getBidsByAuctionItemId(Long id) {
        return bidRepository.getAuctionChatByAuctionItemId(id);
    }

    @Override
    public List<Bid> getBestBidByAuctionItemId(Long id) {
        return bidRepository.getBestBidByAuctionItemId(id);
    }

}
