CREATE DATABASE library_domain;

CREATE TABLE IF NOT EXISTS tbl_authors(
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    second_name VARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL CHECK(date_of_birth < NOW()),
    date_of_death DATE CHECK(date_of_death > date_of_birth)
);

CREATE TABLE IF NOT EXISTS tbl_books(
    id SERIAL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    isbn VARCHAR(13) NOT NULL,
    author_id INT NOT NULL,
    FOREIGN KEY (author_id) REFERENCES tbl_authors(id)
);

CREATE TABLE IF NOT EXISTS tbl_customers(
    email VARCHAR(300) PRIMARY KEY,
    first_name VARCHAR(100) NOT NULL,
    second_name VARCHAR(100) NOT NULL,
    address VARCHAR(300),
    phone_number VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS tbl_orders(
    id SERIAL PRIMARY KEY,
    take_date TIMESTAMP NOT NULL CHECK(take_date <= NOW()),
    return_date TIMESTAMP NOT NULL CHECK(
        return_date >= take_date
        AND return_date <= NOW()
    ),
    book_id INT NOT NULL,
    customer_email VARCHAR(300) NOT NULL,
    FOREIGN KEY (book_id) REFERENCES tbl_books(id),
    FOREIGN KEY (customer_email) REFERENCES tbl_customers(email)
);

CREATE INDEX IF NOT EXISTS tbl_books_author_id ON tbl_books(author_id);

CREATE INDEX IF NOT EXISTS tbl_orders_book_id ON tbl_orders(book_id);

CREATE INDEX IF NOT EXISTS tbl_orders_customer_email ON tbl_orders(customer_email);