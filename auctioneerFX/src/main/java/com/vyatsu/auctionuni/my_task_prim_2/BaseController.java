package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.*;
import com.vyatsu.auctionuni.my_task_prim_2.transfermanager.UploadFile;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import org.sqlite.JDBC;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.net.URISyntaxException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.sql.*;
import java.time.LocalDate;
import java.util.*;
import java.util.Date;

public class BaseController {

    private ObservableList<AuctionItem> auctionItemsData = FXCollections.observableArrayList();

    private User userAuctioneer;
    private AuctionItem auctionItem;

    public Scene changeScene(String fxml) throws IOException {
        Parent pane = FXMLLoader.load(getClass().getResource(fxml));
        return new Scene(pane);
    }
    public ObservableList<AuctionItem> GetAllAuctionItem(){
        ObservableList<AuctionItem> auctionItemsData = FXCollections.observableArrayList();
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select * from auction_items");
            return getAuctionItems(rs, auctionItemsData);
        }
        catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    public ObservableList<AuctionItem> GetAuctionItemByIdAuctioneer(int idAuctioneer){
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select * from auction_items where auctioneer_id=" + idAuctioneer );
            return getAuctionItems(rs, auctionItemsData);
        }
        catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    private ObservableList<AuctionItem> getAuctionItems(ResultSet rs, ObservableList<AuctionItem> auctionItemsData) throws SQLException {
        while(rs.next()){
            AuctionItem auctionItem = new AuctionItem();
            auctionItem.setId(rs.getInt("id"));
            auctionItem.setTitle(rs.getString("title"));
            auctionItem.setDescription(rs.getString("description"));
            auctionItem.setInvestmentSize(rs.getDouble("investment_size"));
            auctionItem.setStartDate(rs.getObject("start_date", LocalDate.class));
            auctionItem.setEndDate(rs.getObject("end_date", LocalDate.class));
            auctionItem.setLocation(rs.getString("location"));
            auctionItem.setAuctioneer(getUserById(rs.getInt("auctioneer_id")));
            auctionItem.setCategory(rs.getString("category"));

            auctionItemsData.add(auctionItem);
        }

        return auctionItemsData;
    }
    public AuctionItem getAuctionItem(AuctionItem auctionItem, int idAuctioneer){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_items WHERE title = ? AND description = ? AND start_date = ? AND auctioneer_id = ?");
            ps.setString(1, auctionItem.getTitle());
            ps.setString(2, auctionItem.getDescription());
            ps.setObject(3, auctionItem.getStartDate());
            ps.setLong(4, idAuctioneer);
            ResultSet rs = ps.executeQuery();
            AuctionItem auctionItem1 = null;

            while(rs.next()) {
                auctionItem1 = new AuctionItem();
                auctionItem1.setId(rs.getInt("id"));
                auctionItem1.setTitle(rs.getString("title"));
                auctionItem1.setDescription(rs.getString("description"));
                auctionItem1.setInvestmentSize(rs.getDouble("investment_size"));
                auctionItem1.setStartDate(rs.getObject("start_date", LocalDate.class));
                auctionItem1.setEndDate(rs.getObject("end_date", LocalDate.class));
                auctionItem1.setLocation(rs.getString("location"));
                auctionItem1.setCategory(rs.getString("category"));
                auctionItem1.setAuctioneer(getUserById(rs.getInt("auctioneer_id")));
            }
                return auctionItem1;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }

    }
    public AuctionItem getAuctionItemById(int id){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_items WHERE id = ?");
            ps.setLong(1, id);
            ResultSet rs = ps.executeQuery();
            AuctionItem auctionItem1 = null;

            while(rs.next()) {
                auctionItem1 = new AuctionItem();
                auctionItem1.setId(rs.getInt("id"));
                auctionItem1.setTitle(rs.getString("title"));
                auctionItem1.setDescription(rs.getString("description"));
                auctionItem1.setInvestmentSize(rs.getDouble("investment_size"));
                auctionItem1.setStartDate(rs.getObject("start_date", LocalDate.class));
                auctionItem1.setEndDate(rs.getObject("end_date", LocalDate.class));
                auctionItem1.setLocation(rs.getString("location"));
                auctionItem1.setCategory(rs.getString("category"));
            }
            return auctionItem1;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public ObservableList<AuctionItem> getAuctionItemsByAuctioneer(User auctioneer){

        ObservableList<AuctionItem> auctionItemsByAuctioneer = FXCollections.observableArrayList();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_items WHERE auctioneer_id = ?");
            ps.setLong(1, auctioneer.getId());
            ResultSet rs = ps.executeQuery();
            AuctionItem auctionItem1 = null;

            while(rs.next()) {
                auctionItem1 = new AuctionItem();
                auctionItem1.setId(rs.getInt("id"));
                auctionItem1.setTitle(rs.getString("title"));
                auctionItem1.setDescription(rs.getString("description"));
                auctionItem1.setInvestmentSize(rs.getDouble("investment_size"));
                auctionItem1.setStartDate(rs.getObject("start_date", LocalDate.class));
                auctionItem1.setEndDate(rs.getObject("end_date", LocalDate.class));
                auctionItem1.setLocation(rs.getString("location"));
                auctionItem1.setCategory(rs.getString("category"));

                auctionItemsByAuctioneer.add(auctionItem1);
            }
            return auctionItemsByAuctioneer;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public User getUser(String email, String password) {
        try {
            System.out.println(email);
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM users WHERE email = ?;");
            ps.setString(1, email);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {

                userAuctioneer = new User(
                        rs.getInt("id"),
                        rs.getString("first_name"),
                        rs.getString("second_name"),
                        rs.getString("email"),
                        rs.getString("password"),
                        rs.getString("username"),
                        rs.getBoolean("is_verify")
                );
            }
            if (Objects.equals(hashPassword(password), userAuctioneer.getPassword())) {
                return userAuctioneer;
            } else {
                return null;
            }
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public User getUserById(int id){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM users WHERE id = ?;");
            ps.setLong(1, id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                userAuctioneer = new User(
                        rs.getInt("id"),
                        rs.getString("first_name"),
                        rs.getString("second_name"),
                        rs.getString("email"),
                        rs.getString("password"),
                        rs.getString("username"),
                        rs.getBoolean("is_admin")
                );
            }

            return userAuctioneer;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public boolean checkUserByEmail(String email){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM users WHERE email = ?");
            ps.setString(1, email);
            System.out.println(email);
            ResultSet rs = ps.executeQuery();
            while (rs.next()){
                if(rs.getLong("id") > 0){
                    System.out.println("Уже есть такой пользователь");
                    return true;
                }
            }
            System.out.println(rs.getRow());

        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    public User createUser(String password, String firstName, String secondName, String email, String username) {


        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("INSERT INTO users(first_name, second_name, email, password, username, is_verify) VALUES(?, ?, ?, ?, ?, ?)");
            ps.setString(1, firstName);
            ps.setString(2, secondName);
            ps.setString(3, email);
            ps.setString(4, hashPassword(password));
            ps.setString(5, username);
            ps.setBoolean(6, false);
            ps.executeUpdate();

            User user = new User();
            user.setFirstName(firstName);
            user.setSecondName(secondName);
            user.setEmail(email);
            user.setPassword(hashPassword(password));
            user.setUsername(username);

            return user;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static String hashPassword(String password) {
        try {
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            byte[] hash = md.digest(password.getBytes());
            StringBuilder hexString = new StringBuilder();
            for (byte b : hash) {
                String hex = Integer.toHexString(0xff & b);
                if (hex.length() == 1) hexString.append('0');
                hexString.append(hex);
            }
            return hexString.toString();
        } catch (NoSuchAlgorithmException e) {
            return null;
        }
    }

    public ObservableList<String> getAllCategories(){
        ObservableList<String> categoryList = FXCollections.observableArrayList();

        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select distinct category from auction_items");
            while (rs.next()){
                categoryList.add(rs.getString("category"));
            }
            return categoryList;
        }
        catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    public void createAuctionItem(AuctionItem auctionItem, String category){

        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("INSERT INTO auction_items(title, description, investment_size, start_date, end_date, auctioneer_id, category, location) VALUES(?, ?, ?, ?, ?, ?, ?, ?)");
            ps.setString(1, auctionItem.getTitle());
            ps.setString(2, auctionItem.getDescription());
            ps.setDouble(3, auctionItem.getInvestmentSize());
            ps.setObject(4, auctionItem.getStartDate());
            ps.setObject(5, auctionItem.getEndDate());
            ps.setLong(6, auctionItem.getAuctioneer().getId());
            ps.setString(7, category);
            ps.setString(8, auctionItem.getLocation());
            ps.executeUpdate();

            AuctionItem newAuctionItem = getAuctionItem(auctionItem, auctionItem.getAuctioneer().getId());

            changeScene("/AuthView.fxml");
        }
        catch (SQLException | IOException e){
            e.printStackTrace();
        }
    }
    public AuctionChat createAuctionChat(AuctionItem auctionItem){

        AuctionItem newAuctionItem = getAuctionItem(auctionItem, auctionItem.getAuctioneer().getId());

        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("INSERT INTO auction_chats(auction_id) VALUES(?)");
            ps.setLong(1, newAuctionItem.getId());
            ps.executeUpdate();

            AuctionChat auctionChat = new AuctionChat();
            System.out.println("aucitonItem: " + auctionItem);
            auctionChat.setAuctionItem(auctionItem);

            System.out.println("Добавленный auctionChat: " + auctionChat);

            changeScene("/AuthView.fxml");

            return auctionChat;
        }
        catch (SQLException | IOException e){
            e.printStackTrace();
            return null;
        }
    }

//    public ChatMessage createChatMessage(AuctionChat auctionChat, User user, String text){
//        ChatMessage chatMessage = new ChatMessage();
//        chatMessage.setAuctionChat(auctionChat);
//        chatMessage.setUser(user);
//        chatMessage.setText(text);
//        chatMessage.setTimestamp(new java.util.Date());
//
//        try{
//            DriverManager.registerDriver(new JDBC());
//            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
//            PreparedStatement ps = con.prepareStatement("INSERT INTO chat_messages(text, timestamp, chat_id, user_id, attachment_id ) VALUES(?, ?, ?, ?, ?)");
//            ps.setString(1, text);
//            ps.setObject(2, chatMessage.getTimestamp());
//            ps.setLong(3, getChatMessageByDateAndUser(chatMessage.getTimestamp(), chatMessage.getUser()).getId());
//            ps.setLong(4, chatMessage.getUser().getId());
//
//            ps.executeUpdate();
//
//            System.out.println("Добавленное сообщение: " + auctionChat);
//
//            //      changeScene("/AuthView.fxml");
//
//            return chatMessage;
//        }
//        catch (SQLException e){
//            e.printStackTrace();
//            return null;
//        }
//    }

    public AuctionChat getAuctionChat(AuctionChat auctionChat){
        AuctionChat auctionChat1 = new AuctionChat();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_chats WHERE auction_id=?");
            System.out.println("Поиск auctionChat по id: " + auctionChat.getAuctionItem().getId());
            ps.setLong(1, auctionChat.getAuctionItem().getId());


            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                auctionChat1.setId(rs.getInt("id"));
                auctionChat1.setAuctionItem(getAuctionItemById(rs.getInt("auction_id")));
            }

            System.out.println(auctionChat1);
            return auctionChat1;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    private ChatMessage getChatMessageByDateAndUser(Timestamp timestamp, User user) {
        ChatMessage chatMessage = new ChatMessage();
        
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM chat_messages WHERE timestamp=? AND user_id=?;");
            ps.setObject(1, timestamp);
            ps.setLong(2, user.getId());
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                chatMessage.setId(rs.getInt("id"));
                chatMessage.setText(rs.getString("text"));
                chatMessage.setUser(getUserById(rs.getInt("user_id")));
                chatMessage.setAuctionChat(getAuctionChatById(rs.getInt("chat_id")));
                chatMessage.setAttachment(getAttachmentById(rs.getInt("attachment_id")));
                chatMessage.setTimestamp(rs.getObject("timestamp", LocalDate.class));
            }

            return chatMessage;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public ObservableList<Attachment> getAttachmentByAuctionChat(AuctionChat auctionChat){
        ObservableList<Attachment> attachments = FXCollections.observableArrayList();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM chat_messages WHERE chat_id=?;");
            ps.setObject(1, auctionChat.getId());

            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Attachment tempAttachment = new Attachment();
                tempAttachment.setId(rs.getInt("id"));
                tempAttachment.setFileSize(rs.getDouble("file_size"));
                tempAttachment.setFileType(rs.getString("file_type"));
                tempAttachment.setKey(rs.getString("url"));
                tempAttachment.setName(rs.getString("name"));
                attachments.add(tempAttachment);
            }

            return attachments;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }

    }

    public Attachment getAttachmentById(int id){
        Attachment attachment = new Attachment();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM attachments WHERE id=?;");
            ps.setObject(1, id);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                attachment.setId(rs.getInt("id"));
                attachment.setFileSize(rs.getDouble("file_size"));
                attachment.setFileType(rs.getString("file_type"));
                attachment.setKey(rs.getString("key"));
                attachment.setName(rs.getString("name"));
                attachment.setTimestamp(rs.getObject("timestamp", LocalDate.class));
            }

            return attachment;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public File getFileFromAWS(Attachment attachment) throws URISyntaxException {
        return new UploadFile().getObjectFromAWS(attachment.getKey());
    }

    public List<File> getFilesFromAWS(ObservableList<Attachment> attachments) throws URISyntaxException {
        List<File> files = new ArrayList<File>();

        for(Attachment attachment : attachments){
            files.add(getFileFromAWS(attachment));
        }

        return files;
    }
    
    public AuctionChat getAuctionChatById(int id){
        AuctionChat auctionChat = new AuctionChat();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_chats WHERE id=?");
            ps.setLong(1, id);
            
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                auctionChat.setId(rs.getInt("id"));
                auctionChat.setAuctionItem(getAuctionItemById(rs.getInt("auction_id")));
            }

            return auctionChat;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
    public AuctionChat getAuctionChatByAuctionId(int id){
        AuctionChat auctionChat = new AuctionChat();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM auction_chats WHERE auction_id=?");
            ps.setLong(1, id);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                auctionChat.setId(rs.getInt("id"));
                auctionChat.setAuctionItem(getAuctionItemById(rs.getInt("auction_id")));
            }

            return auctionChat;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public ChatMessage createChatMessage(AuctionChat auctionChat, User user, String text, File file) throws URISyntaxException, IOException {
        ChatMessage chatMessage = new ChatMessage();
        System.out.println("getAuctionChat: " + getAuctionChat(auctionChat));
        chatMessage.setAuctionChat(getAuctionChat(auctionChat));
        chatMessage.setUser(user);
        chatMessage.setText(text);


        chatMessage.setAttachment(createAttachment(file));

        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("INSERT INTO chat_messages(text, timestamp, chat_id, user_id, attachment_id) VALUES(?, ?, ?, ?, ?)");
            ps.setString(1, text);
            ps.setObject(2, chatMessage.getTimestamp());
            ps.setLong(3, getAuctionChat(auctionChat).getId());
            ps.setLong(4, chatMessage.getUser().getId());
            ps.setLong(5, getAttachment(chatMessage.getAttachment()).getId());

            ps.executeUpdate();

            return chatMessage;
        }
        catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    private Attachment getAttachment(Attachment attachment) {
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM attachments WHERE key=?");
            ps.setString(1, attachment.getKey());

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                attachment.setId(rs.getInt("id"));
                attachment.setKey(rs.getString("key"));
                attachment.setFileSize(rs.getDouble("file_size"));
                attachment.setFileType(rs.getString("file_type"));
                attachment.setTimestamp(rs.getObject("timestamp", LocalDate.class));
                attachment.setName(rs.getString("name"));
            }

            return attachment;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    private Attachment createAttachment(File file) throws IOException, URISyntaxException {
        String path = file.getAbsolutePath();

        String fileName = file.getName();
        int dotIndex = fileName.lastIndexOf(".");
        String nameWithoutExtension = fileName.substring(0, dotIndex);
        String extension = fileName.substring(dotIndex + 1, fileName.length() - 1);

        Attachment attachment = new Attachment();
        attachment.setFileSize((double) Math.round (file.length() / 1024 ));
        attachment.setFileType(extension);
        attachment.setName(nameWithoutExtension);
        System.out.println("Имя Файла: " + file.getName());

        UploadFile uploadFile = new UploadFile();
        uploadFile.filePath = path;
        attachment.setKey(uploadFile.putS3Object());

        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("INSERT INTO attachments(key, file_size, file_type, name) VALUES(?, ?, ?, ?)");
            ps.setString(1, attachment.getKey());
            ps.setDouble(2, attachment.getFileSize());
            ps.setString(3, attachment.getFileType());
            ps.setString(4, attachment.getName());

            System.out.println(ps.getMetaData());
            ps.executeUpdate();

            System.out.println("Прикрепленный файл: " + attachment);

            return attachment;
        }
        catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    public void setAuctionCategory(AuctionItem auctionItem, String category){
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("UPDATE auction_items SET category=(?) WHERE id=(?);");
            ps.setString(1, category);
            ps.setLong(2, auctionItem.getId());
        }
        catch (SQLException e){
            e.printStackTrace();
        }
    }

    public boolean deleteAuctionItem(AuctionItem auctionItem) {
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("delete from auction_items where id = ?");
            ps.setLong(1, auctionItem.getId());
            ps.executeUpdate();
            return true;
        }catch (SQLException e){
            e.printStackTrace();
            return false;
        }
    }

    public void updateAuctionItem(AuctionItem auctionItem) {
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("update auction_items set title = ?, description = ?, investment_size = ?, end_date = ?, location = ? where id = ?;");
            ps.setString(1, auctionItem.getTitle());
            ps.setString(2, auctionItem.getDescription());
            ps.setDouble(3, auctionItem.getInvestmentSize());
            if(auctionItem.getEndDate() != null){
                ps.setObject(4, auctionItem.getEndDate());
            }
            else{
                ps.setObject(4, this.auctionItem.getEndDate());
            }

            ps.setString(5, auctionItem.getLocation());

            ps.setLong(6, auctionItem.getId());
            ps.executeUpdate();

        }catch (SQLException e){
            e.printStackTrace();
        }
    }

    public void setAuctionItem(AuctionItem auctionItem){
        this.auctionItem = auctionItem;
    }
    private List<ChatMessage> getChatMessagesByAuctionChat(AuctionChat chat) {
        List<ChatMessage> messages = new ArrayList<>();
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM chat_messages WHERE chat_id = ?;");
            ps.setLong(1, chat.getId());
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                ChatMessage message = new ChatMessage();
                message.setId(rs.getInt("id"));
                message.setText(rs.getString("text"));
                message.setAuctionChat(getAuctionChatById(rs.getInt("chat_id")));
                message.setUser(getUserById(rs.getInt("user_id")));
                message.setAttachment(getAttachmentById(rs.getInt("attachment_id")));
                message.setTimestamp(rs.getObject("timestamp", LocalDate.class));

                messages.add(message);
            }

            return messages;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
    public List<Attachment> getAttachmentsByAuctionId(Integer id) {
        AuctionChat chat = getAuctionChatByAuctionId(id);
        System.out.println("Чат: " + chat);
        List<ChatMessage> messages = getChatMessagesByAuctionChat(chat);
        System.out.println("Сообщений: " + messages.stream().count());
        List<Attachment> attachments = new ArrayList<>();
        for (ChatMessage message : messages){
            attachments.add(message.getAttachment());
        }
        System.out.println("Вложений найдено: " + attachments.stream().count());
        return attachments;
    }
    public String getConfirmCodeAndSendToEmail(String to) throws IOException, MessagingException {
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
        String confirmCode = String.format("%06d", code);
        msg.setText(confirmCode + " - ваш код подтверждения на интернет-аукционе уникальных идей и инноваций");
        Transport.send(msg);

        return confirmCode;
    }

    public void setVerifyUser(User user, boolean isVerify) {
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("update users set is_verify = ? where id = ?;");
            ps.setBoolean(1, isVerify);
            ps.setInt(2, user.getId());

            ps.executeUpdate();

        }catch (SQLException e){
            e.printStackTrace();
        }
    }

    public List<Bid> getBidsByAuctionId(int id){
        List<Bid> bids = new ArrayList<>();

        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM bids WHERE auction_item_id=?");
            ps.setLong(1, id);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Bid bid = new Bid();
                bid.setId(rs.getInt("id"));
                bid.setAuctionItem(getAuctionItemById(rs.getInt("auction_item_id")));
                bid.setTimestamp(rs.getObject("timestamp", LocalDate.class));
                bid.setUser(getUserById(rs.getInt("user_id")));
                bid.setInvestmentVolume(rs.getDouble("investment_volume"));
                bid.setEntryPercentage(rs.getDouble("entry_percentage"));
                bids.add(bid);
            }
            return bids;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }

    public Bid getMinBidByInvestmentVolumeByAuctionItemId(int auction_id){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM bids WHERE investment_volume = (SELECT MIN(investment_volume) FROM bids) AND auction_item_id = ?;");
            ps.setInt(1, auction_id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Bid bid = new Bid();
                bid.setId(rs.getInt("id"));
                bid.setInvestmentVolume(rs.getDouble("investment_volume"));
                bid.setTimestamp(rs.getObject("timestamp", LocalDate.class));
                bid.setEntryPercentage(rs.getDouble("entry_percentage"));
                bid.setUser(getUserById(rs.getInt("user_id")));
                return bid;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public Bid getMaxBidByInvestmentVolumeByBidList(int auction_id){
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM bids WHERE investment_volume = (SELECT MAX(investment_volume) FROM bids) AND auction_item_id = ?;");
            ps.setInt(1, auction_id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Bid bid = new Bid();
                bid.setId(rs.getInt("id"));
                bid.setInvestmentVolume(rs.getDouble("investment_volume"));
                bid.setTimestamp(rs.getObject("timestamp", LocalDate.class));
                bid.setEntryPercentage(rs.getDouble("entry_percentage"));
                bid.setUser(getUserById(rs.getInt("user_id")));
                return bid;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public Bid getBestOfferByBidList(int auction_id) {
        try {
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps = con.prepareStatement("SELECT * FROM bids WHERE auction_item_id = ? ORDER BY investment_volume / entry_percentage DESC;");
            ps.setInt(1, auction_id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Bid bid = new Bid();
                bid.setId(rs.getInt("id"));
                bid.setInvestmentVolume(rs.getDouble("investment_volume"));
                bid.setTimestamp(rs.getObject("timestamp", LocalDate.class));
                bid.setEntryPercentage(rs.getDouble("entry_percentage"));
                bid.setUser(getUserById(rs.getInt("user_id")));
                return bid;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void deleteAttachment(int id) {
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection(MyTaskPrim2JavaFX.connectionString);
            PreparedStatement ps1 = con.prepareStatement("delete from chat_messages where attachment_id = ?");
            ps1.setInt(1, id);
            ps1.executeUpdate();
            PreparedStatement ps = con.prepareStatement("delete from attachments where id = ?");
            ps.setInt(1, id);
            ps.executeUpdate();
        }catch (SQLException e){
            e.printStackTrace();
        }
    }
}
