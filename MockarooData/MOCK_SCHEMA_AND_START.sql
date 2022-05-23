/*
If you run this, then you can make the database that will resemble the database
we created through Entity Framework (EF). However, we took the code first route.
Alternatively, this could be used with EF to scaffold the API build as the data-
base for a database first approach.
*/

--Create the schema
CREATE SCHEMA RevConnect
GO

--Tables creation below
CREATE TABLE RevConnect.Users (
	userID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	authID NVARCHAR(24) NOT NULL,
	name NVARCHAR(50),
	email NVARCHAR(50),
	profilePicture NVARCHAR(1000),
	aboutMe TEXT,
	phone NVARCHAR(50),
	address NVARCHAR(50),
	linkedin NVARCHAR(50),
	twitter NVARCHAR(50),
	github NVARCHAR(50),
	active BIT
);

CREATE TABLE RevConnect.Posts (
	postID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	title TEXT,
	body TEXT,
	authID NVARCHAR(24)
);

CREATE TABLE RevConnect.Comments (
	commentID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	body TEXT,
	authID NVARCHAR(24),
	postID INT NOT NULL FOREIGN KEY REFERENCES 
);

CREATE TABLE RevConnect.Likes (
	likeID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	authID NVARCHAR(24),
	postID INT,
	commentID INT
);