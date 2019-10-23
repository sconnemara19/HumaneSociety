CREATE TABLE Employees (EmployeeId INTEGER IDENTITY (1,1) PRIMARY KEY, FirstName VARCHAR(50), LastName VARCHAR(50), UserName VARCHAR(50), Password VARCHAR(50), EmployeeNumber INTEGER, Email VARCHAR(50));
CREATE TABLE Categories (CategoryId INTEGER IDENTITY (1,1) PRIMARY KEY, Name VARCHAR(50));
CREATE TABLE DietPlans(DietPlanId INTEGER IDENTITY (1,1) PRIMARY KEY, Name VARCHAR(50), FoodType VARCHAR(50), FoodAmountInCups INTEGER);
CREATE TABLE Animals (AnimalId INTEGER IDENTITY (1,1) PRIMARY KEY, Name VARCHAR(50), Weight INTEGER, Age INTEGER, Demeanor VARCHAR(50), KidFriendly BIT, PetFriendly BIT, Gender VARCHAR(50), AdoptionStatus VARCHAR(50), CategoryId INTEGER FOREIGN KEY REFERENCES Categories(CategoryId), DietPlanId INTEGER FOREIGN KEY REFERENCES DietPlans(DietPlanId), EmployeeId INTEGER FOREIGN KEY REFERENCES Employees(EmployeeId));
CREATE TABLE Rooms (RoomId INTEGER IDENTITY (1,1) PRIMARY KEY, RoomNumber INTEGER, AnimalId INTEGER FOREIGN KEY REFERENCES Animals(AnimalId));
CREATE TABLE Shots (ShotId INTEGER IDENTITY (1,1) PRIMARY KEY, Name VARCHAR(50));
CREATE TABLE AnimalShots (AnimalId INTEGER FOREIGN KEY REFERENCES Animals(AnimalId), ShotId INTEGER FOREIGN KEY REFERENCES Shots(ShotId), DateReceived DATE, CONSTRAINT AnimalShotId PRIMARY KEY (AnimalId, ShotId));
CREATE TABLE USStates (USStateId INTEGER IDENTITY (1,1) PRIMARY KEY, Name VARCHAR(50), Abbreviation VARCHAR(2));
CREATE TABLE Addresses (AddressId INTEGER IDENTITY (1,1) PRIMARY KEY, AddressLine1 VARCHAR(50), City VARCHAR(50), USStateId INTEGER FOREIGN KEY REFERENCES USStates(USStateId),  Zipcode INTEGER); 
CREATE TABLE Clients (ClientId INTEGER IDENTITY (1,1) PRIMARY KEY, FirstName VARCHAR(50), LastName VARCHAR(50), UserName VARCHAR(50), Password VARCHAR(50), AddressId INTEGER FOREIGN KEY REFERENCES Addresses(AddressId), Email VARCHAR(50));
CREATE TABLE Adoptions(ClientId INTEGER FOREIGN KEY REFERENCES Clients(ClientId), AnimalId INTEGER FOREIGN KEY REFERENCES Animals(AnimalId), ApprovalStatus VARCHAR(50), AdoptionFee INTEGER, PaymentCollected BIT, CONSTRAINT AdoptionId PRIMARY KEY (ClientId, AnimalId));

INSERT INTO USStates VALUES('Alabama','AL');
INSERT INTO USStates VALUES('Alaska','AK');
INSERT INTO USStates VALUES('Arizona','AZ');
INSERT INTO USStates VALUES('Arkansas','AR');
INSERT INTO USStates VALUES('California','CA');
INSERT INTO USStates VALUES('Colorado','CO');
INSERT INTO USStates VALUES('Connecticut','CT');
INSERT INTO USStates VALUES('Delaware','DE');
INSERT INTO USStates VALUES('Florida','FL');
INSERT INTO USStates VALUES('Georgia','GA');
INSERT INTO USStates VALUES('Hawaii','HI');
INSERT INTO USStates VALUES('Idaho','ID');
INSERT INTO USStates VALUES('Illinois','IL');
INSERT INTO USStates VALUES('Indiana','IN');
INSERT INTO USStates VALUES('Iowa','IA');
INSERT INTO USStates VALUES('Kansas','KS');
INSERT INTO USStates VALUES('Kentucky','KY');
INSERT INTO USStates VALUES('Louisiana','LA');
INSERT INTO USStates VALUES('Maine','ME');
INSERT INTO USStates VALUES('Maryland','MD');
INSERT INTO USStates VALUES('Massachusetts','MA');
INSERT INTO USStates VALUES('Michigan','MI');
INSERT INTO USStates VALUES('Minnesota','MN');
INSERT INTO USStates VALUES('Mississippi','MS');
INSERT INTO USStates VALUES('Missouri','MO');
INSERT INTO USStates VALUES('Montana','MT');
INSERT INTO USStates VALUES('Nebraska','NE');
INSERT INTO USStates VALUES('Nevada','NV');
INSERT INTO USStates VALUES('New Hampshire','NH');
INSERT INTO USStates VALUES('New Jersey','NJ');
INSERT INTO USStates VALUES('New Mexico','NM');
INSERT INTO USStates VALUES('New York','NY');
INSERT INTO USStates VALUES('North Carolina','NC');
INSERT INTO USStates VALUES('North Dakota','ND');
INSERT INTO USStates VALUES('Ohio','OH');
INSERT INTO USStates VALUES('Oklahoma','OK');
INSERT INTO USStates VALUES('Oregon','OR');
INSERT INTO USStates VALUES('Pennsylvania','PA');
INSERT INTO USStates VALUES('Rhode Island','RI');
INSERT INTO USStates VALUES('South Carolina','SC');
INSERT INTO USStates VALUES('South Dakota','SD');
INSERT INTO USStates VALUES('Tennessee','TN');
INSERT INTO USStates VALUES('Texas','TX');
INSERT INTO USStates VALUES('Utah','UT');
INSERT INTO USStates VALUES('Vermont','VT');
INSERT INTO USStates VALUES('Virginia','VA');
INSERT INTO USStates VALUES('Washington','WA');
INSERT INTO USStates VALUES('West Virgina','WV');
INSERT INTO USStates VALUES('Wisconsin','WI');
INSERT INTO USStates VALUES('Wyoming','WY');

