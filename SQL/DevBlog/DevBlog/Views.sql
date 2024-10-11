USE DevBlog
GO

/*
	Account
*/
CREATE OR ALTER VIEW View_Accounts
AS
	SELECT TOP 100 PERCENT Account.*, TimeRegistration.UpdatedAt, TimeRegistration.CreatedAt
	FROM Account
	INNER JOIN TimeRegistration
	ON Account.TimeRegistrationId = TimeRegistration.Id
GO

/*
	BlogPost
*/

CREATE OR ALTER VIEW View_BlogPosts
AS
	SELECT
		Post.[Id], Post.[Title], Post.[Content], Post.[PostType],
		Post.[TimeRegistrationId], TimeRegistration.[UpdatedAt], TimeRegistration.[CreatedAt],
		Post.[AuthorId], View_Accounts.[FirstName] AS AccountFirstName, View_Accounts.[LastName] AS AccountLastName, View_Accounts.[Email] AS AccountEmail, View_Accounts.[Password] AS AccountPassword, View_Accounts.[IsAdmin] AS AccountIsAdmin, View_Accounts.[TimeRegistrationId] AS AccountTimeRegistrationId, View_Accounts.[UpdatedAt] AS AccountUpdatedAt, View_Accounts.[CreatedAt] AS AccountCreatedAt,
		Post.[CategoryId], Category.[Name] AS CategoryName
	FROM Post
	INNER JOIN View_Accounts
	ON View_Accounts.Id = Post.AuthorId
	INNER JOIN Category
	ON Post.CategoryId = Category.Id
	INNER JOIN TimeRegistration
	ON Post.TimeRegistrationId = TimeRegistration.Id
	WHERE PostType = 0
GO