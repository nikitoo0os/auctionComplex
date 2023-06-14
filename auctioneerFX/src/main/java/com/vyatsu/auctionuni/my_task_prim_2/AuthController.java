package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.User;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.io.FileInputStream;
import java.io.IOException;
import java.net.URL;
import java.util.*;

public class AuthController implements Initializable {

    public PasswordField password;
    public TextField firstName;
    public TextField secondName;
    public TextField email;
    public TextField login;
    public TextField inputCode;
    public Button confirmButton;
    public Button submit;
    public Button registerBtn;
    public Label status;
    public Label warningLabel;
    private BaseController baseController;

    private User user;
    private String confirmCode;
    private Button firstPageButton;


    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        baseController = new BaseController();
    }

    @FXML
    public void authFirstStep(ActionEvent event) throws IOException, MessagingException {

        System.out.println("Открытие окна двухфакторной авторизации!");
        if(this.user == null){
            try{
                this.user = baseController.getUser(login.getText(), password.getText());
            }
            catch (Exception e){
                warningLabel.setText("Неправильный логин или пароль!");
            }
        }

        if(this.user != null){
            if(submit != null){
                Stage stage1 = (Stage) submit.getScene().getWindow();
                stage1.close();
            }

            sendEmail(this.user.getEmail());

            Stage stage = new Stage();
            Scene scene = new Scene(new Group());
            stage.setTitle("Подтверждение электронной почты");

            Parent pane = null;
            try {
                FXMLLoader loader = new FXMLLoader(getClass().getResource("/ConfirmEmailView.fxml"));
                pane = loader.load();
                AuthController controller = loader.getController();
                controller.setConfirmCode(this.confirmCode, this.user);
                System.out.println("Второй этап кнопка: " + this.firstPageButton);
                controller.setFirstPage(this.firstPageButton);
                scene.setRoot(pane);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            stage.setScene(scene);
            stage.show();
        }

    }
    @FXML
    private void authSecondStep(ActionEvent event) throws IOException {
        System.out.println("Успешная авторизация!");

        Stage stage2 = (Stage)firstPageButton.getScene().getWindow();
        stage2.close();

        if(Objects.equals(inputCode.getText(), confirmCode.replace(" ", ""))){
            Stage stage1 = (Stage) confirmButton.getScene().getWindow();
            stage1.close();

            Stage stage = new Stage();
            Scene scene = new Scene(new Group());
            stage.setTitle("Мои аукционные лоты");
            System.out.println("3 этап кнопка: " + this.firstPageButton);
            Parent pane = null;
            try {
                FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuctionItemsView.fxml"));
                pane = loader.load();
                AuctionItemsController controller = loader.getController();
                System.out.println(this.user.getId());
                controller.setUser(this.user);
                scene.setRoot(pane);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            stage.setScene(scene);
            stage.show();
        }

    }

    private void setConfirmCode(String confirmCode, User user) {
        this.confirmCode = confirmCode;
        this.user = user;
    }

    @FXML
    private void registerStep(ActionEvent event) throws IOException{
        Stage stage1 = (Stage) registerBtn.getScene().getWindow();
        stage1.close();

            Stage stage = new Stage();
            Scene scene = new Scene(new Group());
            stage.setTitle("Регистрация");

            Parent pane = null;
            try {
                FXMLLoader loader = new FXMLLoader(getClass().getResource("/RegisterUserView.fxml"));
                pane = loader.load();
                scene.setRoot(pane);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            stage.setScene(scene);
            stage.show();

    }

    public void createUser(ActionEvent event) throws IOException, MessagingException {
        if(!baseController.checkUserByEmail(email.getText())){
            this.user = baseController.createUser(
                    password.getText(),
                    firstName.getText(),
                    secondName.getText(),
                    email.getText(),
                    email.getText());
            authFirstStep(event);
        }
        else{
            status.setText("Электронная почта уже зарегистрирована!");
        }
    }

    private void sendEmail(String to) throws IOException, MessagingException {
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
        confirmCode = String.format("%06d", code);
        msg.setText(confirmCode + " - ваш код подтверждения на интернет-аукционе уникальных идей и инноваций");

        Transport.send(msg);
    }


    public void setFirstPage(Button auth_button) {
        this.firstPageButton = auth_button;
    }
}
