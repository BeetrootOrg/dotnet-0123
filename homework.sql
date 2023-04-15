-- Homework 29-Key Index SQL DDL
--Create normalized tables for the library domain. it should include:
--    books
--    authors
--    count of each book
--    customers
--    history which book was taken by whom and when

--1 table book
CREATE TABLE IF NOT EXISTS tbl_book
(
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    author_id SERIAL NOT NULL, 
    year TIMESTAMP NOT NULL,
    FOREIGN KEY (author_id) REFERENCES tbl_author(id)
);

--2 table authors
CREATE TABLE IF NOT EXISTS tbl_author
(
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    birthday TIMESTAMP NOT Null
);

--4 table customers
CREATE TABLE IF NOT EXISTS tbl_customer
(
    id BIGSERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    adress VARCHAR(255) NOT NULL,
    phone VARCHAR(15) NOT NULL,
    birthday TIMESTAMP NOT Null
);


--2 table to store school schedule
CREATE TABLE IF NOT EXISTS tbl_school_schedule 
(
    Id SMALLSERIAL PRIMARY KEY,
    DayCode SMALLINT NOT NULL,
    StartLesson TIME NOT NULL,
    EndLesson TIME NOT NULL,
    Lesson VARCHAR(100) NOT NULL
);
--3 table to store user’s login history
CREATE TABLE IF NOT EXISTS tbl_users_login_history
(
    Id BIGSERIAL PRIMARY KEY,
    UserLogin VARCHAR(100) NOT NULL,
    LoginAt TIMESTAMP NOT NULL DEFAULT now()
); 

--4 table to store bank accounts
CREATE TABLE IF NOT EXISTS tbl_bank_account
(
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Account VARCHAR(100) NOT NULL,
    OwnerData VARCHAR(500) NOT NULL,
    CreateAt TIMESTAMP NOT NULL DEFAULT now(),
    Balance MONEY NOT NULL
);

--5  table to store bank transactions data
CREATE TABLE IF NOT EXISTS tbl_bank_transactions_data
(
    Id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    Account UUID NOT NULL,
    DebitCredit boolean Not Null, 
    Summ MONEY NOT NULL,
    CreateAt TIMESTAMP NOT NULL DEFAULT now()
);