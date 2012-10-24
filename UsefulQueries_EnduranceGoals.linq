<Query Kind="SQL">
  <Connection>
    <ID>a3e8086a-9cfc-4c3b-9897-27c0e62da7df</ID>
    <Persist>true</Persist>
    <Provider>System.Data.SqlServerCe.3.5</Provider>
    <AttachFileName>D:\MyStuff\Personal\WebDev\DropBox\EnduranceGoals.com\EnduranceGoals\App_Data\EnduranceGoals.sdf</AttachFileName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAqG4MWCGsx065i5bFM62poQAAAAACAAAAAAADZgAAwAAAABAAAACMKampe0tugwXkflhFqWQ4AAAAAASAAACgAAAAEAAAAGaOFMoxg+aoVCdsp5ehbEsQAAAA1KU71ruflv34UZIT+MGdRxQAAAArVp+U7IfjutYhwceUxvhE/IJrSg==</Password>
    <DisplayName>EnduranceGoals</DisplayName>
  </Connection>
</Query>

ALTER TABLE Participants RENAME TO EventParticipants;

-- Rename tables and columns
sp_rename 'Location', 'Venues'
exec sp_rename 'Location.Location' , 'Location.City', 'COLUMN'

select * from Countries


-- Creating Countries
INSERT into Countries (Name) VALUES ('Spain');
INSERT into Countries (Name) VALUES ('Singapore');
INSERT into Countries (Name) VALUES ('Philippines');
INSERT into Countries (Name) VALUES ('United States');

-- Creating Cities
INSERT into Cities (Name, CountryId) VALUES ('Madrid',1);
INSERT into Cities (Name, CountryId) VALUES ('Barcelona',1);
INSERT into Cities (Name, CountryId) VALUES ('Burgos',1);
INSERT into Cities (Name, CountryId) VALUES ('Singapaore',2);
INSERT into Cities (Name, CountryId) VALUES ('Manila',3);
INSERT into Cities (Name, CountryId) VALUES ('Cavite',3);
INSERT into Cities (Name, CountryId) VALUES ('Camarines Sur',3);
INSERT into Cities (Name, CountryId) VALUES ('Kona',4);
INSERT into Cities (Name, CountryId) VALUES ('New York',4);
INSERT into Cities (Name, CountryId) VALUES ('Boston',4);

-- Creating Venues
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Casa de Campo',1)
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Parque Guell',2)
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Plaza Mayor',3)
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'East Coast Park',4)
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Manila Bay',5)
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Puregold',6);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Water Sports Complex',7);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Kailua Beach',8);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Lady Liberty',9);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Boston Bridge',10);

-- Creating Users
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Juan','Huerta','juan.huerta@gmail.com','jhuerta','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Hasmin','Gelera','hgelera@yahoo.com','hgelera','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Eduard','Moix','edu.moix@gmail.com','emoix','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Unai','Rodriguez','me@u-journal.org','urodriguez','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Lucas','Fernandez','lucas.fernandez@gmail.com','lfernandez','password');

-- Creating Goals
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) VALUES ('20131013','Ironamn World Championship','World Championship of Ironman WTC','www.ironman.com',8,2);
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) VALUES ('20130210','Singapore Duathlon','Annual duathlon organized in Singapore','www.duathlon.sg',4,4);
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) VALUES ('20131013','Boston Marathon','The classic marathon of all times','www.bostonmarathon.com',10,3);
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) VALUES ('20131015','New York 70.3','Amazin 70.3 in the heart of the city!','www.newyork7030.com',9,2);
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) VALUES ('20130415','Madrid Marathon','Rock Madrid Marathon!','www.rockmadridmarathon.com',3,1);

