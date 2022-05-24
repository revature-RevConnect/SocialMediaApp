--Highlight the commands you want to run and hit run. 
--If you run the file without doing that, you will take apart the tables and schema.

SELECT * FROM RevSocial.Users;
SELECT * FROM RevSocial.Posts;
SELECT * FROM RevSocial.Comments;
SELECT * FROM RevSocial.Likes;

DROP TABLE RevSocial.Likes;
DROP TABLE RevSocial.Comments;
DROP TABLE RevSocial.Posts;
DROP TABLE RevSocial.Users;

DROP SCHEMA [ IF EXISTS ] RevSocial;
