package com.vyatsu.auctionComplex.controller.api;

import jakarta.mail.*;
import jakarta.mail.internet.InternetAddress;
import jakarta.mail.internet.MimeMessage;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Date;
import java.util.Properties;
import java.util.Random;

public class EmailController {
    public int getConfirmCode(String to) throws IOException, MessagingException {
        FileInputStream fileInputStream = new FileInputStream("src/main/config.properties");
        Properties properties = new Properties();
        properties.load(fileInputStream);

        String user = properties.getProperty("mail.user");
        String password = properties.getProperty("mail.password");
        String hostSMTP = properties.getProperty("mail.host");
        Integer port = Integer.valueOf(properties.getProperty("mail.port"));

        Properties prop = new Properties();
        prop.put("mail.smtp.host", hostSMTP);
        prop.put("mail.smtp.ssl.enable", true);
        prop.put("mail.smtp.port", port);
        prop.put("mail.smtp.auth", "true");
        prop.put("mail.smtp.ssl.protocols", "TLSv1.2");

        Session session = Session.getDefaultInstance(prop, new Authenticator() {
            @Override
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(user, password);
            }
        });

        Message msg = new MimeMessage(session);
        msg.setFrom(new InternetAddress(user));
        InternetAddress[] addresses = {new InternetAddress(to)};
        msg.setRecipients(Message.RecipientType.TO, addresses);
        msg.setSubject("Интернет-аукцион готовых идей и инноваций");
        msg.setSentDate(new Date());

        Random random = new Random();
        int code = random.nextInt(999999);
        code = Integer.parseInt(String.format("%06d", code));
        msg.setText(code + " - ваш код подтверждения на интернет-аукционе уникальных идей и инноваций");
        Transport.send(msg);
        return code;
    }
}
