-- Create the Members table
CREATE TABLE IF NOT EXISTS Members (
    MemberId INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT NOT NULL,
    LastName TEXT NOT NULL,
    Age INTEGER NOT NULL,
    Registration TEXT NOT NULL,
    Email TEXT NOT NULL,
    PhoneNumber TEXT NOT NULL,
    MembershipStatus TEXT NOT NULL,
    BorrowedBooks TEXT,
    MembershipFee REAL NOT NULL,
    DueDates TEXT
);

-- Create the Loans table
CREATE TABLE IF NOT EXISTS Loans (
    LoanId INTEGER PRIMARY KEY AUTOINCREMENT,
    StartDate TEXT NOT NULL,
    DueDate TEXT NOT NULL,
    ReturnDate TEXT,
    RenewalCount INTEGER NOT NULL,
    Status TEXT NOT NULL,
    Fine REAL,
    MemberId INTEGER NOT NULL,
    FOREIGN KEY (MemberId) REFERENCES Members(MemberId)
);

-- Create the Books table
CREATE TABLE IF NOT EXISTS Books (
    BookId INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Author TEXT NOT NULL,
    YearPublished TEXT NOT NULL,
    Genre TEXT NOT NULL,
    NumberOfPages INTEGER NOT NULL
);
