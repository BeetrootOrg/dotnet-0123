-- 01.1 create table to store customer information
CREATE TABLE IF NOT EXISTS tbl_customers (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    phone VARCHAR(12) NOT NULL,
    address VARCHAR(255) NOT NULL
);

-- 01.2 create table to store author information
CREATE TABLE IF NOT EXISTS tbl_authors (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    birth_year INT NOT NULL,
    death_year INT
);

-- 01.3 create table to store book information
CREATE TABLE IF NOT EXISTS tbl_books (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    isbn VARCHAR(13) NOT NULL,
    author_id BIGINT NOT NULL,
	amount INT NOT NULL,
	year INT NOT NULL,
    FOREIGN KEY (author_id) REFERENCES tbl_authors(id)
);

-- 01.4 create table to store order information
CREATE TABLE IF NOT EXISTS tbl_orders (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    customer_id BIGINT NOT NULL,
    book_id BIGINT NOT NULL,
    taken_date TIMESTAMP NOT NULL,
    return_date TIMESTAMP NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES tbl_customers(id),
    FOREIGN KEY (book_id) REFERENCES tbl_books(id)
);

-- 01.5 alter tbl_orders to return_date to be nullable
ALTER TABLE tbl_orders
ALTER COLUMN return_date DROP NOT NULL;


