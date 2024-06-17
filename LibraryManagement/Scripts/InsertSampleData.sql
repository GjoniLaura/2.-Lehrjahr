-- Insert sample data into Books
INSERT INTO Books (Title, Author, YearPublished, Genre, NumberOfPages) VALUES
('1984', 'George Orwell', '1949-06-08', 'Dystopian', 328),
('To Kill a Mockingbird', 'Harper Lee', '1960-07-11', 'Fiction', 281);

-- Insert sample data into Members
INSERT INTO Members (FirstName, LastName, Age, Registration, Email, PhoneNumber, MembershipStatus, MembershipFee) VALUES
('John', 'Doe', 30, '2023-01-01', 'john.doe@example.com', '123-456-7890', 'Active', 50.0),
('Jane', 'Smith', 25, '2023-02-01', 'jane.smith@example.com', '987-654-3210', 'Active', 60.0);

-- Insert sample data into Loans
INSERT INTO Loans (StartDate, DueDate, ReturnDate, RenewalCount, Status, Fine, MemberId) VALUES
('2023-01-01', '2023-01-15', NULL, 0, 'Active', 0, 1),
('2023-02-01', '2023-02-15', '2023-02-10', 1, 'Returned', 5, 2);
