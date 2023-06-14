module com.vyatsu.auctionuni {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.sql;
    requires jakarta.persistence;
    requires lombok;
    requires mail;
    requires org.xerial.sqlitejdbc;
    requires software.amazon.awssdk.auth;
    requires software.amazon.awssdk.regions;
    requires software.amazon.awssdk.services.s3;
    requires software.amazon.awssdk.transfer.s3;
    requires software.amazon.awssdk.core;
    requires slf4j.api;
    requires poi;

    opens com.vyatsu.auctionuni.ex_2.model to javafx.base;
    exports com.vyatsu.auctionuni.ex_2;
    exports com.vyatsu.auctionuni.prim_2;
    opens com.vyatsu.auctionuni.prim_2 to javafx.fxml;
    exports com.vyatsu.auctionuni.hello;
    opens com.vyatsu.auctionuni.hello to javafx.fxml;


    opens com.vyatsu.auctionuni.my_task_prim_2.entity to javafx.base;
    opens com.vyatsu.auctionuni.my_task_prim_2 to javafx.fxml;
    exports com.vyatsu.auctionuni.my_task_prim_2;


//    exports com.vyatsu.auctionuni.ex_1;
//
//    opens com.vyatsu.auctionuni.ex_2 to javafx.fxml;
//    opens com.vyatsu.auctionuni.ex_2.model to javafx.base;
//    exports com.vyatsu.auctionuni.ex_2;
//    exports com.vyatsu.auctionuni.prim_2;
//    opens com.vyatsu.auctionuni.prim_2 to javafx.fxml;
//    exports com.vyatsu.auctionuni.hello;
//    opens com.vyatsu.auctionuni.hello to javafx.fxml;
//
//
//    opens com.vyatsu.auctionuni.my_task_prim_2.entity to javafx.base;
//    opens com.vyatsu.auctionuni.my_task_prim_2 to javafx.fxml;
//    exports com.vyatsu.auctionuni.my_task_prim_2;
}

