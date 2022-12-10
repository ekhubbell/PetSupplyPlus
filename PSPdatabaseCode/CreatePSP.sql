drop database petsupplyplus;
create database petsupplyplus;
use petsupplyplus;

create table customer (
cust_id int,
firstName varchar(30),
lastName varchar(30),
address varchar(50),
city varchar(50),
state_ID int, 
zipcode int, 
email varchar(50),
phone varchar(10), 
PRIMARY KEY (cust_id),
check(phone regexp '[:digit:]' = 1 AND length(phone)=10)
);

create table C_Username(
user_id int,
username varchar(60),
password varchar(60));

create table E_Username(
user_id varchar(5),
username varchar(60),
password varchar(60));

create table employee (
employee_id varchar(5),
firstName varchar(30),
lastName varchar(30),
email varchar(40),
phone varchar(10),
primary key (employee_id),
check(phone regexp '[:digit:]' = 1 AND length(phone)=10));

create table Items (
itemId int,
item_name varchar(30),
description varchar(100),
Price double,
Quantity int,
Pettype int,
PRIMARY KEY (itemID)
);

create table historicalItems
(
itemId int,
item_name varchar(30),
description varchar(100),
Price double,
Quantity int,
Pettype int,
removedOn datetime,
PRIMARY KEY (itemID)
);

create table ordercontent(
orderID int,
itemID int,
quantity int,
price double,
PRIMARY KEY (orderID, itemID)
);

create table orders (
orderID int,
Cust_id int,
EmployeeID char(3),
EmployeeAction varchar(20),
Paid varchar(10),
Status varchar(20)
);

create table petTypes(
type_ID int,
typeName varchar(20),
primary key(type_ID));

create table states(
state_id int,
state_name varchar(20),
state_abbr varchar(2),
tax double,
primary key (state_id)
);

