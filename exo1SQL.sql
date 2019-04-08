/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/
USE master
GO

CREATE DATABASE agenda
GO

USE agenda;
GO

/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	idBroker      INT IDENTITY (1,1) NOT NULL ,
	lastname      VARCHAR (50) NOT NULL ,
	firstname     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (idBroker)
);


/*------------------------------------------------------------
-- Table: customer
------------------------------------------------------------*/
CREATE TABLE customer(
	idCustomer    INT IDENTITY (1,1) NOT NULL ,
	lastname      VARCHAR (50) NOT NULL ,
	firstname     VARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL ,
	subject       TEXT  NOT NULL  ,
	CONSTRAINT customer_PK PRIMARY KEY (idCustomer)
);


/*------------------------------------------------------------
-- Table: appointment
------------------------------------------------------------*/
CREATE TABLE appointment(
	idAppointment   INT IDENTITY (1,1) NOT NULL ,
	dateHour        DATETIME  NOT NULL ,
	idBroker        INT  NOT NULL ,
	idCustomer      INT  NOT NULL  ,
	CONSTRAINT appointment_PK PRIMARY KEY (idAppointment)

	,CONSTRAINT appointment_brokers_FK FOREIGN KEY (idBroker) REFERENCES brokers(idBroker)
	,CONSTRAINT appointment_customer0_FK FOREIGN KEY (idCustomer) REFERENCES customer(idCustomer)
);



