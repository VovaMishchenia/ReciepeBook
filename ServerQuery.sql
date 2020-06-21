create table [User]
(
Id int primary key identity(1,1),
Email nvarchar(100) not null unique,
[Name] nvarchar(100) not null,
Surname nvarchar(100) not null,
PhoneNumber nvarchar(50) not null,
[Password] nvarchar(40) not null,
);

create table Friend
(
Id int primary key identity(1,1),
friend1 int foreign key references [User](Id),
friend2 int foreign key references [User](Id)
)



create table ReciepeType
(
	Id int primary key identity(1,1),
	TypeName nvarchar(50) not null unique
);

create table Cuisine
(
	Id int primary key identity(1,1),
	CuisineName nvarchar(50) not null unique
);

insert into ReciepeType values
('Перша страва'),
('Друга страва'),
('Салат'),
('Закуска'),
('Випічка'),
('Десерт'),
('Гарнір'),
('Напій')

insert into Cuisine values
('Грузинська'),
('Італійська'),
('Кавказька'),
('Китайська'),
('Німецька'),
('Українська'),
('Французька'),
('Японська')

create table Reciepe 
(
	Id int primary key identity(1,1),
	ReciepeName nvarchar(100) unique not null,
	Ingredients nvarchar(max)  not null,
	PhotoPath nvarchar(100) not null,
	Instruction nvarchar(max) not null,
	TypeId int foreign key references ReciepeType(Id),
	CuisineId int foreign key references Cuisine(Id),
	CookingTime int not null,
	Rating int check(Rating<=10),
	Calories int not null
);



create table [Message]
(
Id int primary key identity(1,1),
FromId int foreign key references [User](Id),
ToId int foreign key references [User](Id),
ReciepeId int foreign key references Reciepe(Id),
MessageString nvarchar(1000) 
);





