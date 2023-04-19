-- initial create table script
CREATE TABLE IF NOT EXISTS tbl_books (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    isbn VARCHAR(255) NOT NULL,
    year INT NOT NULL
);

-- insert some data
INSERT INTO
    tbl_books (title, author, isbn, year)
VALUES
    (
        'To Kill a Mockingbird',
        'Harper Lee',
        '9780446310789',
        1960
    ),
    ('1984', 'George Orwell', '9780451524935', 1949),
    (
        'The Great Gatsby',
        'F. Scott Fitzgerald',
        '9780743273565',
        1925
    ),
    (
        'Pride and Prejudice',
        'Jane Austen',
        '9780486284736',
        1967
    ),
    (
        'The Catcher in the Rye',
        'J.D. Salinger',
        '9780316769488',
        1967
    ),
    (
        'One Hundred Years of Solitude',
        'Gabriel García Márquez',
        '9780060883287',
        1967
    ),
    (
        'Brave New World',
        'Aldous Huxley',
        '9780060850524',
        1932
    ),
    (
        'The Lord of the Rings',
        null,
        '9780544003415',
        1954
    ),
    (
        'The Hitchhiker''s Guide to the Galaxy',
        'Douglas Adams',
        '9780345391803',
        1979
    ),
    (
        'The Diary of a Young Girl',
        'Anne Frank',
        '9780553577129',
        1960
    );

-- group by author and count books in every group
SELECT
    author,
    COUNT(1)
FROM
    tbl_books
GROUP BY
    author -- select all books with titles having the letter 'a'
SELECT
    *
FROM
    tbl_books
WHERE
    title LIKE '%a%'
    OR title LIKE '%A%' -- select all books without an author
SELECT
    *
FROM
    tbl_books
WHERE
    author IS NULL -- update the year of every book, add 1 year
UPDATE
    tbl_books
SET
    year = year + 1 -- delete all books without the author
DELETE FROM
    tbl_books
WHERE
    author IS NULL
    OR author = '';

-- count the number of rows in the table with the author having the letter 'o'
SELECT
    COUNT(1)
FROM
    tbl_books
WHERE
    author LIKE '%o%'
    OR author LIKE '%O%' -- group books by year and show how many books in the same year
SELECT
    year,
    COUNT(1)
FROM
    tbl_books
GROUP BY
    year