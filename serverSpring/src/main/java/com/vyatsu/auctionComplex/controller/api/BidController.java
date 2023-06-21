package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import com.vyatsu.auctionComplex.entity.api.Bid;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.service.api.BidService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;
import java.util.Optional;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/bid")
public class BidController {
    private final BidService bidService;

    @PostMapping("/best")
    public ResponseEntity<Bid> getBestOfferByAuctionItemId(@RequestBody AuctionItem auctionItem){
        LOGGER.info("find best offer by auction item id " + auctionItem.getId());
        List<Bid> bid = bidService.getBestBidByAuctionItemId(Long.valueOf(auctionItem.getId()));
        if(bid.stream().count() > 0){
            return new ResponseEntity<>(bid.get(0), HttpStatus.OK);
        }
        else{
            return new ResponseEntity<>(HttpStatus.OK);
        }

    }

    @PostMapping("/")
    public ResponseEntity<List<Bid>> getBidsByAuctionItemId(@RequestBody AuctionItem auctionItem){
        LOGGER.info("find all bids by auction item id " + auctionItem.getId());
        List<Bid> bids = bidService.getBidsByAuctionItemId(Long.valueOf(auctionItem.getId()));
        return new ResponseEntity<>(bids, HttpStatus.OK);
    }
}
