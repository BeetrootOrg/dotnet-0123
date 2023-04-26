INSERT INTO tbl_books(title, author, isbn, year)
VALUES('The Hunger Games', 'Suzanne Collins', 'Fiction', 2008),
('Harry Potter and the Order of the Phoenix', 'Joanne Rowling', 'Magic', 2003),
('The Chronicles of Narnia', 'Clive Lewis', 'Fantasy', 1956),
('The Picture of Dorian Gray', 'Oscar Wilde', 'Fiction', 1890),
('Romeo and Juliet', 'William Shakespeare', 'Fiction', 1597),
('Harry Potter and the Sorcerers Stone', 'Joanne Rowling', 'Magic', 1997),
('A Game of Thrones', 'George Martin', 'Fantasy', 1996)


SELECT isbn, COUNT(*) AS book_count
FROM tbl_books
GROUP BY isbn

SELECT * FROM tbl_books
WHERE title LIKE '%a%'

SELECT * FROM tbl_books
WHERE author IS NULL

UPDATE tbl_books
SET year = year + 1

DELETE FROM tbl_books
WHERE author IS NULL

SELECT COUNT(1)
FROM tbl_books
WHERE author LIKE '%o%'
OR author LIKE '%O%'

SELECT year, COUNT(*) AS book_count
FROM tbl_books
GROUP BY year