package com.vyatsu.auctionComplex.service.api;

import com.vyatsu.auctionComplex.entity.api.Attachment;

import java.util.List;

public interface AttachmentService {
    List<Attachment> getAttachmentsByAuctionItemId(Long id);
    String getAttachmentLinkByAttachmentId(Long id);
}
