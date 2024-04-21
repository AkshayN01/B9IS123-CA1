# Introdcution
This is a project on Hotel Management System. It is a comprehensive software solution designed to streamline and enhance the operation of hotels, from administrative tasks to front desk management, our system encompasses 3 core projects, each serving a distinct purpose.

The Admin Project serves as the backbone of the system, offering robust permission controls and a range of features to manage various aspects of the hotel’s operations. It provides administrators with the ability to oversee and regulate access to sensitive information and functionalities within the system.

However, our primary focus on the Front Desk project, which serves as the central hub for front desk operations, with this project, hotel staff can efficiently handle bookings, manage guest information and streamline the Check-In and Check-Out process.

## Pre-Requisites
- Docker and Docker Compose

## Technologies used
- .NET 8.0
- Angular 17
- MySQL
- Docker
- Docker Compose
- Identity server
- OAuth 2.0

## Instructions to run the project
- Update config.json in FrontDesk Client project present inside src/HotelManagementSystem/FrontDesk/
    - Update LoginAPIUrl and APIUrl
    - LoginAPIUrl points to admin API project
    - APIUrl points to front desk API project.
- Run docker build
    - docker-compose build --no-cache
- Run the containers
    - docker-compose up -d