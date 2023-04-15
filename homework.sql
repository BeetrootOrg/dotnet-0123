-- Homework SQL DDL
-- Create few tables schemas:
--     table for ‘phone book’
--     table to store school schedule
--     table to store user’s login history
--     table to store bank accounts
--     table to store bank transactions data

--1 table for ‘phone book’
CREATE TABLE IF NOT EXISTS tbl_phone_book
(
    Id BIGSERIAL PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    phone VARCHAR(12) NOT NULL
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