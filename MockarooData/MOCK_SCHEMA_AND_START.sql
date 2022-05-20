/*
If you run this, then you can make the database that will resemble the database
we created through Entity Framework (EF). However, we took the code first route.
Alternatively, this could be used with EF to scaffold the API build as the data-
base for a database first approach.
*/

--Create the schema
CREATE SCHEMA RevConnect
GO

--Tables creation below - for the purposes of setting mock data, "IDENTITY (1,1)" is left out.
CREATE TABLE RevConnect.Users (
	userID INT NOT NULL PRIMARY KEY,
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
	postID INT NOT NULL PRIMARY KEY,
	title TEXT,
	body TEXT,
	authID NVARCHAR(24),
	postComments NVARCHAR(10),
	postLikes NVARCHAR(50)
);

CREATE TABLE RevConnect.Comments (
	commentID INT NOT NULL PRIMARY KEY,
	body TEXT,
	authID NVARCHAR(24),
	commentLikes NVARCHAR(50)
);

CREATE TABLE RevConnect.Likes (
	likeID INT NOT NULL PRIMARY KEY,
	authID NVARCHAR(24),
	postID INT,
	commentID INT
);