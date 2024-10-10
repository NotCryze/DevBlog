USE DevBlog
GO

/*
	Execute a few Stored Procedures or Queries to generate some example data
*/
DECLARE @Id UNIQUEIDENTIFIER;

-- Category Example Data
SET @Id = NEWID();
EXEC spCreateCategory @Id = @Id, @Name = 'Web Development'

SET @Id = NEWID();
EXEC spCreateCategory @Id = @Id, @Name = 'Machine Learning'

SET @Id = NEWID();
EXEC spCreateCategory @Id = @Id, @Name = 'Testing & QA'

SET @Id = NEWID();
EXEC spCreateCategory @Id = @Id, @Name = 'Game Development'

SET @Id = NEWID();
EXEC spCreateCategory @Id = @Id, @Name = 'APIs & Integrations'


-- Tag Example Data
SET @Id = NEWID();
EXEC spCreateTag @Id = @Id, @Name = 'HTML'

SET @Id = NEWID();
EXEC spCreateTag @Id = @Id, @Name = 'React'

SET @Id = NEWID();
EXEC spCreateTag @Id = @Id, @Name = 'Python'

SET @Id = NEWID();
EXEC spCreateTag @Id = @Id, @Name = 'Docker'

SET @Id = NEWID();
EXEC spCreateTag @Id = @Id, @Name = 'Unity'
