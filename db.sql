create database employee_crm;
use employee_crm;

CREATE TABLE vehicles (
    ID int NOT NULL,
    vehicleNo varchar(255) NOT NULL,
    status tinyint default 0,
    AddedDate datetime default current_timestamp,
    PRIMARY KEY (ID)
);