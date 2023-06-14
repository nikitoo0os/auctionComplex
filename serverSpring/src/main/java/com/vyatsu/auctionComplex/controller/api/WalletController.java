package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.entity.api.Wallet;
import com.vyatsu.auctionComplex.service.api.WalletService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/wallet")
public class WalletController {
        private final WalletService walletService;

        @GetMapping("/user/{id}")
        public ResponseEntity<List<Wallet>> registerUser(@PathVariable int id){
                LOGGER.info("find wallet by user " + id);
                List<Wallet> wallet = walletService.getWalletByUserId(Math.toIntExact(id));
                return new ResponseEntity<>(wallet, HttpStatus.OK);
        }
}
