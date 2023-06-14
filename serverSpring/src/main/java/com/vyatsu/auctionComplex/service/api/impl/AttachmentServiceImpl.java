package com.vyatsu.auctionComplex.service.api.impl;

import com.vyatsu.auctionComplex.entity.api.Attachment;
import com.vyatsu.auctionComplex.entity.api.AuctionChat;
import com.vyatsu.auctionComplex.repository.api.AttachmentRepository;
import com.vyatsu.auctionComplex.repository.api.AuctionChatRepository;
import com.vyatsu.auctionComplex.service.api.AttachmentService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AttachmentServiceImpl implements AttachmentService  {
    private final AttachmentRepository attachmentRepository;
    private final AuctionChatRepository auctionChatRepository;

    public AttachmentServiceImpl(AttachmentRepository attachmentRepository, AuctionChatRepository auctionChatRepository) {
        this.attachmentRepository = attachmentRepository;
        this.auctionChatRepository = auctionChatRepository;
    }

    @Override
    public List<Attachment> getAttachmentsByAuctionItemId(Long id) {
        AuctionChat auctionChat = auctionChatRepository.getAuctionChatByAuctionItemId(id);
        return attachmentRepository.getAttachmentsByAuctionChatId(Long.valueOf(auctionChat.getId()));
    }

    @Override
    public String getAttachmentLinkByAttachmentId(Long id) {
        return null;
    }
}