INSERT into GoalParticipants (GoalId, UserId) VALUES (1,1);
INSERT into GoalParticipants (GoalId, UserId) VALUES (1,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,1);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,3);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,4);
INSERT into GoalParticipants (GoalId, UserId) VALUES (4,3);
INSERT into GoalParticipants (GoalId, UserId) VALUES (5,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (5,4);


DELETE from [countries]
ALTER TABLE [countries] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [cities]
ALTER TABLE [cities] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [venues]
ALTER TABLE [venues] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [goals]
ALTER TABLE [goals] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [users]
ALTER TABLE [users] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [goalparticipants]
ALTER TABLE [goalparticipants]

DECLARE @myid uniqueidentifier;

select * from Countries;
select ci.Id, ci.Name, co.Name from Cities ci join Countries co on ci.CountryId = co.Id;
select * from Goals go
join Users us on go.UserCreatorId = Us.Id 
join Venues ve on go.VenueId = ve.Id ;

select * from Cities;
select * from Countries;
select * from goalparticipants;
select * from goals;
select * from Users;
select * from Venues;

select * from cities;
select * from goalparticipants;

update Goals set GoalId = Id
update Users set UserId = Id
update Venues set VenueId = Id








-- Deleting Tables
DELETE from [cities]
DELETE from [countries]
DELETE from [goalparticipants]
DELETE from [goals]
DELETE from [users]
DELETE from [venues]

newid()

-- Creating Countries
select * from countries
DELETE from [countries]
INSERT into Countries (Name) VALUES ('Spain');
INSERT into Countries (Name) VALUES ('Singapore');
INSERT into Countries (Name) VALUES ('Philippines');
INSERT into Countries (Name) VALUES ('United States');

-- Creating Cities
select * from cities
DELETE from [cities]
INSERT INTO Cities(Name, CountryId) SELECT 'Madrid',CountryId FROM Countries WHERE Countries.Name = 'Spain';
INSERT INTO Cities(Name, CountryId) SELECT 'Barcelona',CountryId FROM Countries WHERE Countries.Name = 'Spain';
INSERT INTO Cities(Name, CountryId) SELECT 'Burgos',CountryId FROM Countries WHERE Countries.Name = 'Spain';
INSERT INTO Cities(Name, CountryId) SELECT 'Singapore',CountryId FROM Countries WHERE Countries.Name = 'Singapore';
INSERT INTO Cities(Name, CountryId) SELECT 'Manila',CountryId FROM Countries WHERE Countries.Name = 'Philippines';
INSERT INTO Cities(Name, CountryId) SELECT 'Cavite',CountryId FROM Countries WHERE Countries.Name = 'Philippines';
INSERT INTO Cities(Name, CountryId) SELECT 'Camarines Sur',CountryId FROM Countries WHERE Countries.Name = 'Philippines';
INSERT INTO Cities(Name, CountryId) SELECT 'Kona',CountryId FROM Countries WHERE Countries.Name = 'United States';
INSERT INTO Cities(Name, CountryId) SELECT 'New York',CountryId FROM Countries WHERE Countries.Name = 'United States';
INSERT INTO Cities(Name, CountryId) SELECT 'Boston',CountryId FROM Countries WHERE Countries.Name = 'United States';

-- Creating Venues
select * from venues
DELETE from [venues]
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Casa de Campo',CityId from Cities where Cities.Name = 'Madrid';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Parque Guell',CityId from Cities where Cities.Name = 'Barcelona';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Plaza Mayor',CityId from Cities where Cities.Name = 'Burgos';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'East Coast Park',CityId from Cities where Cities.Name = 'Singapore';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Manila Bay',CityId from Cities where Cities.Name = 'Manila';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Puregold',CityId from Cities where Cities.Name = 'Cavite';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Water Sports Complex',CityId from Cities where Cities.Name = 'Camarines Sur';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Kailua Beach',CityId from Cities where Cities.Name = 'Kona';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Lady Liberty',CityId from Cities where Cities.Name = 'New York';
INSERT into Venues(Latitude, Longitude, Name, CityId) Select 1,1,'Boston Bridge',CityId from Cities where Cities.Name = 'Boston';

-- Creating Users
select * from Users
DELETE from [Users]
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Juan','Huerta','juan.huerta@gmail.com','jhuerta','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Hasmin','Gelera','hgelera@yahoo.com','hgelera','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Eduard','Moix','edu.moix@gmail.com','emoix','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Unai','Rodriguez','me@u-journal.org','urodriguez','password');
INSERT into Users (Name, Lastname, Email, Username,Password) VALUES ('Lucas','Fernandez','lucas.fernandez@gmail.com','lfernandez','password');

-- Creating Goals
select * from Users
select * from Venues
select * from Goals
DELETE from [Goals]
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) values ('20131013','Ironamn World Championship','World Championship of Ironman WTC','www.ironman.com','f63c7348-7b51-4e56-87bc-18a0b79a786b','ad3405c4-ad07-4e46-b7bf-5ac8cefe86a7');
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) values ('20130210','Singapore Duathlon','Annual duathlon organized in Singapore','www.duathlon.sg','c21d222a-f484-4c59-af36-f701ea8a7fc6','d3c1e218-2c4c-494d-ac9e-ddb6d3fd5b18');
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) values ('20131013','Boston Marathon','The classic marathon of all times','www.bostonmarathon.com','e7d219ab-8424-4e54-860d-d27fc12cf9e8','f3539593-0461-4a9f-9b89-5e8e9410033f');
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) values ('20131015','New York 70.3','Amazin 70.3 in the heart of the city!','www.newyork7030.com','bfcfbb53-3a34-401c-94a2-fecf9189d482','c140e608-1c17-4b2e-ab31-4d5a72b01935');
INSERT into Goals ([Date], Title, Description, EventWeb,VenueId,UserCreatorId) values ('20130415','Madrid Marathon','Rock Madrid Marathon!','www.rockmadridmarathon.com','ca373744-43d4-4ec4-b4ae-9abe84e53d96','25daf848-5e1a-4f00-bcb1-cb0beffee9ef');


-- Creating GoalParticipants
select 'users', UserId,newid() from Users
UNION ALL
select 'goals',goalid, newid() from goals
select * from GoalParticipants
DELETE from [GoalParticipants]
INSERT into GoalParticipants (GoalId, UserId) VALUES ('5fcd0e9e-f53d-4cc3-89b9-3b81f2c15cb2','c140e608-1c17-4b2e-ab31-4d5a72b01935');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('5fcd0e9e-f53d-4cc3-89b9-3b81f2c15cb2','ad3405c4-ad07-4e46-b7bf-5ac8cefe86a7');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('5fcd0e9e-f53d-4cc3-89b9-3b81f2c15cb2','25daf848-5e1a-4f00-bcb1-cb0beffee9ef');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('267cead3-ff4a-4cce-bc65-49973e6f6bec','d3c1e218-2c4c-494d-ac9e-ddb6d3fd5b18');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('4e76e1f1-76ac-4b4d-a943-51d3aed20b62','c140e608-1c17-4b2e-ab31-4d5a72b01935');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('82320d8e-9540-4542-ad10-7afe495789b5','c140e608-1c17-4b2e-ab31-4d5a72b01935');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('848b8909-16a9-4c20-b274-9bbd463d345f','ad3405c4-ad07-4e46-b7bf-5ac8cefe86a7');
INSERT into GoalParticipants (GoalId, UserId) VALUES ('4e76e1f1-76ac-4b4d-a943-51d3aed20b62','ad3405c4-ad07-4e46-b7bf-5ac8cefe86a7');
