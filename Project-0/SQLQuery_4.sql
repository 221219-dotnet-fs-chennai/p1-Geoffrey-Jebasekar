-- create schema project0;
create table Signup(
-- userid int NOT NULL,
firstname varchar(15) not null,
lastname VARCHAR(15) not null,
emailId VARCHAR(25) not NULL,
[password] VARCHAR(15) not NULL,
phoneno VARCHAR(10) not null,
age int not NULL,
city VARCHAR(15) not null,
constraint [PK_Signup] PRIMARY KEY(emailId) 

);
-- drop table project0.TrainerSignup;
create table [Login]
(
    --[UserLoginId] int not null,
    emailid VARCHAR(25) not null UNIQUE,
    [password] VARCHAR(25) not null,
    CONSTRAINT [FK_Login]FOREIGN KEY( emailid ) REFERENCES Signup(emailId) on DELETE CASCADE on UPDATE CASCADE



);

CREATE TABLE Education
(
    --trainerid int not null,
    emailid VARCHAR(25) not NULL,
    educationType VARCHAR(20) not null,
    instituteName VARCHAR(50) not null,
    stream VARCHAR(20) not NULL,
    startYear VARCHAR(4) not null,
    endYear VARCHAR(4) not null,
    [percentage] VARCHAR(4) not NULL,
    CONSTRAINT [FK_Education] FOREIGN KEY(emailid) REFERENCES Signup(emailId) on DELETE CASCADE on UPDATE CASCADE

);

create table Companies
(
    --trainerid int not NULL,
    emailid VARCHAR(25) not NULL,
    companyName VARCHAR(25) not null,
    Title VARCHAR(10) not null,
    industry VARCHAR(20) not null,
    employementType VARCHAR(15) not NULL,
    [location] VARCHAR(20) not null,
    startYear VARCHAR(4) not null,
    endYear VARCHAR(4) not NULL
    CONSTRAINT [FK_Companies] FOREIGN KEY(emailid) REFERENCES Signup(emailid) on delete CASCADE on UPDATE CASCADE

);

CREATE table Skills
(
    emailid VARCHAR(25) not NULL,
    skill VARCHAR(15) not null,
    Profeciency int not NULL ,
    CONSTRAINT [FK_Skills] FOREIGN key(emailid) REFERENCES Signup(emailId) on DELETE cascade on UPDATE CASCADE



);

alter table Signup alter COLUMN age int not null
alter TABLE Signup alter COLUMN phoneno VARCHAR(10) not null


SELECT Signup.firstname,Signup.lastname,Signup.emailId,Signup.age,Education.educationType,Education.instituteName,Education.stream,Education.percentage,
Companies.companyName,Companies.Title,Companies.industry,Companies.location,Skills.skill,Skills.Profeciency From Signup 
INNER JOIN Education on Signup.emailId = Education.emailid INNER join Companies on Signup.emailId = Companies.emailid INNER JOIN Skills 
on Signup.emailId = Skills.emailid WHERE Signup.emailId = 'geffshelby@gmail.com'

SELECT firstname,lastname,phoneno,age,city from Signup where emailid = 'geffshelby@gmail.com'

update Skills set skill='{skills.skill}',Profeciency='{skills.profeciencyInSkill}' where emailid='{emailid}' and skill='{skill}'


select * from Signup
SELECT * from Login
ALTER TABLE LOGIN add CONSTRAINT Unique_Email UNIQUE(emailid)