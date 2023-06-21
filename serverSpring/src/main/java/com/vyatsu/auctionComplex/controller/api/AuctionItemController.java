package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.FilterModel;
import com.vyatsu.auctionComplex.dto.UserModel;
import com.vyatsu.auctionComplex.entity.api.Attachment;
import com.vyatsu.auctionComplex.entity.api.AuctionItem;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.service.api.AttachmentService;
import com.vyatsu.auctionComplex.service.api.AuctionItemService;
import com.vyatsu.auctionComplex.service.api.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Comparator;
import java.util.List;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/auctionItem")
public class AuctionItemController {
    private final AuctionItemService auctionItemService;
    private final AttachmentService attachmentService;
    private final UserService userService;

    @GetMapping("/")
    private ResponseEntity<List<AuctionItem>> getAllAuctionItems(){
        LOGGER.info("get all auction items");
        List<AuctionItem> auctionItems = auctionItemService.getAllAuctionItems();
        auctionItems.sort(Comparator.comparingLong(AuctionItem::getId).reversed());
        return new ResponseEntity<>(auctionItems, HttpStatus.OK);
    }
    @GetMapping("/{id}")
    private ResponseEntity<AuctionItem> getAuctionItemById(@PathVariable Long id){
        LOGGER.info("get auction item by id");
        AuctionItem auctionItem = auctionItemService.getAuctionItemById(id);
        return new ResponseEntity<>(auctionItem, HttpStatus.OK);
    }
    @GetMapping("/attachments/{id}")
    private ResponseEntity<List<Attachment>> getAttachmentByAuctionItemId(@PathVariable Long id){
        LOGGER.info("get attachments by auction item id");
        List<Attachment> attachments = attachmentService.getAttachmentsByAuctionItemId(id);
        return new ResponseEntity<>(attachments, HttpStatus.OK);
    }

    @PostMapping("/auctioneer")
    private ResponseEntity<List<AuctionItem>> getAuctionItemByAuctioneer(@RequestBody UserModel model){
        LOGGER.info("get auction items by auctioneer #" + model.getId());
        List<AuctionItem> auctionItems = auctionItemService.getAuctionItemsByAuctioneer(model.getId());
        return new ResponseEntity<>(auctionItems, HttpStatus.OK);
    }

    @PostMapping("/categories")
    private ResponseEntity<List<String>> getAllCategories(){
        LOGGER.info("get all categories");
        List<String> categories = auctionItemService.getAllCategories();
        return new ResponseEntity<>(categories, HttpStatus.OK);
    }

    @PostMapping("/filter")
    private ResponseEntity<List<AuctionItem>> getFilterAuctionItems(@RequestBody FilterModel model){
        LOGGER.info("get filter items");
        List<AuctionItem> filterAuctionItems = auctionItemService.getFilterAuctionItems(model.getInvestmentVolume(), model.getTime(), model.getCategory());
        return new ResponseEntity<>(filterAuctionItems, HttpStatus.OK);
    }

}
