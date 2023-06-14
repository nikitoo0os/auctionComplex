package com.vyatsu.auctionuni.my_task_prim_2;

import com.vyatsu.auctionuni.my_task_prim_2.entity.AuctionItem;
import com.vyatsu.auctionuni.my_task_prim_2.entity.Bid;
import javafx.scene.control.Alert;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.*;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.time.format.DateTimeFormatter;
import java.util.List;

public class AuctionListExporter {
    public static void exportToXLS(List<Bid> bids, AuctionItem auctionItem, Bid minBid, Bid maxBid, Bid bestOffer) {

        Stage stage = new Stage();
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Save File");
        File file = fileChooser.showSaveDialog(stage);
        if (file != null) {
            try (Workbook workbook = new HSSFWorkbook();
                 FileOutputStream fileOutputStream = new FileOutputStream(file)) {

                Sheet sheet = workbook.createSheet("Аукционный лист №" + auctionItem.getId());

                Row headerRow = sheet.createRow(0);
                headerRow.createCell(0).setCellValue("№");
                headerRow.createCell(1).setCellValue("Объем инвестиций(TON)");
                headerRow.createCell(2).setCellValue("Процент входа");
                headerRow.createCell(3).setCellValue("Время");
                headerRow.createCell(4).setCellValue("№ пользователя");

                int rowNum = 1;
                DateTimeFormatter dateTimeFormatter = DateTimeFormatter.ISO_LOCAL_DATE_TIME;
                for (Bid bid : bids) {
                    Row dataRow = sheet.createRow(rowNum++);
                    dataRow.createCell(0).setCellValue(bid.getId());
                    dataRow.createCell(1).setCellValue(bid.getInvestmentVolume());
                    dataRow.createCell(2).setCellValue(bid.getEntryPercentage());
                    dataRow.createCell(3).setCellValue(bid.getTimestamp());
                    dataRow.createCell(4).setCellValue(bid.getUser().getId());
                }

                if (auctionItem != null) {
                    Row auctionInfoRow = sheet.createRow(rowNum++);
                    auctionInfoRow.createCell(0).setCellValue("Название аукциона");
                    auctionInfoRow.createCell(1).setCellValue(auctionItem.getTitle());
                    Row auctionIdRow = sheet.createRow(rowNum++);
                    auctionIdRow.createCell(0).setCellValue("Идентификатор аукциона");
                    auctionIdRow.createCell(1).setCellValue("№" + auctionItem.getId());
                }
                if (bestOffer != null) {
                    Row bestOfferRow = sheet.createRow(rowNum++);
                    bestOfferRow.createCell(0).setCellValue("Наиболее выгодное предложение");
                    bestOfferRow.createCell(4).setCellValue(bestOffer.getEntryPercentage() + "% вход в капитал компании при обьеме инвестирования: " + bestOffer.getInvestmentVolume() + " TON" + " Пользователя №" + minBid.getUser().getId() + " " + minBid.getUser().getFirstName());
                }
                if (minBid != null) {
                    Row minBidRow = sheet.createRow(rowNum++);
                    minBidRow.createCell(0).setCellValue("Минимальная ставка");
                    minBidRow.createCell(4).setCellValue(minBid.getEntryPercentage() + "% вход в капитал компании при обьеме инвестирования: " + minBid.getInvestmentVolume() + " TON" + " Пользователя №" + minBid.getUser().getId() + " " + minBid.getUser().getFirstName());
                }
                if (maxBid != null) {
                    Row maxBidRow = sheet.createRow(rowNum++);
                    maxBidRow.createCell(0).setCellValue("Максимальная ставка");
                    maxBidRow.createCell(4).setCellValue(maxBid.getEntryPercentage() + "% вход в капитал компании при обьеме инвестирования: " + maxBid.getInvestmentVolume() + " TON" + " Пользователя №" + minBid.getUser().getId() + " " + minBid.getUser().getFirstName());
                }

                workbook.write(fileOutputStream);
            } catch (IOException e) {
                e.printStackTrace();
            }
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Подсказка");
            alert.setHeaderText("Успешно!");
            alert.setContentText("Аукционный лист сохранен!");
            alert.showAndWait();
        }
    }

}
