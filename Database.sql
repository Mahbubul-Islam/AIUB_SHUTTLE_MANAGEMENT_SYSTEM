-- Create database
CREATE DATABASE AIUB_SHUTTLE_MANAGEMENT_SYSTEM;
USE AIUB_SHUTTLE_MANAGEMENT_SYSTEM;
 
-- Create User table
CREATE TABLE Users (
    UserID VARCHAR(50) PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    Password VARCHAR(100),
    Role VARCHAR(50),
	Gender VARCHAR(10),
    Nationality VARCHAR(50),
    BloodGroup VARCHAR(10),
    Address VARCHAR(255),
    Dob DATE,
    PhoneNumber VARCHAR(20)
);
 
 
-- Create Shuttles table
CREATE TABLE Shuttles (
    ShuttleName VARCHAR(50) PRIMARY KEY,
    Route VARCHAR(100),
    Capacity INT,
    Time TIME
);
 
-- Create Booking table
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY,
    ShuttleName VARCHAR(50),
    UserID VARCHAR(50),
    BookingSeatNumber VARCHAR(50),
    BookingStatus VARCHAR(50),
    BookedTime DATETIME,
    FOREIGN KEY (ShuttleName) REFERENCES Shuttles(ShuttleName) ON DELETE CASCADE,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);
 
-- Create Notifications table
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY , 
    Message TEXT,
    UserID VARCHAR(50),
    Date DATETIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- end
-- Insert a user with username 'admin' and password 'admin'
INSERT INTO Users (UserID, Name, Email, Password, Role, Gender, Nationality, BloodGroup,Address, Dob, PhoneNumber)
VALUES ('admin', 'Admin', 'admin@example.com', 'admin', 'Admin', 'Male', 'Bangladeshi', 'O+', 'Dhaka','2002-05-10','01774593370');
 
INSERT INTO Users (UserID, Name, Email, Password, Role) VALUES ('22-5455-2', 'Ujbuk', 'ujbuk@gmail', 'ujbuk', 'Faculty')

SELECT COUNT(*) FROM Users WHERE UserID COLLATE SQL_Latin1_General_CP1_CS_AS ='22-54555-2'  AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = 'ujbuk'

ALTER TABLE Users
ADD Gender VARCHAR(10),
    Nationality VARCHAR(50),
    BloodGroup VARCHAR(10),
    Address VARCHAR(255),
    Dob DATE,
    PhoneNumber VARCHAR(20);



	INSERT INTO Users (UserID, Name, Email, Password, Role, Gender, Nationality, BloodGroup, Address, Dob, PhoneNumber)
VALUES 
('U001', 'John Doe', 'john@example.com', 'password123', 'Passenger', 'Male', 'American', 'O+', '123 Street, NY', '1990-05-14', '1234567890'),
('U002', 'Jane Smith', 'jane@example.com', 'securePass', 'Driver', 'Female', 'British', 'A-', '456 Avenue, LA', '1985-10-22', '0987654321'),
('U003', 'Alice Brown', 'alice@example.com', 'alicePass', 'Admin', 'Female', 'Canadian', 'B+', '789 Road, TX', '1992-07-30', '1122334455');


INSERT INTO Shuttles (ShuttleName, Route, Capacity, Time)
VALUES 
('Shuttle_A', 'NY to LA', 50, '08:00:00'),
('Shuttle_B', 'LA to TX', 40, '12:00:00'),
('Shuttle_C', 'TX to NY', 35, '18:30:00');

INSERT INTO Booking (BookingID, ShuttleName, UserID, BookingSeatNumber, BookingStatus, BookedTime)
VALUES 
(1, 'Shuttle_A', 'U001', 12, 'Confirmed', '2024-02-01 10:15:00'),
(2, 'Shuttle_B', 'U002', 5, 'Pending', '2024-02-01 12:30:00'),
(3, 'Shuttle_C', 'U003', 20, 'Cancelled', '2024-02-01 15:45:00');

DELETE FROM Booking WHERE BookingID = 901694;

INSERT INTO Notifications (NotificationID, Message, UserID, Date)
VALUES (1, 'Booking confirmed', 'user123', '2025-02-03');
