create database ETSDB
create table Admin
(AdminID int,
AdminName varchar(50),
Password varchar(max))
insert into admin values(1,'King','King@123')
create table Customer
(CustomerId int identity(1,1),
Name varchar(50),
EmailId varchar(max),
PhoneNo bigint,
Address varchar(max),
AccountBalance float,
Password varchar(max))
--insert into Customer values('Vatsa','Vatsa@gmail.com',6354924783,'hyderabad',2500)
--select * from Customer
create table Vendor
(VendorId int identity(1,1) primary key,
Name varchar(50),
EmailId varchar(max),
PhoneNo bigint,
Address varchar(max),
Password varchar(max))

create table Product
(ProductId int identity(1,1),
VendorId int foreign key references vendor(vendorid),
BrandName varchar(100),
Price float,
Availability bit)

