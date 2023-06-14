package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.MessageModel;
import org.springframework.messaging.handler.annotation.MessageMapping;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.stereotype.Controller;

@Controller
public class WebSocketChatController {
    private final SimpMessagingTemplate messagingTemplate;

    public WebSocketChatController(SimpMessagingTemplate messagingTemplate) {
        this.messagingTemplate = messagingTemplate;
    }

    @MessageMapping("/hello")
    @SendTo("/topic/chat")
    public void greeting(MessageModel message) throws Exception {
        Thread.sleep(1000);
        int chatId = message.getChatId();
        String sendToPath = "/topic/chat/" + chatId;
        messagingTemplate.convertAndSend(sendToPath, message);
    }
}
