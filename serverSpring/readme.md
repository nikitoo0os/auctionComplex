# Проект Server

Это серверная часть проекта, разработанная с использованием фреймворка Spring.

## Описание проекта

Проект Server представляет собой серверное приложение, которое обрабатывает запросы от клиентов, предоставляет API и взаимодействует с базой данных.

## Установка и настройка

1. Клонируйте репозиторий проекта:

git clone https://github.com/horse18leet/auctionComplex/tree/main/serverSpring

2. Установите необходимые зависимости, выполнив следующую команду в корневом каталоге проекта:

gradle build

3. Настройте конфигурацию базы данных. Откройте файл `application.properties` и внесите необходимые изменения в настройки подключения к вашей базе данных:

spring.datasource.driver-class-name=org.postgresql.Driver
spring.datasource.url=jdbc:postgresql://localhost:5432/db_name
spring.datasource.username=*
spring.datasource.password=*

4. Запустите сервер, выполнив следующую команду:

gradle bootRun

