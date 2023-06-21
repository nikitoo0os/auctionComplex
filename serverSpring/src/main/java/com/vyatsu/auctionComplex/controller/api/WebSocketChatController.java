package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.MessageModel;
import com.vyatsu.auctionComplex.entity.api.*;
import com.vyatsu.auctionComplex.repository.api.BidRepository;
import com.vyatsu.auctionComplex.repository.api.ChatMessageRepository;
import com.vyatsu.auctionComplex.service.api.AuctionChatService;
import com.vyatsu.auctionComplex.service.api.AuctionItemService;
import com.vyatsu.auctionComplex.service.api.UserService;
import com.vyatsu.auctionComplex.service.api.WalletService;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.stereotype.Controller;

import java.time.Instant;
import java.util.Comparator;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

@Controller
public class WebSocketChatController {
    private final SimpMessagingTemplate messagingTemplate;
    private final AuctionChatService auctionChatService;
    private final AuctionItemService auctionItemService;
    private final UserService userService;
    private final ChatMessageRepository chatMessageRepository;
    private final BidRepository bidRepository;
    private final WalletService walletService;


    public WebSocketChatController(SimpMessagingTemplate messagingTemplate, AuctionChatService auctionChatService, AuctionItemService auctionItemService, UserService userService, ChatMessageRepository chatMessageRepository, BidRepository bidRepository, WalletService walletService) {
        this.messagingTemplate = messagingTemplate;
        this.auctionChatService = auctionChatService;
        this.auctionItemService = auctionItemService;
        this.userService = userService;
        this.chatMessageRepository = chatMessageRepository;
        this.bidRepository = bidRepository;
        this.walletService = walletService;
    }

    @MessageMapping("/hello")
    @SendTo("/topic/chat")
    public void greeting(MessageModel message) {

        Double[] digits = searchDigitFromText(message.getText());
        double entryPercentageMessage = digits[1];
        double investmentVolumeMessage = digits[0];
        int chatId = message.getAuctionChatId();
        AuctionItem auctionItem = auctionItemService.getAuctionItemByAuctionChatId((long) chatId);

        Wallet richestWallet = walletService.getWalletByUserId(message.getUserId()).stream()
                .max(Comparator.comparing(Wallet::getBalance))
                .orElse(null);

        if(investmentVolumeMessage >= auctionItem.getInvestmentSize() && richestWallet.getBalance() >= investmentVolumeMessage){
            User user = userService.getUserById(message.getUserId());
            ChatMessage chatMessage = new ChatMessage();
            chatMessage.setText(message.getText());
            chatMessage.setAuctionChat(auctionChatService.getAuctionChatById(Long.valueOf(auctionChatService.getAuctionChatByAuctionId((long) message.getAuctionChatId()).getId())));
            chatMessage.setUser(user);
            chatMessage.setTimestamp(Instant.now());
            chatMessageRepository.save(chatMessage);

            Bid bid = new Bid();
            bid.setUser(user);
            long auctionChatId = message.getAuctionChatId();
            bid.setAuctionItem(auctionItemService.getAuctionItemByAuctionChatId(auctionChatId));
            bid.setEntryPercentage(entryPercentageMessage);
            bid.setInvestmentVolume(investmentVolumeMessage);
            bid.setTimestamp(Instant.from(Instant.now()));
            bidRepository.save(bid);

            String sendToPath = "/topic/chat/" + chatId;
            messagingTemplate.convertAndSend(sendToPath, message);
        }

    }

    private Double[] searchDigitFromText(String input){
        String regex = "(\\d+)%?";

        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(input);

        Double[] digits = new Double[2];
        int count = 0;
        while (matcher.find() && count < 2) {
            String match = matcher.group(1);
            double value = Double.parseDouble(match);

            if (count == 0) {
                digits[0] = Double.valueOf(value);
                System.out.println("Первое значение: " + digits[0]);
            } else if (count == 1) {
                digits[1] = Double.valueOf(value);
                System.out.println("Второе значение: " + digits[1]);
            }

            count++;
        }

        return digits;
    }

}
