<Query Kind="SQL">
  <Connection>
    <ID>a3e8086a-9cfc-4c3b-9897-27c0e62da7df</ID>
    <Persist>true</Persist>
    <Provider>System.Data.SqlServerCe.3.5</Provider>
    <AttachFileName>D:\MyStuff\Personal\WebDev\DropBox\EnduranceGoals.com\EnduranceGoals\App_Data\EnduranceGoals.sdf</AttachFileName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAqG4MWCGsx065i5bFM62poQAAAAACAAAAAAADZgAAwAAAABAAAACMKampe0tugwXkflhFqWQ4AAAAAASAAACgAAAAEAAAAGaOFMoxg+aoVCdsp5ehbEsQAAAA1KU71ruflv34UZIT+MGdRxQAAAArVp+U7IfjutYhwceUxvhE/IJrSg==</Password>
  </Connection>
</Query>

ALTER TABLE Participants RENAME TO EventParticipants;

-- Rename tables and columns
-- sp_rename 'GoalAtheletes', 'GoalParticipants'
-- sp_RENAME 'EventParticipants.[OldColumnName]' , '[NewColumnName]', 'COLUMN'



-- Creating Countries
INSERT into Countries (Name) VALUES ('Spain');
INSERT into Countries (Name) VALUES ('Singapore');
INSERT into Countries (Name) VALUES ('Philippines');
INSERT into Countries (Name) VALUES ('United States');

-- Creating Cities
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Madrid',2);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Barcelona',2);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Burgos',2);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Singapaore',3);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Manila',4);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Cavite',4);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Camarines Sur',4);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Kona',5);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'New York',5);
INSERT into Cities (Latitude, Longitude, Name, CountryId) VALUES (1,1,'Boston',5);

-- Creating Users
INSERT into Users (Name, Lastname, Email, Username) VALUES ('Juan','Huerta','juan.huerta@gmail.com','jhuerta');
INSERT into Users (Name, Lastname, Email, Username) VALUES ('Hasmin','Gelera','hgelera@yahoo.com','hgelera');
INSERT into Users (Name, Lastname, Email, Username) VALUES ('Eduard','Moix','edu.moix@gmail.com','emoix');
INSERT into Users (Name, Lastname, Email, Username) VALUES ('Unai','Rodriguez','me@u-journal.org','urodriguez');

INSERT into Goals ([Date], Title, Description, EventWeb,CityId,UserCreatorId) VALUES ('20131013','Ironamn World Championship','World Championship of Ironman WTC','www.ironman.com',8,1);
INSERT into Goals ([Date], Title, Description, EventWeb,CityId,UserCreatorId) VALUES ('20130210','Singapore Duathlon','Annual duathlon organized in Singapore','www.duathlon.sg',4,1);
INSERT into Goals ([Date], Title, Description, EventWeb,CityId,UserCreatorId) VALUES ('20131013','Boston Marathon','The classic marathon of all times','www.bostonmarathon.com',10,2);
INSERT into Goals ([Date], Title, Description, EventWeb,CityId,UserCreatorId) VALUES ('20130415','Madrid Marathon','Rock Madrid Marathon!','www.rockmadridmarathon.com',1,4);

INSERT into GoalParticipants (GoalId, UserId) VALUES (1,1);
INSERT into GoalParticipants (GoalId, UserId) VALUES (1,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,1);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,3);
INSERT into GoalParticipants (GoalId, UserId) VALUES (3,4);
INSERT into GoalParticipants (GoalId, UserId) VALUES (4,3);
INSERT into GoalParticipants (GoalId, UserId) VALUES (6,2);
INSERT into GoalParticipants (GoalId, UserId) VALUES (6,4);


select * from Countries;
select * from Cities;
select * from Users;
select * from Goals;
select * from GoalParticipants;