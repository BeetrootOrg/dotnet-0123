-- 01. init table
CREATE TABLE IF NOT EXISTS tbl_books (

 id BIGSERIAL PRIMARY KEY,

 title VARCHAR(255) NOT NULL,

 author VARCHAR(255),

 genre VARCHAR(255) NOT NULL,

 year INT NOT NULL

);

-- 02. select data by condition

-- 02.1. group by genre and count books in every group
SELECT genre, Count(genre)
FROM tbl_books
GROUP BY genre;

--02.2 select all books with titles having the letter 'a'
SELECT *
FROM tbl_books
where title like '%a%';

--02.3 select all books without an author
SELECT *
FROM tbl_books
where author is NULL;

--02.4 update the year of every book, add 1 year
UPDATE tbl_books
SET year = year+1;

--02.5 delete all books without the author
DELETE FROM tbl_books
WHERE author is null;

--02.6 count the number of rows in the table with the author having the letter 'o'
SELECT COUNT(*)
FROM tbl_books
WHERE author like '%o%';

--02.7 group books by year and show how many books in the same year
SELECT year, COUNT(year)
FROM tbl_books
GROUP BY year;