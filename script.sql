CREATE DATABASE library;
CREATE TABLE IF NOT EXISTS tbl_authors (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    death_date DATE
);
CREATE TABLE IF NOT EXISTS tbl_books (
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author_id BIGINT NOT NULL,
    total_count INT NOT NULL,
    CONSTRAINT fk_author_id FOREIGN KEY (author_id) REFERENCES tbl_authors(id)
);
CREATE INDEX IF NOT EXISTS idx_author_id ON tbl_books(author_id);
CREATE TABLE IF NOT EXISTS tbl_customers (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    address VARCHAR(255) NOT NULL,
    phone VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);
CREATE TABLE IF NOT EXISTS tbl_history (
    id BIGSERIAL PRIMARY KEY,
    book_id BIGINT NOT NULL,
    customer_id BIGINT NOT NULL,
    borrow_date TIMESTAMP NOT NULL,
    return_date TIMESTAMP,
    CONSTRAINT fk_book_id FOREIGN KEY (book_id) REFERENCES tbl_books(id),
    CONSTRAINT fk_customer_id FOREIGN KEY (customer_id) REFERENCES tbl_customers(id)
);
CREATE INDEX IF NOT EXISTS idx_book_id ON tbl_history(book_id);
CREATE INDEX IF NOT EXISTS idx_customer_id ON tbl_history(customer_id);
INSERT INTO tbl_authors (name, surname, birth_date, death_date)
VALUES (
        'William',
        'Shakespeare',
        '1564-04-26',
        '1616-04-23'
    ),
    (
        'Charles',
        'Dickens',
        '1812-02-07',
        '1870-06-09'
    ),
    (
        'Jane',
        'Austen',
        '1775-12-16',
        '1817-07-18'
    );
INSERT INTO tbl_books (title, author_id, total_count)
VALUES ('Hamlet', 1, 10),
    (
        'Romeo and Juliet',
        1,
        10
    ),
    ('Macbeth', 1, 10),
    (
        'A Tale Of Two Cities',
        2,
        10
    ),
    (
        'Oliver Twist',
        2,
        10
    ),
    (
        'Christmas Carol',
        2,
        10
    ),
    (
        'Pride and Prejudice',
        3,
        10
    ),
    (
        'Sense and Sensibility',
        3,
        10
    ),
    ('Emma', 3, 10);
INSERT INTO tbl_customers (name, surname, birth_date, address, phone, email)
VALUES (
        'John',
        'Doe',
        '1990-01-01',
        '123 Main Street',
        '123-456-7890',
        'johndoe@gmail.com'
    ),
    (
        'Jane',
        'Doe',
        '1990-01-01',
        '123 Main Street',
        '123-456-7890',
        'janedoe@gmail.com'
    );
INSERT INTO tbl_history (book_id, customer_id, borrow_date, return_date)
VALUES(
        1,
        1,
        '2020-01-01 00:00:00',
        '2020-01-02 00:00:00'
    ),
    (
        2,
        1,
        '2020-01-01 00:00:00',
        NULL
    );
SELECT b.id,
    b.title,
    b.author_id,
    b.total_count - (
        SELECT COUNT(1)
        FROM tbl_history
        WHERE book_id = b.id
            AND return_date IS NULL
    ) AS remaining_count
FROM tbl_books AS b;