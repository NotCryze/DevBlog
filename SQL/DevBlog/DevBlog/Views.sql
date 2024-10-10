USE DevBlog
GO

/*
	BlogPost
*/

CREATE OR ALTER VIEW View_OrderedBlogPosts
AS
	SELECT TOP 100 PERCENT Post.*
	FROM Post
	INNER JOIN Category
	ON Post.CategoryId = Category.Id
	INNER JOIN TimeRegistration
	ON Post.TimeRegistrationId = TimeRegistration.Id
	WHERE PostType = 0
	ORDER BY TimeRegistration.CreatedAt DESC
GO