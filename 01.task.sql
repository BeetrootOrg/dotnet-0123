CREATE TABLE IF NOT EXISTS tbl_author
(
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_book
(
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author_id BIGSERIAL NOT NULL, 
	genre VARCHAR(255) NOT NULL,
    year TIMESTAMP NOT NULL,
	
    FOREIGN KEY (author_id) REFERENCES tbl_author(id)
);

CREATE TABLE IF NOT EXISTS tbl_customer 
(
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    phone VARCHAR(12) NOT NULL,
    address VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_orders (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    customer_id BIGINT NOT NULL,
    book_id BIGINT NOT NULL,
    taken_date TIMESTAMP NOT NULL,
    back_date TIMESTAMP NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES tbl_customer(id),
    FOREIGN KEY (book_id) REFERENCES tbl_book(id)
);

SELECT COUNT(title), title
FROM tbl_book
GROUP BY title;