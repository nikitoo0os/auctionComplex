package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import javax.mail.MessagingException;
import java.io.IOException;
import java.util.Objects;

public class ProfileController {
    public TextField firstName;
    public TextField secondName;
    public TextField email;
    public Label labelProfileUser;
    public TextField username;
    public TextField oldPassword;
    public TextField newPassword;
    public TextField confirmNewPassword;
    public TextField inputCode;
    public Button confirmButton;
    public Button confirmEmailBtn;
    private User user;
    private String confirmCode;
    BaseController baseController;

    public void setUser(User user){
        baseController = new BaseController();
        this.user = user;
        firstName.setText(user.getFirstName());
        secondName.setText(user.getSecondName());
        email.setText(user.getEmail());
        username.setText(user.getUsername());

        labelProfileUser.setText("Пользователь-аукционист №" + this.user.getId());
        System.out.println(user.getIsVerify());
        if(user.getIsVerify()){
            confirmEmailBtn.setDisable(true);
        }
    }

    public void saveUser(ActionEvent event) throws MessagingException, IOException {

    }

    public void changePassword(ActionEvent event) {
    }

    public void confirmEmail(ActionEvent event) throws MessagingException, IOException {
        confirmCode = baseController.getConfirmCodeAndSendToEmail(email.getText());

        Stage stage = new Stage();
        Scene scene = new Scene(new Group());
        stage.setTitle("Подтверждение электронной почты");

        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/ValidationEmailView.fxml"));
            pane = loader.load();

            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();
    }

    public void secondStepConfirmEmail(ActionEvent event) {
        if(Objects.equals(inputCode.getText(), confirmCode)){
            baseController.setVerifyUser(this.user, true);
            Stage stage = (Stage) confirmButton.getScene().getWindow();
            stage.close();
        }
    }

}
