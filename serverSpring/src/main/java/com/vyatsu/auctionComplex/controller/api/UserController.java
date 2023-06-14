package com.vyatsu.auctionComplex.controller.api;

import com.vyatsu.auctionComplex.dto.ConfirmEmailModel;
import com.vyatsu.auctionComplex.dto.LoginModel;
import com.vyatsu.auctionComplex.dto.UserModel;
import com.vyatsu.auctionComplex.entity.api.User;
import com.vyatsu.auctionComplex.entity.auth.JwtSession;
import com.vyatsu.auctionComplex.service.api.UserService;
import com.vyatsu.auctionComplex.service.auth.TokenService;
import io.jsonwebtoken.JwtBuilder;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import jakarta.mail.MessagingException;
import lombok.RequiredArgsConstructor;
import org.modelmapper.ModelMapper;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.Date;
import java.util.Objects;

import static com.vyatsu.auctionComplex.AuctionComplexApplication.LOGGER;

@RestController
@RequiredArgsConstructor
@RequestMapping("/user")
public class UserController {

    private final UserService userService;
    private final TokenService tokenService;
    private int confirmCode;
    private User user;

    @GetMapping("/{id}")
    public ResponseEntity<UserModel> getUserById(@PathVariable Long id) {
        LOGGER.info("get user by id: " + id);
        UserModel userDto = userService.getUserDtoById(id);
        if (userDto != null) {
            return new ResponseEntity<>(userDto, HttpStatus.OK);
        }
        return ResponseEntity.notFound().build();
    }

    @PostMapping("/register")
    public ResponseEntity<User> registerUser(@RequestBody User user){
        LOGGER.info("creating new user");
        LOGGER.info(String.valueOf(user));
        User createdUser = userService.createUser(user);
        return new ResponseEntity<>(createdUser, HttpStatus.CREATED);
    }
    @PostMapping("/login")
        public ResponseEntity<User> firstStepAuth(@RequestBody LoginModel loginModel) throws MessagingException, IOException {
        UserModel userModel;

        if(loginModel.getToken() == null){
            LOGGER.info("login user...");
            LOGGER.info(String.valueOf(loginModel));
            user = userService.getUserByLoginAndPassword(loginModel.getUsernameOrEmail(), loginModel.getPassword());

//            userModel = mapUserToUserModel(user);
//            LOGGER.info(user.toString());

               secondStepAuth(user.getEmail());

            user.setToken(tokenService.createSession(user));
        }
        else{
            LOGGER.info("find by token " + loginModel.getToken());
            user = tokenService.findUserByToken(loginModel.getToken());

        }

        return new ResponseEntity<>(user, HttpStatus.OK);
    }
    private static UserModel mapUserToUserModel(User user) {
        if(user != null){
            ModelMapper modelMapper = new ModelMapper();
            return modelMapper.map(user, UserModel.class);
        }
        return null;
    }
    public void secondStepAuth(String email) throws MessagingException, IOException {
        confirmCode = new EmailController().getConfirmCode(email);
    }

    @PostMapping("/login/confirm")
    public ResponseEntity<User> confirmCode(@RequestBody ConfirmEmailModel confirmEmailModel) {
        LOGGER.info("confirm code...");
        int code = confirmEmailModel.getConfirmCode();

        //code = code.replace(" ", "");
        if (code == confirmCode) {
            LOGGER.info("ID: " + user.getId());
            return new ResponseEntity<>(user, HttpStatus.OK);
        }
        else{
            return new ResponseEntity<>(user, HttpStatus.UNAUTHORIZED);
        }
    }
}
