create database KP;
use KP;


create table Users(
	UserId int identity not null primary key,
	Secondname nvarchar(50) not null,
	Firstname nvarchar(50) not null,
	Mobile nvarchar(20) not null,
	email nvarchar(100) not null,
	password nvarchar(MAX) not null,
	Admin bit not null
)

create table Place(
	PlaceId int identity not null primary key,
	Number nvarchar(10) not null,
	Sector nvarchar(5) not null,
	Status bit not null,
	ParkingId int not null,
	cost int not null
	foreign key (PlaceId)
	references MyParking (ParkingId)
)

create table Booking(
	BookingId int identity not null primary key,
	UserID int not null,
	PlaceID int not null,
	TimeStart datetime not null,
	TimeEnd datetime
	foreign key (UserID)
	references Users (UserId),
	foreign key (PlaceID)
	references Place (PlaceId)
)

create table MyParking(
	ParkingId int identity not null primary key,
	Name nvarchar(50) not null,
)

create table Review(
	ReviewId int identity not null primary key,
	Review nvarchar(300) not null,
	TimeRev datetime not null,
	ParkingId int not null,
	UserId int not null
	foreign key (UserId)
	references Users (UserId),
	foreign key (ParkingId)
	references MyParking (ParkingId)
)

insert into Users(Secondname,Firstname,Mobile,email,password,Admin)
values ('Admin','Admin',111111111,1111,1111,'True');

insert into MyParking (Name) values ('DingoParking');

insert into Place (Number,Sector,Status,cost,ParkingId)
values ('A100','A','True',6,1),
('A101','A','True',6,1),
('A102','A','True',6,1),
('A103','A','True',6,1),
('A104','A','True',6,1),
('A105','A','True',6,1),
('A106','A','True',6,1),
('A107','A','True',6,1),
('A108','A','True',6,1),
('A109','A','True',6,1),
('B100','B','True',6,1),
('B101','B','True',6,1),
('B102','B','True',6,1),
('B103','B','True',6,1),
('B104','B','True',6,1),
('B105','B','True',6,1),
('B106','B','True',6,1),
('B107','B','True',6,1),
('B108','B','True',6,1),
('B109','B','True',6,1),
('C100','C','True',6,1),
('C101','C','True',6,1),
('C102','C','True',6,1),
('C103','C','True',6,1),
('C104','C','True',6,1),
('C105','C','True',6,1),
('C106','C','True',6,1),
('C107','C','True',6,1),
('C108','C','True',6,1),
('C109','C','True',6,1);