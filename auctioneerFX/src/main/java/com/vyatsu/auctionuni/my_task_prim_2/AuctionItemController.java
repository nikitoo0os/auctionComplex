package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.ResourceBundle;
import java.util.stream.Collectors;

public class AuctionItemController implements Initializable {

    public Label idItem;
    public TextField volumeInvestment;
    public ComboBox category;
    public DatePicker endDate;
    public TextField title;
    public TextArea description;
    public TextField location;
    public Button deleteBtn;
    public Label status;
    public TableView tableAttachments;
    public Button deleteFileBtn;
    private AuctionItem auctionItem;
    private BaseController baseController;
    private ObservableList<String> categoryList;
    private AuctionItemsController auctionItemsController;
    public ObservableList<File> uploadFiles = FXCollections.observableArrayList();

    @FXML
    private TableColumn<Attachment, Integer> idCol;
    @FXML
    private TableColumn<Attachment, String> nameCol;
    @FXML
    private TableColumn<Attachment, String> keyCol;

    @FXML
    private TableColumn<Attachment, Integer> sizeCol;
    @FXML
    private TableColumn<Attachment, String> typeCol;

    @FXML
    private TableColumn<Attachment, LocalDate> timestampCol;




    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        baseController = new BaseController();

        ArrayList<String> categories = (ArrayList<String>) baseController.getAllCategories()
                .stream()
                .collect(Collectors.toList());

        ObservableList<String> observableCategories = FXCollections.observableArrayList();
        observableCategories.addAll(categories);

        category.setItems(observableCategories);

        status.setVisible(false);
        status.setDisable(true);

        this.auctionItem = baseController.getAuctionItemById(Integer.parseInt(this.idItem.getText().substring(5)));

        deleteFileBtn.disableProperty().bind(tableAttachments.getSelectionModel().selectedItemProperty().isNull());

        deleteFileBtn.setOnAction(event -> {
            Attachment selectedAttachment = (Attachment) tableAttachments.getSelectionModel().getSelectedItem();
            if (selectedAttachment != null) {
                baseController.deleteAttachment(selectedAttachment.getId());
                SetAuctionItem(this.auctionItem);
            }
        });
    }

    public void SetAuctionItem(AuctionItem auctionItem){
        this.auctionItem = auctionItem;

        title.setText(auctionItem.getTitle());
        idItem.setText("Лот №" + auctionItem.getId().toString());
        volumeInvestment.setText(auctionItem.getInvestmentSize().toString());
        description.setText(auctionItem.getDescription().toString());
        location.setText(auctionItem.getLocation());
        category.setValue(this.auctionItem.getCategory());
        System.out.println(auctionItem);

        List<Attachment> attachments = baseController.getAttachmentsByAuctionId(this.auctionItem.getId());
        ObservableList<Attachment> attachmentList = FXCollections.observableArrayList(attachments);
        tableAttachments.setItems(attachmentList);

        System.out.println("ВЫВОДДДДДДД");
        idCol.setCellValueFactory(new PropertyValueFactory<Attachment, Integer>("id"));
        keyCol.setCellValueFactory(new PropertyValueFactory<Attachment, String>("key"));
        sizeCol.setCellValueFactory(new PropertyValueFactory<Attachment, Integer>("fileSize"));
        typeCol.setCellValueFactory(new PropertyValueFactory<Attachment, String>("fileType"));
        timestampCol.setCellValueFactory(new PropertyValueFactory<Attachment, LocalDate>("timestamp"));
        nameCol.setCellValueFactory(new PropertyValueFactory<Attachment, String>("name"));
    }

    public void deleteAuctionItem(ActionEvent actionEvent) {
        boolean isDeleted = baseController.deleteAuctionItem(this.auctionItem);
        Stage stage = (Stage) deleteBtn.getScene().getWindow();
        stage.close();

        this.auctionItemsController.fillContent(FXCollections.observableArrayList());
    }

    public void setController(AuctionItemsController aClass) {
        this.auctionItemsController = aClass;
    }


    public void updateAuctionItem(ActionEvent actionEvent) {

        AuctionItem updatedAuctionItem = new AuctionItem(
                this.auctionItem.getId(),
                title.getText(),
                description.getText(),
                Double.parseDouble(volumeInvestment.getText()),
                this.auctionItem.getStartDate(),
                endDate.getValue(),
                this.auctionItem.getAuctioneer(),
                location.getText(),
                category.getValue().toString()
        );

        System.out.println("Обновл аук локац: " + this.auctionItem.getLocation());

        baseController.setAuctionItem(this.auctionItem);
        baseController.updateAuctionItem(updatedAuctionItem);

        status.setVisible(true);
        status.setDisable(false);
    }

    public void createAuctionList(ActionEvent event) {
        List<Bid> bids = baseController.getBidsByAuctionId(this.auctionItem.getId());
        Bid minBid = baseController.getMinBidByInvestmentVolumeByAuctionItemId(this.auctionItem.getId());
        Bid maxBid = baseController.getMaxBidByInvestmentVolumeByBidList(this.auctionItem.getId());
        Bid bestOfferBid = baseController.getBestOfferByBidList(this.auctionItem.getId());
        AuctionListExporter.exportToXLS(bids, this.auctionItem, minBid, maxBid, bestOfferBid);
    }

    public void addAttachment(ActionEvent event) throws URISyntaxException, IOException {
        showFileChooser(event);
        AuctionChat auctionChat = baseController.getAuctionChatByAuctionId(auctionItem.getId());
        User auctioneer = auctionItem.getAuctioneer();
        for(File file : uploadFiles){
            baseController.createChatMessage(auctionChat, auctioneer, "", file);
        }

        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Подсказка");
        alert.setHeaderText("Успешно!");
        alert.setContentText("Файл добавлен!");
        alert.showAndWait();
    }

    public void showFileChooser(ActionEvent event) {
        Stage stage = new Stage();

        FileChooser fileChooser = new FileChooser();

        fileChooser.getExtensionFilters().addAll(
                new FileChooser.ExtensionFilter("Текстовые файлы", "*.txt; *.docx; *.doc")
                ,new FileChooser.ExtensionFilter("Файлы табличного процессора", "*.xls; *.xlsx")
                ,new FileChooser.ExtensionFilter("Файлы презентации", "*.pptx")
                ,new FileChooser.ExtensionFilter("Все файлы", "*.*")
        );

        File selectedFile = fileChooser.showOpenDialog(stage);
        if(!uploadFiles.contains(selectedFile) & selectedFile != null){
            uploadFiles.add(selectedFile);
        }
    }
}
