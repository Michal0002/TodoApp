CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(32),
    Description VARCHAR(64),
    CreatedDate DATETIME,
    DueDate DATETIME,
    Status VARCHAR(16),
    Priority VARCHAR(8)
);
