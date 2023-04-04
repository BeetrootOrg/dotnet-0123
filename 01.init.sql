CREATE DATABASE books;

-- Initial database creation script
CREATE TABLE IF NOT EXISTS tbl_books 
(
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    isbn VARCHAR(255) NOT NULL,
    year INT NOT NULL
);