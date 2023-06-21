package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.CreateWalletModel;
import com.vyatsu.auctionComplex.dto.DeleteWalletModel;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.entity.api.Wallet;
import com.vyatsu.auctionComplex.service.api.WalletService;
import com.vyatsu.auctionComplex.service.auth.TokenService;
import jakarta.mail.MessagingException;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/wallet")
public class WalletController {
        private final WalletService walletService;
        private final TokenService tokenService;
        private int confirmCode;

        @GetMapping("/user/{id}")
        public ResponseEntity<List<Wallet>> registerUser(@PathVariable int id){
                LOGGER.info("find wallet by user " + id);
                List<Wallet> wallet = walletService.getWalletByUserId(Math.toIntExact(id));
                return new ResponseEntity<>(wallet, HttpStatus.OK);
        }

        @PostMapping("user/drop")
        public ResponseEntity deleteWallet(@RequestBody DeleteWalletModel model){
                if(tokenService.findUserByToken(model.getToken()) != null){
                        LOGGER.info("delete wallet " + model.getId() + " #" + model.getToken());
                        walletService.deleteWalletByWalletId(model.getId());
                        return new ResponseEntity(HttpStatus.OK);
                }
                else{
                        return new ResponseEntity(HttpStatus.UNAUTHORIZED);
                }
        }
        @PostMapping("user/new/code")
        public ResponseEntity createConfirmCode(@RequestBody CreateWalletModel model) throws MessagingException, IOException {
                User user = tokenService.findUserByToken(model.getToken());
                if(user != null){
                        LOGGER.info("create confirm code " + " #" + model.getToken());
                        confirmCode = new EmailController().getConfirmCode(user.getEmail());
                        return new ResponseEntity(HttpStatus.OK);
                }
                else{
                        return new ResponseEntity(HttpStatus.UNAUTHORIZED);
                }
        }
        @PostMapping("user/new/confirm")
        public ResponseEntity checkConfirmCode(@RequestBody CreateWalletModel model) throws MessagingException, IOException {
                User user = tokenService.findUserByToken(model.getToken());
                if (user != null) {
                        LOGGER.info("create confirm code " + " #" + model.getToken());
                        if (model.getConfirmCode() == confirmCode) {
                                createWallet(model);
                                return new ResponseEntity(HttpStatus.OK);
                        } else {
                                return new ResponseEntity(HttpStatus.NOT_ACCEPTABLE);
                        }
                } else {
                        return new ResponseEntity(HttpStatus.UNAUTHORIZED);
                }
        }

        public void createWallet(CreateWalletModel model){
                User user = tokenService.findUserByToken(model.getToken());
                if(user != null && model.getAddress().length() == 48){
                        LOGGER.info("create new wallet " + model.getAddress() + " #" + model.getToken());
                        walletService.createWalletByUserId(model.getAddress(), user.getId());
                }
        }
}
