USE DevBlog
GO

/*
	Time Registration
*/

-- Create Time Registration
CREATE OR ALTER PROCEDURE spCreateTimeRegistration
	@Id UNIQUEIDENTIFIER,
	@UpdatedAt DateTime,
	@CreatedAt DateTime
AS
BEGIN
	INSERT INTO TimeRegistration
		([Id], [UpdatedAt], [CreatedAt])
	VALUES
		(@Id, @UpdatedAt, @CreatedAt)
END
GO


/*
	Account
*/

-- Create Account
CREATE OR ALTER PROCEDURE spCreateAccount
	@Id UNIQUEIDENTIFIER,
	@FirstName NVARCHAR(64),
	@LastName NVARCHAR(64),
	@Email NVARCHAR(320),
	@Password NVARCHAR(60),
	@IsAdmin BIT,
	@TimeRegistrationId UNIQUEIDENTIFIER 
AS
BEGIN
	INSERT INTO Account
		([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin], [TimeRegistrationId])
	VALUES
		(@Id, @FirstName, @LastName, @Email, @Password, @IsAdmin, @TimeRegistrationId)
END
GO

-- Read Account
CREATE OR ALTER PROCEDURE spGetAccount
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM View_Accounts
	WHERE [Id] = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetAccounts
AS
BEGIN
	SELECT Account.*, TimeRegistration.UpdatedAt, TimeRegistration.CreatedAt
	FROM Account
	INNER JOIN TimeRegistration
	ON Account.TimeRegistrationId = TimeRegistration.Id
END
GO

CREATE OR ALTER PROCEDURE spGetAccountByEmail
	@Email NVARCHAR(320)
AS
BEGIN
	SELECT Account.*, TimeRegistration.UpdatedAt, TimeRegistration.CreatedAt
	FROM Account
	INNER JOIN TimeRegistration
	ON Account.TimeRegistrationId = TimeRegistration.Id
	WHERE [Email] = @Email
END
GO

/*
	BlogPost
*/

-- Create BlogPost
CREATE OR ALTER PROCEDURE spCreateBlogPost
	@Id UNIQUEIDENTIFIER,
	@Title NVARCHAR(64),
	@Content NVARCHAR(1024),
	@AuthorId UNIQUEIDENTIFIER,
	@CategoryId UNIQUEIDENTIFIER,
	@PostType TINYINT,
	@TimeRegistrationId UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO Post
		([Id], [Title], [Content], [AuthorId], [CategoryId], [PostType], [TimeRegistrationId])
	VALUES
		(@Id, @Title, @Content, @AuthorId, @CategoryId, @PostType, @TimeRegistrationId)
END
GO

-- Read BlogPost
CREATE OR ALTER PROCEDURE spGetBlogPost
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM View_BlogPosts
	WHERE [Id] = @Id
	ORDER BY CreatedAt DESC
END
GO

CREATE OR ALTER PROCEDURE spGetBlogPosts
AS
BEGIN
	SELECT *
	FROM View_BlogPosts
	ORDER BY CreatedAt DESC
END
GO

CREATE OR ALTER PROCEDURE spGetBlogPostsByAccountId
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM View_BlogPosts
	WHERE [AuthorId] = @Id
	ORDER BY CreatedAt DESC
END
GO


/*
	Category
*/

-- Create Category
CREATE OR ALTER PROCEDURE spCreateCategory
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(64) 
AS
BEGIN
	INSERT INTO Category
		([Id], [Name])
	VALUES
		(@Id, @Name)
END
GO

-- Read Category
CREATE OR ALTER PROCEDURE spGetCategory
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM Category
	WHERE [Id] = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetCategoryByName
	@Name NVARCHAR(64)
AS
BEGIN
	SELECT *
	FROM Category
	WHERE [Name] = @Name
END
GO

CREATE OR ALTER PROCEDURE spGetCategories
AS
BEGIN
	SELECT *
	FROM Category
END
GO


/*
	Tag
*/

-- Create Tag
CREATE OR ALTER PROCEDURE spCreateTag
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(64) 
AS
BEGIN
	INSERT INTO Tag
		([Id], [Name])
	VALUES
		(@Id, @Name)
END
GO

CREATE OR ALTER PROCEDURE spAddTag
	@TagId UNIQUEIDENTIFIER,
	@PostId UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO PostTags
		([TagId], [PostId])
	VALUES
		(@TagId, @PostId)
END
GO

-- Read Tag
CREATE OR ALTER PROCEDURE spGetTag
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM Tag
	WHERE [Id] = @Id
END
GO

CREATE OR ALTER PROCEDURE spGetTagByName
	@Name NVARCHAR(64)
AS
BEGIN
	SELECT *
	FROM Tag
	WHERE [Name] = @Name
END
GO

CREATE OR ALTER PROCEDURE spGetTags
AS
BEGIN
	SELECT *
	FROM Tag
END
GO

CREATE OR ALTER PROCEDURE spGetTagsByPost
	@Id UNIQUEIDENTIFIER 
AS
BEGIN
	SELECT Tag.*
	FROM Tag
	INNER JOIN PostTags
	ON @Id = PostTags.PostId
	WHERE PostTags.TagId = Tag.Id
END
GO

/*
	Post Image
*/

-- Create Post Image
CREATE OR ALTER PROCEDURE spCreatePostImage
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(max),
	@PostId UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO PostImage
		([Id], [Name], [PostId])
	VALUES
		(@Id, @Name, @PostId)
END
GO

-- Read Post Image
CREATE OR ALTER PROCEDURE spGetPostImagesByPost
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT *
	FROM PostImage
	WHERE [PostId] = @Id
END
GO