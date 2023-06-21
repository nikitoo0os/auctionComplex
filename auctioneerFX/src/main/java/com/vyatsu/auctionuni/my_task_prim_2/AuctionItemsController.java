package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.AuctionItem;
import com.vyatsu.auctionuni.my_task_prim_2.entity.User;
import com.vyatsu.auctionuni.my_task_prim_2.transfermanager.UploadFile;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.IOException;
import java.math.BigDecimal;
import java.net.URISyntaxException;
import java.net.URL;
import java.time.LocalDate;
import java.time.chrono.ChronoLocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.ResourceBundle;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class AuctionItemsController implements Initializable {

    public Button auth_button;
    public Button createItem;
    public Label username;
    public Button userProfile;
    public ComboBox categoryCB;
    public TextField volumeInvFromInput;
    public TextField titleInput;
    public TextField volumeInvToInput;
    public CheckBox isActiveAuctionInput;
    public Label filterStatus;

    @FXML
    private Label label;
    private ObservableList<AuctionItem> auctionItemsData = FXCollections.observableArrayList();

    @FXML
    private TableView<AuctionItem> tableAuctionItems;

    @FXML
    private TableColumn<AuctionItem, Integer> idCol;

    @FXML
    private TableColumn<AuctionItem, String> titleCol;

    @FXML
    private TableColumn<AuctionItem, String> descriptionCol;

    @FXML
    public TableColumn<AuctionItem, String> categoryCol;
    @FXML
    private TableColumn<AuctionItem, BigDecimal> investmentSizeCol;

    @FXML
    private TableColumn<AuctionItem, LocalDate> startDateCol;

    @FXML
    private TableColumn<AuctionItem, LocalDate> endDateCol;

    private BaseController baseController;

    private AuctionItem selectedItem;
    private User authUser;
    private boolean isEnabledEvent;
    @FXML
    private void handleButtonAction(ActionEvent event){
        initData();
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {

        baseController = new BaseController();
        setUser(baseController.getUserById(1));

        ArrayList<String> categories = (ArrayList<String>) baseController.getAllCategories()
                .stream()
                .sorted().collect(Collectors.toList());

        ObservableList<String> observableCategories = FXCollections.observableArrayList();
        observableCategories.add("");
        observableCategories.addAll(categories);

        initData();

        categoryCB.setItems(observableCategories);
    }

    private void initData(){
        if(this.authUser == null){
            tableAuctionItems.setPlaceholder(new Label("Авторизуйтесь для отображения аукционов"));
        }
        else{
            tableAuctionItems.setPlaceholder(new Label("Нет данных для отображения. Создайте свой первый аукцион!"));
            fillContent(baseController.getAuctionItemsByAuctioneer(authUser));
        }
    }
//    @FXML
//    public void handleAuthAction(ActionEvent event) throws IOException {
//        System.out.println("Открытие окна авторизации аукциониста!");
//
//        Stage stage = new Stage();
//        Scene scene = new Scene(new Group());
//        stage.setTitle("Авторизация");
//
//        Parent pane = null;
//        try {
//            FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuthView.fxml"));
//            pane = loader.load();
//            AuthController controller = loader.getController();
//            controller.setFirstPage(auth_button);
//            scene.setRoot(pane);
//        } catch (IOException e) {
//            throw new RuntimeException(e);
//        }
//        stage.setScene(scene);
//        stage.show();
//    }
    @FXML
    public void handleAuthAction(ActionEvent event) throws IOException {
        System.out.println(auth_button.getText());
        if(auth_button.getText() != "Авторизация"){

            Stage stage = (Stage) auth_button.getScene().getWindow();
            stage.close();
        }

        Stage stage = new Stage();
        Scene scene = new Scene(new Group());
        stage.setTitle("Авторизация");
        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuthView.fxml"));
            pane = loader.load();
            AuthController controller = loader.getController();
            controller.setFirstPage(auth_button);
            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();
    }
    @FXML
    private void newItemAction(ActionEvent event) throws IOException {

        Stage stage = new Stage();
        Scene scene = new Scene(new Group());
        stage.setTitle("Создание аукционного лота");
        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/NewItemView.fxml"));
            pane = loader.load();
            ManageAuctionItemController controller = loader.getController();
            controller.setUser(authUser);
            controller.setFirstButton(auth_button);
            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();

    }

    @FXML
    private void handleShowItem(ActionEvent event) throws IOException{
        Scene mainForm = baseController.changeScene("/AuctionItemView.fxml");
    }


    public void setUser(User user) {
        if(user != null){
            this.authUser = user;

            auth_button.setText("Выход");
            createItem.setDisable(false);
            userProfile.setDisable(false);
            createItem.setVisible(true);
            createItem.setDisable(true);
            username.setText("Добро пожаловать, " + user.getUsername());
            username.setLayoutX(728.0);
            username.setLayoutY(16.0);
        }

        fillContent(this.auctionItemsData);
    }
    public void fillContent(ObservableList<AuctionItem> auctionItemObservableList){
        tableAuctionItems.getItems().clear();
        if(this.authUser == null){
            this.auctionItemsData = baseController.GetAllAuctionItem();
            createItem.setDisable(true);
            createItem.setVisible(false);
            userProfile.setDisable(true);
            userProfile.setVisible(false);
        }
        else{
            if(!(auctionItemObservableList.stream().count() > 0)){
                this.auctionItemsData = baseController.GetAuctionItemByIdAuctioneer(this.authUser.getId());
            }
            userProfile.setDisable(false);
            userProfile.setVisible(true);
            createItem.setDisable(false);
        }

        idCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, Integer>("id"));
        titleCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, String>("title"));

       // ObservableList<Category> categories = baseController.getCategoryByAuctionItem(this.);

        categoryCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, String>("category"));
        investmentSizeCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, BigDecimal>("investmentSize"));
        startDateCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, LocalDate>("startDate"));
        endDateCol.setCellValueFactory(new PropertyValueFactory<AuctionItem, LocalDate>("endDate"));




        tableAuctionItems.setItems(auctionItemObservableList);
        setEventClickMouse();
    }

    private void setEventClickMouse(){
        tableAuctionItems.setOnMousePressed(mouseEvent -> {
            if (mouseEvent.isPrimaryButtonDown() && mouseEvent.getClickCount() == 2) {
                int selectedId = tableAuctionItems.getSelectionModel().getSelectedItem().getId();
                for (AuctionItem item : auctionItemsData) {
                    if (item.getId() == selectedId) {
                        selectedItem = item;

                        Stage stage = new Stage();
                        Scene scene = new Scene(new Group());
                        stage.setTitle("Управление аукционным лотом");

                        Parent pane = null;
                        try {
                            FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuctionItemView.fxml"));
                            pane = loader.load();
                            AuctionItemController controller = loader.getController();
                            controller.SetAuctionItem(selectedItem);
                            controller.setController(this);
                            scene.setRoot(pane);
                        } catch (IOException e) {
                            throw new RuntimeException(e);
                        }
                        stage.setScene(scene);
                        stage.show();
                    }
                }
            }
        });

        isEnabledEvent = true;
    }

    public void showFileChooser(ActionEvent event) throws URISyntaxException {
        Stage stage = new Stage();

        FileChooser fileChooser = new FileChooser();

        fileChooser.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("Текстовые файлы", "*.txt; *.docx; *.doc")
                ,new FileChooser.ExtensionFilter("Файлы табличного процессора", "*.xls; *.xlsx")
                ,new FileChooser.ExtensionFilter("Файлы презентации", "*.pptx")
                ,new FileChooser.ExtensionFilter("Все файлы", "*.*")
        );

        File selectedFile = fileChooser.showOpenDialog(stage);

        if(selectedFile != null){
            System.out.println("Первый путь" + selectedFile.getAbsolutePath());

//            UploadFile upload = new UploadFile(selectedFile.getAbsolutePath());
//            upload.filePath = selectedFile.getAbsolutePath();
//            upload.uploadFile(S3ClientFactory.transferManager, upload.bucketName, upload.key, upload.filePath);
//            upload.cleanUp();

            UploadFile uploadFile = new UploadFile();
            uploadFile.filePath = selectedFile.getAbsolutePath();
            uploadFile.putS3Object();
  //          System.out.println("bucket name: " + upload.bucketName + " upload key: " + selectedFile.getAbsolutePath());


        }
    }

    public void showUserProfile(ActionEvent event) {
        Stage stage = new Stage();
        Scene scene = new Scene(new Group());
        stage.setTitle("Профиль аукциониста");

        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/ProfileView.fxml"));
            pane = loader.load();
            ProfileController controller = loader.getController();
            System.out.println(authUser);
            controller.setUser(authUser);
            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();
    }


    public void filter(ActionEvent event) {
        long startTime = System.currentTimeMillis();

        ObservableList<AuctionItem> temp = auctionItemsData;
        System.out.println(auctionItemsData.stream().count());

        Predicate<AuctionItem> titleContainsSearchValue = auctionItem -> {
            String title = auctionItem.getTitle();
            return title != null && title.toLowerCase().contains(this.titleInput.getText().toLowerCase());
        };

        Double minVolInv, maxVolInv;

        if(Objects.equals(volumeInvFromInput.getText(), "")){
            volumeInvFromInput.setText("0");
        }

        if(Objects.equals(volumeInvToInput.getText(), "")){
            volumeInvToInput.setText("999999");
        }

        if(categoryCB.getValue() == null){
            categoryCB.setValue("");
        }

        minVolInv = Double.parseDouble(volumeInvFromInput.getText());
        maxVolInv = Double.parseDouble(volumeInvToInput.getText());

        System.out.println("Выбранная категория для фильтра: " + categoryCB.getValue());

        List<AuctionItem> sortedByInvVol = temp.stream()
                .filter(a -> (a.getInvestmentSize().compareTo(minVolInv) > 0) && (a.getInvestmentSize().compareTo(maxVolInv) < 0))
                .collect(Collectors.toList());

        List<AuctionItem> sortedByTitle = temp.stream()
                .filter(a -> a.getTitle().toLowerCase().contains(titleInput.getText().toLowerCase()))
                .collect(Collectors.toList());

        List<AuctionItem> sortedByCategory = temp.stream()
                .filter(a -> a.getCategory().contains(categoryCB.getValue().toString()))
                .collect(Collectors.toList());

        LocalDate currentTime = LocalDate.now();



        List<AuctionItem> intersection = new ArrayList<>(sortedByInvVol);
        intersection.retainAll(sortedByTitle);
        intersection.retainAll(sortedByCategory);

        if(isActiveAuctionInput.isSelected()){
            List<AuctionItem> activeAuctionItem = temp.stream()
                    .filter(a -> a.getEndDate().isAfter(currentTime) && currentTime.isAfter(ChronoLocalDate.from(a.getStartDate())))
                    .collect(Collectors.toList());

            intersection.retainAll(activeAuctionItem);
        }


        ObservableList<AuctionItem> filteredList = FXCollections.observableArrayList(intersection);


        fillContent(filteredList);
        if(filteredList.stream().count() > 0){
            long duration = System.currentTimeMillis() - startTime;
            filterStatus.setText("Найдено аукционов: " + filteredList.stream().count() + " за " + duration + "мс");
        }
        else{
            filterStatus.setText("Аукционы не найдены");
        }

    }


}