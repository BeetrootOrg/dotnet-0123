CREATE TABLE IF NOT EXISTS tbl_books (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    isbn VARCHAR(255) NOT NULL,
    year INT NOT NULL,
    genre VARCHAR(255)
);

-- 1. Group by genre and count books in every group
SELECT genre, COUNT(*) FROM tbl_books  GROUP BY (genre);

-- 2. Select all books with titles having the letter 'a'
SELECT * FROM tbl_books WHERE title LIKE '%a%';

-- 3. Select all books without an author
SELECT * FROM tbl_books WHERE author IS NULL;

-- 4. Update the year of every book, add 1 year
UPDATE tbl_books SET year = year + 1;

--delete all books without the author
DELETE FROM tbl_books WHERE author IS NULL;

-- 5. Count the number of rows in the table with the author having the letter 'o'
SELECT COUNT(*) FROM tbl_books WHERE author LIKE '%o%';

-- 6. Group books by year and show how many books in the same year
SELECT year, COUNT(*) FROM tbl_books GROUP BY year;