--group by genre and count books in every group
SELECT gerne, 
	COUNT(*) AS total
	FROM tbl_books
	GROUP BY gerne;

--select all books with titles having the letter 'a'
SELECT title 
	FROM tbl_books
	WHERE title LIKE '%a%';

--select all books without an author
SELECT * 
	FROM tbl_books
	WHERE author IS NULL;

--update the year of every book, add 1 year
UPDATE tbl_books 
	SET year = year + 1;

--delete all books without the author
DELETE FROM tbl_books
	WHERE author IS NULL;

--count the number of rows in the table with the author having the letter 'o'
SELECT COUNT(*)
	FROM tbl_books
	WHERE author LIKE '%o%';

--group books by year and show how many books in the same year
SELECT "year", 
	COUNT(*) AS total
	FROM tbl_books
	GROUP BY "year";