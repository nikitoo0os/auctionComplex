package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.service.api.AttachmentService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequiredArgsConstructor
@RequestMapping("/attachment")
public class AttachmentController {

    private final AttachmentService attachmentService;

//    @GetMapping("/{id}")
//    private ResponseEntity<AuctionItem> getAttachmentById(@PathVariable Long id){
//        LOGGER.info("get attachment by id");
//        AuctionItem auctionItem = attachmentService.(id);
//        return new ResponseEntity<>(auctionItem, HttpStatus.OK);
//    }
}
