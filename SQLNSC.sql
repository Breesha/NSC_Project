USE NSC;

DROP TABLE Bookings;
DROP TABLE Sports;
DROP TABLE Rooms;
DROP TABLE Staff;
DROP TABLE Members;

CREATE TABLE Members
(
MemberID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
Username VARCHAR(30) NOT NULL,
Passwrd VARCHAR(30) NOT NULL
);

CREATE TABLE Staff
(
StaffID INT NOT NULL PRIMARY KEY,
StaffName VARCHAR(30) NOT NULL
);

CREATE TABLE Rooms
(
RoomID INT NOT NULL PRIMARY KEY,
RoomName VARCHAR(30) NOT NULL
);

CREATE TABLE Sports
(
SportID INT NOT NULL PRIMARY KEY,
SportName VARCHAR(30) NOT NULL,
StaffID INT,
FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

CREATE TABLE Bookings
(
BookingID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
MemberID INT,
FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
RoomID INT,
FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
SportID INT,
FOREIGN KEY (SportID) REFERENCES Sports(SportID),
DateNeeded DATE NOT NULL,
TimeSlot TIME NOT NULL
);

INSERT INTO [Members]
([Username]
,[Passwrd])
VALUES
('bfoxton'
,'password')
;

INSERT INTO [Staff]
([StaffID]
,[StaffName])
VALUES
(1
,'Tom Burrows')
;

INSERT INTO [Staff]
([StaffID]
,[StaffName])
VALUES
(2
,'Joe Burrows')
;

INSERT INTO [Staff]
([StaffID]
,[StaffName])
VALUES
(3
,'George Burrows')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(1
,'Diving Pool')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(2
,'Lane Pool')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(3
,'Sports Hall 1')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(4
,'Sports Hall 2')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(5
,'Squash 1')
;

INSERT INTO [Rooms]
([RoomID]
,[RoomName])
VALUES
(6
,'Squash 2')
;

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(1,'Platform Diving',1);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(2,'Springboard Diving',1);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(3,'Lane Swimming',2);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(4,'Aquaerobics',2);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(5,'Child Swim Lessons',2);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(6,'Adult Swim Lessons',2);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(7,'Indoor Hockey',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(8,'Indoor Football',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(9,'Table Tennis',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(10,'Badminton',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(11,'Wheelchair Basketball',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(12,'Basketball',3);

INSERT INTO [Sports]
([SportID]
,[SportName]
,[StaffID])
VALUES
(13,'Squash',3);