INSERT INTO Categories VALUES ('Dog')
INSERT INTO Categories VALUES ('Cat')
INSERT INTO Categories VALUES ('Chicken')
INSERT INTO Categories VALUES ('Rabbit')
INSERT INTO Categories VALUES ('Dragon')

INSERT INTO DietPlans VALUES ('Pescatarian', 'Tuna', 2)
INSERT INTO DietPlans VALUES ('DogFood', 'Beef', 3)
INSERT INTO DietPlans VALUES ('Vegetarian', 'Corn', 2)
INSERT INTO DietPlans VALUES ('Vegan', 'Carrots', 2)
INSERT INTO DietPlans VALUES ('Carnivore', 'Deer', 10)

INSERT INTO Employees VALUES ('Billy', 'Bob', 'billybob', 'abcde', 1, 'billybob@aol.com')
INSERT INTO Employees VALUES ('Gary', 'Henderson', 'garyhenderson', 'abc123', 2, 'gmonthehenderson@gmail.com')
INSERT INTO Employees VALUES ('Michael', 'Scott', 'mscott', 'fun123', 3, 'mscott@yahoo.com')
INSERT INTO Employees VALUES ('Laura', 'Raider', 'lauraraider', 'fghijk', 4, 'missraider@comcast.net')
INSERT INTO Employees VALUES ('Leslie', 'Knope', 'LKnope', 'Parks456', 5, 'Parksarethebest@gmail.com')

INSERT INTO Animals VALUES('Scrambles', 680, 150, 'Cuddly', 1, 0, 'Male', 'Available', 5, 5, 3)
INSERT INTO Animals VALUES('Ghost' , 80, 3, 'Loyal', 1, 1, 'Male', 'Taken', 1,2,5)
INSERT INTO Animals VALUES('Pancake', 15, 3, 'Aloof', 0, 0, 'Female', 'Available', 2, 1, 2)
INSERT INTO Animals VALUES('Popeye', 5, 2, 'Angry', 0, 1, 'Male', 'Available', 3, 3, 4)
INSERT INTO Animals VALUES('Patrice', 3, 4, 'Fast' , 1,1, 'Female', 'Available',  4, 4, 1)

INSERT INTO Rooms VALUES(1, 1)
INSERT INTO Rooms VALUES(2, 1)
INSERT INTO Rooms VALUES(3, 1)
INSERT INTO Rooms VALUES(4, 1)
INSERT INTO Rooms VALUES(5, 2)
INSERT INTO Rooms VALUES(6, 2)
INSERT INTO Rooms VALUES(7, 3)
INSERT INTO Rooms VALUES(8, 3)
INSERT INTO Rooms VALUES(9, 4)
INSERT INTO Rooms VALUES(10, 5)

INSERT INTO Addresses VALUES('806 W Glen Oaks Ln', 'Mequon', 49, 53092)
INSERT INTO Addresses VALUES ('3304 N Fratney St', 'Milwaukee', 49, 53212)
INSERT INTO Addresses VALUES('1024 Lakefield Rd. Apt 1', 'Grafton', 49, 53024)
INSERT INTO Addresses VALUES('1407 15th St', 'Silvis', 13, 61282)
INSERT INTO Addresses VALUES ('N123W234 Concord Ave', 'Minneapolis', 23, 55111)

INSERT INTO Clients VALUES('Ben', 'Wyatt', 'bigben', 'gameofthronesfan', 1, 'bigben@hotmail.com')
INSERT INTO Clients VALUES ('Dwight', 'Schrute', 'BeetFarmer', 'battlestar galactica', 2, 'SchruteFarms2@yahoo.com')
INSERT INTO Clients VALUES('Frank', 'Reynolds', 'warthog', 'password1234', 3, 'hogman64@gmail.com')
INSERT INTO Clients VALUES ('Tom', 'Haverford', 'swaggytom', 'treatyoself', 4, 'chickychickyparmparm@gmail.com')
INSERT INTO Clients VALUES('Sterling', 'Archer', 'dangerloggins', 'ummphrasing', 5, 'sarcher@aol.com')
