CREATE DATABASE test;

-- table for ‘phone book’
CREATE TABLE IF NOT EXISTS tbl_phone_book(
    id SERIAL PRIMARY KEY,
    number VARCHAR(50) NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    second_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    email VARCHAR(150),
    company VARCHAR(100),
    birthday DATE CHECK(birthday > NOW())
)
ALTER TABLE
    tbl_phone_book DROP CONSTRAINT tbl_phone_book_birthday_check;

ALTER TABLE
    tbl_phone_book
ADD
    CONSTRAINT tbl_phone_book_birthday_check CHECK(birthday < NOW());

-- table to store school schedule
CREATE TABLE IF NOT EXISTS tbl_school_schedule(
    id SERIAL PRIMARY KEY,
    day_of_week VARCHAR(9) NOT NULL,
    subject VARCHAR(50) NOT NULL,
    start_time TIME NOT NULL CHECK(start_time < end_time),
    end_time TIME NOT NULL,
    classroom VARCHAR(25) NOT NULL
) -- table to store user’s login history
CREATE TABLE IF NOT EXISTS tbl_login_history(
    id SERIAL PRIMARY KEY,
    username VARCHAR(30) NOT NULL,
    login_time TIMESTAMP NOT NULL CHECK(login_time < NOW()),
    ip_adress VARCHAR(50) NOT NULL,
    browser VARCHAR(30) NOT NULL,
    device VARCHAR(50) NOT NULL
) -- table to store bank accounts
CREATE TABLE IF NOT EXISTS tbl_bank_accounts(
    account_number VARCHAR(12) UNIQUE PRIMARY KEY,
    balance MONEY NOT NULL CHECK(balance >= 0 :: money) DEFAULT 0,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    status VARCHAR(20) NOT NULL DEFAULT 'active',
    transaction_count INTEGER NOT NULL CHECK(transaction_count >= 0) DEFAULT 0
) -- table to store bank transactions data
CREATE TABLE IF NOT EXISTS tbl_bank_transactions(
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    from_acount_id VARCHAR(12) NOT NULL,
    to_account_id VARCHAR(12) NOT NULL,
    amount MONEY NOT NULL CHECK(amount > 0 :: money),
    created_at TIMESTAMP NOT NULL CHECK(created_at < NOW()),
    status VARCHAR(15) NOT NULL,
    description VARCHAR(300)
)