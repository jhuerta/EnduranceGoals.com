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

select * from Location


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
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Casa de Campo',1);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Parque Guell',2);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Plaza Mayor',3);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'East Coast Park',4);
INSERT into Venues (Latitude, Longitude, Name, CityId) VALUES (1,1,'Manila Bay',5);
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
INSERT into GoalParticipants (GoalId, UserId) VALUES (6,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (6,4);

update [Users] set [Password] = 'password'


DELETE from [countries]
ALTER TABLE [countries] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [cities]
ALTER TABLE [cities] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [venues]
ALTER TABLE [venues] ALTER COLUMN ID IDENTITY (1,1)

select * from goals
DELETE from [goals]
ALTER TABLE [goals] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [users]
ALTER TABLE [users] ALTER COLUMN ID IDENTITY (1,1)

DELETE from [goalparticipants]
ALTER TABLE [goalparticipants]

truncate countries;
truncate cities;
truncate venues;
truncate goals;
truncate users;
truncate goalsparticipants;

select * from Countries;
select ci.Id, ci.Name, co.Name from Cities ci join Countries co on ci.CountryId = co.Id;
select * from Users;
select * from Venues;
select * from Goals go
join Users us on go.UserCreatorId = Us.Id 
join Venues ve on go.VenueId = ve.Id ;

select * from cities;