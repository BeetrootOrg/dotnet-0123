-- Homework 29-Key Index SQL DDL
--Create normalized tables for the library domain. it should include:
--    books
--    authors
--    count of each book
--    customers
--    history which book was taken by whom and when


--2 table authors
CREATE TABLE IF NOT EXISTS tbl_author
(
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    birthday TIMESTAMP NOT Null
);

--1 table book
CREATE TABLE IF NOT EXISTS tbl_book
(
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(500) NOT NULL,
    author_id SERIAL NOT NULL, 
    year TIMESTAMP NOT NULL,
    initialcount INT NOT NULL Default 1,
    availablecount INT ,
    borrowedcount INT,
    FOREIGN KEY (author_id) REFERENCES tbl_author(id)
);

--4 table customers
CREATE TABLE IF NOT EXISTS tbl_customer
(
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    adress VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    birthday TIMESTAMP NOT Null
);

--5 history which book was taken by whom and when
CREATE TABLE IF NOT EXISTS tbl_history
(
    id BIGSERIAL PRIMARY KEY,
    customer_id BIGSERIAL NOT NULL, 
    book_id BIGSERIAL NOT NULL, 
    taken TIMESTAMP NOT Null Default now(),
    returned TIMESTAMP,
    FOREIGN KEY (customer_id) REFERENCES tbl_customer(id),
    FOREIGN KEY (book_id) REFERENCES tbl_book(id)
);
--6 count of each book
UPDATE tbl_book
SET availablecount = initialcount - (SELECT COUNT(*) FROM tbl_history WHERE tbl_history.book_id = tbl_book.id AND tbl_history.returned IS NULL),
    borrowedcount = (SELECT COUNT(*) FROM tbl_history WHERE tbl_history.book_id = tbl_book.id AND tbl_history.returned IS NULL);
