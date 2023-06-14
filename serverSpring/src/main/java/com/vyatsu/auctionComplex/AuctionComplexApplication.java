package com.vyatsu.auctionComplex;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.Banner;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.security.servlet.SecurityAutoConfiguration;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.security.config.annotation.authentication.configuration.AuthenticationConfiguration;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

import java.io.IOException;
import java.time.LocalDateTime;

@EnableScheduling
@SpringBootApplication(exclude = {SecurityAutoConfiguration.class})
public class AuctionComplexApplication {

	@Autowired
	private SimpMessagingTemplate simpMessagingTemplate;

	public static final Logger LOGGER = LoggerFactory.getLogger(AuctionComplexApplication.class);

	public static void main(String[] args) {
		new SpringApplicationBuilder(AuctionComplexApplication.class)
				.bannerMode(Banner.Mode.OFF)
				.run(args);
	}

	@Scheduled(cron = "0/10 * * * * ?")
	public void sc1() throws IOException {
		String rspMsg = Thread.currentThread().getName() + " 自动返回 | sc1：" + LocalDateTime.now();
//        MyWebSocketHandler.groupSend();

		simpMessagingTemplate.convertAndSend("/topic/hello", rspMsg);
	}

	@Bean
	public WebMvcConfigurer corsConfigurer() {
		return new WebMvcConfigurer() {
			@Override
			public void addCorsMappings(CorsRegistry registry) {
				registry.addMapping("/*/**")
						.allowedOrigins("*")
						.allowedMethods("*")
						.allowedHeaders("*");
			}
		};
	}
}
