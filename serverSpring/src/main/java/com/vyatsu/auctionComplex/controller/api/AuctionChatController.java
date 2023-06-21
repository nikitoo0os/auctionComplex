package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.BidListFromChatModel;
import com.vyatsu.auctionComplex.dto.ChatMessageModel;
import com.vyatsu.auctionComplex.dto.UserModel;
import com.vyatsu.auctionComplex.entity.api.AuctionChat;
import com.vyatsu.auctionComplex.entity.api.Bid;
import com.vyatsu.auctionComplex.entity.api.ChatMessage;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.service.api.AuctionChatService;
import com.vyatsu.auctionComplex.service.api.BidService;
import com.vyatsu.auctionComplex.service.api.ChatMessageService;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/auctionChat")
public class AuctionChatController {
    private final AuctionChatService auctionChatService;
    private final ChatMessageService chatMessageService;
    private final BidService bidService;

    @GetMapping("/{id}")
    private ResponseEntity<List<List<Object>>> getChatMessagesByAuctionId(@PathVariable Long id){
        LOGGER.info("get auction chat by auction id");
        AuctionChat auctionChat = auctionChatService.getAuctionChatByAuctionId(id);
        LOGGER.info("get chat messages by auction chat id");
        List<ChatMessageModel> messages = new ArrayList<>();

         List objects = List.of(chatMessageService.getMessagesByAuctionChatId(Long.valueOf(auctionChat.getId())));

        return ResponseEntity.ok(objects);
    }
    private static ChatMessageModel mapChatMessageToChatMessageModel(ChatMessage chatMessage) {
        if(chatMessage != null){
            ModelMapper modelMapper = new ModelMapper();
            return modelMapper.map(chatMessage, ChatMessageModel.class);
        }
        return null;
    }
    @GetMapping("/get/{id}")
    private ResponseEntity<AuctionChat> getAuctionChatByAuctionId(@PathVariable Long id){
        LOGGER.info("get auction chat by auction id");
        AuctionChat auctionChat = auctionChatService.getAuctionChatByAuctionId(id);
        return new ResponseEntity<>(auctionChat, HttpStatus.OK);
    }

    @GetMapping("/get/bids/{id}")
    private ResponseEntity<List<BidListFromChatModel>> getBidListByAuctionId(@PathVariable Long id){
        List<BidListFromChatModel> resultList = new ArrayList<>();
        List<Bid> bids = bidService.getBidsByAuctionItemId(id);
        for(Bid bid : bids){
            BidListFromChatModel model = new BidListFromChatModel();
            model.setId(bid.getId());
            model.setEntryPercentage(bid.getEntryPercentage());
            //model.setFirstNameUser(bid.getUser().getFirstName());
            model.setTimestamp(bid.getTimestamp());
            model.setInvestmentVolume(bid.getInvestmentVolume());
            resultList.add(model);
        }
        return new ResponseEntity<>(resultList, HttpStatus.OK);
    }

}
