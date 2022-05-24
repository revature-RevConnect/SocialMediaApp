/*
If you run this, then you can make the database that will resemble the database
we created through Entity Framework (EF). However, we took the code first route.
Alternatively, this could be used with EF to scaffold the API build as the data-
base for a database first approach. After making the schema and tables, run the
accompanying files in your database management tool in this order: MOCK_USERS,
MOCK_POSTS, MOCK_COMMENTS, and MOCK_LIKES. Once they are populated, you can look
at the data or destroy it with queries in MOCK_CHECKOUT.
*/

--Create the schema
CREATE SCHEMA RevSocial
GO

--Tables creation below
CREATE TABLE RevSocial.Users (
	userID INT NOT NULL IDENTITY (1,1),
	authID NVARCHAR(24) NOT NULL PRIMARY KEY,
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

CREATE TABLE RevSocial.Posts (
	postID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	title TEXT,
	body TEXT,
	authID NVARCHAR(24) FOREIGN KEY REFERENCES RevSocial.Users (authID) ON DELETE CASCADE
);

CREATE TABLE RevSocial.Comments (
	commentID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	body TEXT,
	authID NVARCHAR(24) FOREIGN KEY REFERENCES RevSocial.Users (authID) ON DELETE CASCADE,
	postID INT NOT NULL FOREIGN KEY REFERENCES RevSocial.Posts (postID) ON DELETE CASCADE
);

CREATE TABLE RevSocial.Likes (
	likeID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	authID NVARCHAR(24) FOREIGN KEY REFERENCES RevSocial.Users (authID) ON DELETE CASCADE,
	postID INT FOREIGN KEY REFERENCES RevSocial.Posts (postID) ON DELETE CASCADE,
	commentID INT FOREIGN KEY REFERENCES RevSocial.Comments (commentID) ON DELETE CASCADE
);