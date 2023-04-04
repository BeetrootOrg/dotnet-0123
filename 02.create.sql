INSERT INTO tbl_books(title, author, isbn, "year")
	VALUES ('Lust for Life', 'Irving Stone', '978-0452262492', '1984'),
	('The Agony and the Ecstasy', 'Irving Stone', '978-0451213235', '2004'),
	('Time and time again', 'Ben Elton', '978-0456543128', '2014'),
	('Cutting for stone', 'Abraham Verghese', '978-0452221468', '2010'),
	('Voroshilovgrad', 'Serhiy Zhadan', '978-0452221464', '2016'),
	('11-22-63:A Novel', 'Stephen King', '978-0452468521', '2011'),
	('The Green Mile', 'Stephen King', '978-0452468544', '1999 ');

ALTER TABLE tbl_books ADD COLUMN gerne VARCHAR(255) NOT NULL;

UPDATE tbl_books
	SET gerne = 'Biography'
	WHERE isbn = '978-0452262492' 
    OR isbn ='978-0451213235';
	
UPDATE tbl_books
	SET gerne = 'Science fiction'
	WHERE isbn = '978-0456543128' 
    OR isbn = '978-0452468521' 
    OR isbn = '978-0452468544';
	
UPDATE tbl_books
	SET gerne = 'Novel'
	WHERE isbn = '978-0452221468' 
    OR isbn = '978-0452221464';

INSERT INTO tbl_books (title, isbn, "year", gerne)
	VALUES ('No title 1', '978-0452221111', '2000', 'Novel'),
			('No title 2', '978-0452222222', '2000', 'Novel'),
			('No title 3', '978-0452222222', '2010', 'Biography');

SELECT * 
	FROM tbl_books
	ORDER BY id ASC;