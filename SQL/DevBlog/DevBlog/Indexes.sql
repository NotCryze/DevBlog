CREATE UNIQUE INDEX Idx_CategoryId
    ON Category([Id]);
GO

CREATE UNIQUE INDEX Idx_CategoryName
    ON Category([Name]);
GO

CREATE UNIQUE INDEX Idx_TagId
    ON Tag([Id]);

CREATE UNIQUE INDEX Idx_TagName
    ON Tag([Name]);