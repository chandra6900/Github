--create table tmphello(
--Id int not null Identity(1,1),
--BankName varchar(20) not null,
--City varchar(10)  not null,
--Address varchar(20) not null)

CREATE TABLE [dbo].[tmphello] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [BankName] VARCHAR (20) NOT NULL,
    [City]     VARCHAR (10) NOT NULL,
    [Address]  VARCHAR (20) NOT NULL,
	primary key (Id)
);
--Drop table tmphello;

