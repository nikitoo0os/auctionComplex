package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.AuctionItem;
import com.vyatsu.auctionuni.my_task_prim_2.entity.User;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.ResourceBundle;
import java.util.stream.Collectors;


public class ManageAuctionItemController implements Initializable {
    public TextArea descriptionItemInput;
    public TextField titleItemInput;
    public TextField volumeInvInput;
    public DatePicker endDateItemInput;
    public Button createItem;
    public Button attach;
    public User auctioneer;

    public ObservableList<File> uploadFiles = FXCollections.observableArrayList();
    public Button cancelBtn;
    public ComboBox categoryCB;
    public Label labelFiles;
    public Label warningLabel;
    public TextField locationInput;
    public TextField searchCategoryInput;
    private Button firstBtn;
    private BaseController baseController;
    private List<String> categoryList;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
       baseController = new BaseController();

        ArrayList<String> categories = (ArrayList<String>) baseController.getAllCategories()
                .stream()
                .collect(Collectors.toList());

        ObservableList<String> observableCategories = FXCollections.observableArrayList();
        observableCategories.addAll(categories);
        categoryCB.setItems(observableCategories);


        searchCategoryInput.textProperty().addListener((observable, oldValue, newValue) -> {
            categoryCB.getItems().clear();
            for (String item : observableCategories) {
                if (item.toLowerCase().contains(newValue.toLowerCase())) {
                    categoryCB.getItems().add(item);
                }
            }
            categoryCB.hide(); // Скрытие всплывающего списка после фильтрации
            if (!newValue.isEmpty()) {
                categoryCB.show(); // Показ всплывающего списка при наличии фильтрованных результатов
            }
        });
    }


    public void authButton(ActionEvent actionEvent) throws IOException {
        AuctionItemsController auctionItemsController = new AuctionItemsController();
        auctionItemsController.handleAuthAction(actionEvent);
    }

    public void attachStep(ActionEvent event) {
        AuctionItem auctionItem = new AuctionItem();
        auctionItem.setTitle(titleItemInput.getText());
        auctionItem.setDescription(descriptionItemInput.getText());
        auctionItem.setInvestmentSize(Double.parseDouble(volumeInvInput.getText()));
        auctionItem.setAuctioneer(auctioneer);
        auctionItem.setEndDate(endDateItemInput.getValue());
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
            labelFiles.setText(labelFiles.getText() + selectedFile);
        }
    }

    public void createAuctionItem(ActionEvent event) throws URISyntaxException, IOException {


        boolean isTitle = !Objects.equals(titleItemInput.getText(), "");
        boolean isDescription = !Objects.equals(descriptionItemInput.getText(), "");
        boolean isVolumeInv = !Objects.equals(volumeInvInput.getText(), "");
        boolean isEndDate = endDateItemInput != null;
        boolean isCategory = !Objects.equals(searchCategoryInput.getText(), "");

        if(!(isTitle & isDescription & isVolumeInv & isEndDate & isCategory)){
            warningLabel.setText("Проверьте введённые поля!");
            warningLabel.setDisable(false);
            warningLabel.setVisible(true);

            return;
        }

        AuctionItem auctionItem = new AuctionItem(
                titleItemInput.getText(),
                descriptionItemInput.getText(),
                Double.parseDouble(volumeInvInput.getText()),
                LocalDate.now(),
                endDateItemInput.getValue(),
                auctioneer,
                locationInput.getText());

        baseController.createAuctionItem(auctionItem, searchCategoryInput.getText());

        AuctionItem auctionItem1 = baseController.getAuctionItem(auctionItem, auctioneer.getId());

        for(File file : uploadFiles){
            baseController.createChatMessage(baseController.createAuctionChat(auctionItem1), auctioneer, "", file);
            System.out.println("Файл " + file + "загружен!");
        }

        Stage stage = new Stage();
        Scene scene = new Scene(new Group());
        stage.setTitle("Мои аукционные лоты");

        Stage stage1 = (Stage)firstBtn.getScene().getWindow();
        stage1.close();

        Parent pane = null;
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/AuctionItemsView.fxml"));
            pane = loader.load();
            AuctionItemsController controller = loader.getController();
            controller.setUser(auctioneer);
            scene.setRoot(pane);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
        stage.setScene(scene);
        stage.show();

    }

    public void cancelButton(ActionEvent actionEvent) {
        Stage stage = (Stage) cancelBtn.getScene().getWindow();
        stage.close();
    }

    public void setUser(User authUser) {
        this.auctioneer = authUser;
    }

    public void setFirstButton(Button auth_button) {
        this.firstBtn = auth_button;
    }


//    public void uploadFile(){
//        String accessKey = "k9kAQuz85u8MaLWgTBVnC";
//        String secretKey = "9ABigRK5bo85e8zzt1aXkMbfdfJbada9Ta4qX1eDq3nk";
//        String endPoint = "hb.bizmrg.com";
//        String region = "ru-msk";
//
//        BasicAWSCredentials credentials = new BasicAWSCredentials(accessKey, secretKey);
//
//        AmazonS3 s3Client = AmazonS3ClientBuilder.standard()
//                .withCredentials(new AWSStaticCredentialsProvider(credentials))
//                .withEndpointConfiguration(new AwsClientBuilder.EndpointConfiguration(endPoint, region))
//                .build();
//
//        System.out.println(s3Client);
//    }
//
//    public static Bucket getBucket(String bucket_name) {
//        final AmazonS3 s3 = AmazonS3ClientBuilder.standard().withRegion(Regions.DEFAULT_REGION).build();
//        Bucket named_bucket = null;
//        List<Bucket> buckets = s3.listBuckets();
//        for (Bucket b : buckets) {
//            if (b.getName().equals(bucket_name)) {
//                named_bucket = b;
//            }
//        }
//        return named_bucket;
//    }

}
