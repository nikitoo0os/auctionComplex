package com.vyatsu.auctionuni.prim_2;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import org.sqlite.JDBC;
import java.sql.*;
import javafx.scene.control.TableColumn;

public class FXMLDocumentController implements Initializable {

    @FXML
    private Label label;
    private ObservableList<Products> usersData = FXCollections.observableArrayList();

    @FXML
    private TableView<Products> tableUsers;

    @FXML
    private TableColumn<Products, Integer> idCol;

    @FXML
    private TableColumn<Products, String> nameCol;

    @FXML
    private TableColumn<Products, Double> cenaCol;

    @FXML
    private TableColumn<Products, String> categoryCol;

    @FXML
    private void handleButtonAction(ActionEvent event){
        System.out.println("You clicked me!");
        label.setText("Hello!");
        tableUsers.setItems(usersData);
    }

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        initData();

        idCol.setCellValueFactory(new PropertyValueFactory<Products, Integer>("id"));
        nameCol.setCellValueFactory(new PropertyValueFactory<Products, String>("good"));
        cenaCol.setCellValueFactory(new PropertyValueFactory<Products, Double>("cena"));

        categoryCol.setCellValueFactory(new PropertyValueFactory<Products, String>("category"));
    }

    private void initData(){
        try{
            DriverManager.registerDriver(new JDBC());
            Connection con = DriverManager.getConnection("jdbc:sqlite:C:/myfin.db");
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select * from products");
            while(rs.next()){
                Products pr = new Products();
                pr.setId(rs.getInt("id"));
                pr.setGood(rs.getString("good"));
                pr.setCena(rs.getDouble("price"));
                pr.setCategory(rs.getString("category_name"));

                usersData.add(pr);
            }

        }
        catch (SQLException e){
            e.printStackTrace();
        }
    }
}