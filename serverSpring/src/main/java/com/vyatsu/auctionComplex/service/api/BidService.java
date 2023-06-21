package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.Bid;

import java.util.List;

public interface BidService {
    List<Bid> getBidsByAuctionItemId(Long id);

    List<Bid> getBestBidByAuctionItemId(Long id);

}
