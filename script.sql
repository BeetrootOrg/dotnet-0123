-- Initial database creation script
CREATE TABLE IF NOT EXISTS tbl_books (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    isbn VARCHAR(255) NOT NULL,
    genre VARCHAR(255) NOT NULL,
    year INT NOT NULL
);
INSERT INTO tbl_books (title, author, isbn, genre, year)
VALUES (
        'The Hobbit',
        'J.R.R. Tolkien',
        '9780547928227',
        'Fantasy',
        1937
    ),
    (
        'The Fellowship of the Ring',
        'J.R.R. Tolkien',
        '9780547928210',
        'Fantasy',
        1954
    ),
    (
        'The Two Towers',
        'J.R.R. Tolkien',
        '9780547928203',
        'Fantasy',
        1954
    ),
    (
        'The Return of the King',
        'J.R.R. Tolkien',
        '9780547928197',
        'Fantasy',
        1955
    ),
    (
        'The Silmarillion',
        'J.R.R. Tolkien',
        '9780547928173',
        'Fantasy',
        1977
    ),
    (
        'The Children of Húrin',
        'J.R.R. Tolkien',
        '9780547928180',
        'Fantasy',
        2007
    ),
    (
        'The Lord of the Rings',
        'J.R.R. Tolkien',
        '9780547928234',
        'Fantasy',
        1954
    ),
    (
        '1984',
        'George Orwell',
        '9780451524935',
        'Dystopian',
        1949
    ),
    (
        'The Secret History',
        'Donna Tartt',
        '9780312427650',
        'Mystery',
        1992
    ),
    (
        'The Bible',
        NULL,
        '9780312427650',
        'Religious',
        -100
    );
-- group by genre and count books in every group
SELECT genre,
    COUNT(*) AS books_count
FROM tbl_books
GROUP BY genre;
-- select all books with titles having the letter 'a'
SELECT *
FROM tbl_books
WHERE title LIKE '%a%'
    OR title LIKE '%A%';
-- select all books without an author
SELECT *
FROM tbl_books
WHERE author IS NULL;
-- update the year of every book, add 1 year
UPDATE tbl_books
SET year = year + 1;
-- delete all books without the author
DELETE FROM tbl_books
WHERE author IS NULL;
-- count the number of rows in the table with the author having the letter 'o'
SELECT COUNT(*) AS books_count
FROM tbl_books
WHERE author LIKE '%o%'
    OR author LIKE '%O%';
-- group books by year and show how many books in the same year
SELECT year,
    COUNT(*) AS books_count
FROM tbl_books
GROUP BY year;