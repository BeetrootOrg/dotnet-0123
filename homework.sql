--authors
CREATE TABLE IF NOT EXISTS tbl_authors (
    id serial PRIMARY KEY,
    first_name character varying(255) NOT NULL,
    last_name character varying(255)
);

--books
CREATE TABLE IF NOT EXISTS tbl_books (
    id serial PRIMARY KEY,
    author_id integer,
    title character varying(255) NOT NULL,
    isbn character varying(255) NOT NULL,
    year integer NOT NULL,
    genre character varying(255),
    FOREIGN KEY (author_id) REFERENCES tbl_authors(id)
);

CREATE INDEX IF NOT EXISTS tbl_books_author_id ON tbl_books(author_id);

--count of each book (query instead table)
SELECT 
	h.book_id,
	b.title,
	a.first_name,
	a.last_name,
	(SELECT SUM(quantity) FROM tbl_history WHERE book_id = h.book_id AND direction = 'IN') AS received,
	(SELECT SUM(quantity) FROM tbl_history WHERE book_id = h.book_id AND direction = 'OUT') AS returned
FROM
	tbl_history AS h
INNER JOIN
	tbl_books AS b ON h.book_id = b.id
INNER JOIN
	tbl_authors AS a ON b.author_id = a.id	
GROUP BY
	h.book_id, b.title, a.first_name, a.last_name

--customers
CREATE TABLE IF NOT EXISTS tbl_customers (
    id serial PRIMARY KEY,
    first_name character varying(255) NOT NULL,
    last_name character varying(255),
    phone_number character varying(255)
);

--history which book was taken by whom and when
CREATE TABLE IF NOT EXISTS tbl_history (
    id serial PRIMARY KEY,
    book_id integer NOT NULL,
    customer_id integer NOT NULL,
    quantity integer NOT NULL DEFAULT 1,
    date date NOT NULL DEFAULT CURRENT_DATE,
    direction character varying(3) NOT NULL,
    CHECK (direction in ('IN', 'OUT')),
    FOREIGN KEY (book_id) REFERENCES tbl_books(id),
    FOREIGN KEY (customer_id) REFERENCES tbl_customers(id)
);

CREATE INDEX IF NOT EXISTS tbl_history_books_id ON tbl_history(book_id);
CREATE INDEX IF NOT EXISTS tbl_history_customer_id ON tbl_history(customer_id);