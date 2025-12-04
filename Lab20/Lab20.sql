use BookShop


INSERT INTO Authors (FirstName, LastName) VALUES ('Terry', 'Pratchett');
INSERT INTO Authors (FirstName, LastName) VALUES ('Neil', 'Gaiman');
INSERT INTO Authors (FirstName, LastName) VALUES ('Ursula K.', 'Le Guin');
INSERT INTO Authors (FirstName, LastName) VALUES ('Ray', 'Bradbury');
INSERT INTO Authors (FirstName, LastName) VALUES ('George', 'Orwell');
INSERT INTO Authors (FirstName, LastName) VALUES ('Isaac', 'Asimov');
INSERT INTO Authors (FirstName, LastName) VALUES ('Arthur Conan', 'Doyle');
INSERT INTO Authors (FirstName, LastName) VALUES ('Agatha', 'Christie');
INSERT INTO Authors (FirstName, LastName) VALUES ('Haruki', 'Murakami');
INSERT INTO Authors (FirstName, LastName) VALUES ('F. Scott', 'Fitzgerald');
go 
INSERT INTO Categories (Name) VALUES ('Fiction');
INSERT INTO Categories (Name) VALUES ('Fantasy');
INSERT INTO Categories (Name) VALUES ('Mystery');
INSERT INTO Categories (Name) VALUES ('Science Fiction');
INSERT INTO Categories (Name) VALUES ('Classic');
INSERT INTO Categories (Name) VALUES ('Novel');
INSERT INTO Categories (Name) VALUES ('Historical');
INSERT INTO Categories (Name) VALUES ('Short Story');
INSERT INTO Categories (Name) VALUES ('Thriller');
INSERT INTO Categories (Name) VALUES ('Poetry');
go

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (1, 'The Colour of Magic', 'The first novel in the satirical Discworld series.', '1983-11-24', 500, 15.99, 1, 0); 

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (2, 'American Gods', 'An ex-convict finds himself in the middle of a conflict between Old and New Gods.', '2001-06-19', 800, 22.50, 2, 1);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (3, 'A Wizard of Earthsea', 'A young wizard must confront a powerful shadow that he accidentally released.', '1968-04-01', 300, 12.00, 0, 0);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (4, 'Fahrenheit 451', 'A dystopian future where firemen burn books to suppress dissent.', '1953-10-15', 1200, 18.75, 1, 0);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (5, 'Nineteen Eighty-Four', 'A cautionary tale about totalitarianism and surveillance.', '1949-06-08', 950, 14.99, 2, 2);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (6, 'I, Robot', 'Explorations of the ethical implications of robots governed by the Three Laws of Robotics.', '1950-12-02', 620, 16.50, 1, 0);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (7, 'A Study in Scarlet', 'Introduces the characters Sherlock Holmes and Dr. Watson.', '1887-10-25', 400, 9.99, 0, 0); 

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (8, 'And Then There Were None', 'Ten strangers are lured to an island mansion and killed one by one.', '1939-11-06', 710, 17.00, 1, 0);

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (9, 'Norwegian Wood', 'A nostalgic story of loss and sexual awakening.', '1987-09-04', 1100, 25.00, 2, 1); 

INSERT INTO Books (AuthorId, Title, Description, ReleaseDate, Copies, Price, AgeRestriction, EditionType) 
VALUES (10, 'The Great Gatsby', 'The Jazz Age novel focusing on wealth, class, and the American Dream.', '1925-04-10', 550, 13.50, 1, 0); 
go
INSERT INTO BookCategory (BookId, CategoryId) VALUES (1, 2);
INSERT INTO BookCategory (BookId, CategoryId) VALUES (1, 1);

INSERT INTO BookCategory (BookId, CategoryId) VALUES (2, 2);
INSERT INTO BookCategory (BookId, CategoryId) VALUES (2, 6);

INSERT INTO BookCategory (BookId, CategoryId) VALUES (3, 2);

INSERT INTO BookCategory (BookId, CategoryId) VALUES (4, 4);
INSERT INTO BookCategory (BookId, CategoryId) VALUES (4, 5);

INSERT INTO BookCategory (BookId, CategoryId) VALUES (5, 5);
INSERT INTO BookCategory (BookId, CategoryId) VALUES (5, 1);

INSERT INTO BookCategory (BookId, CategoryId) VALUES (7, 3);
INSERT INTO BookCategory (BookId, CategoryId) VALUES (7, 5);