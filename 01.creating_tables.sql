
CREATE TABLE IF NOT EXISTS tbl_authors
(
    id SERIAL PRIMARY KEY,
	first_name VARCHAR(100) DEFAULT 'UNKNOWN',
	last_name VARCHAR(100) DEFAULT 'UNKNOWN'
);

CREATE TABLE IF NOT EXISTS tbl_books
(
    id SERIAL PRIMARY KEY,
	isbn INTEGER NOT NULL,
    title VARCHAR(100) NOT NULL,
	author_id INTEGER NOT NULL, 
	publish_year DATE CHECK(publish_year < CURRENT_DATE), 
	FOREIGN KEY (author_id) REFERENCES tbl_authors(id)
);

CREATE TABLE IF NOT EXISTS tbl_customers 
(
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone_number VARCHAR(255) NOT NULL,
    address VARCHAR(1000) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_counting 
(
    id SERIAL PRIMARY KEY,
	book_id INTEGER NOT NULL,
	customer_id INTEGER NOT NULL,
	issue_date TIMESTAMP NOT NULL,
	return_date TIMESTAMP NOT NULL CHECK(issue_date < return_date),
	FOREIGN KEY (book_id) REFERENCES tbl_books(id),
	FOREIGN KEY (customer_id) REFERENCES tbl_customers(id)
);

CREATE INDEX IF NOT EXISTS tbl_books_author_id ON tbl_books(author_id);
CREATE INDEX IF NOT EXISTS tbl_counting_book_id ON tbl_counting(book_id);
CREATE INDEX IF NOT EXISTS tbl_authors_customer_id ON tbl_counting(customer_id)