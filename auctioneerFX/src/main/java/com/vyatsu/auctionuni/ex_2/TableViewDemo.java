package com.vyatsu.auctionuni.ex_2;

import com.vyatsu.auctionuni.ex_2.model.UserAccount;
import javafx.application.Application;


import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;


public class TableViewDemo extends Application {
    @Override
    public void start(Stage stage) {

        TableView<UserAccount> table = new TableView<UserAccount>();

        // Create column UserName (Data type of String).
        TableColumn<UserAccount, String> userNameCol //
                = new TableColumn<UserAccount, String>("User Name");

        // Create column Email (Data type of String).
        TableColumn<UserAccount, String> emailCol//
                = new TableColumn<UserAccount, String>("Email");

        // Create column FullName (Data type of String).
        TableColumn<UserAccount, String> fullNameCol//
                = new TableColumn<UserAccount, String>("Full Name");

        // Create 2 sub column for FullName.
        TableColumn<UserAccount, String> firstNameCol //
                = new TableColumn<UserAccount, String>("First Name");

        TableColumn<UserAccount, String> lastNameCol //
                = new TableColumn<UserAccount, String>("Last Name");

        // Add sub columns to the FullName
        fullNameCol.getColumns().addAll(firstNameCol, lastNameCol);

        // Active Column
        TableColumn<UserAccount, Boolean> activeCol//
                = new TableColumn<UserAccount, Boolean>("Active");

        table.getColumns().addAll(userNameCol, emailCol, fullNameCol, activeCol);

        StackPane root = new StackPane();
        root.setPadding(new Insets(5));
        root.getChildren().add(table);

        stage.setTitle("TableView (o7planning.org)");

        Scene scene = new Scene(root, 450, 300);
        stage.setScene(scene);
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }

}
