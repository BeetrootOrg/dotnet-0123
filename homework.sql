-- 01. Create table for ‘phone book’
CREATE TABLE IF NOT EXISTS tbl_phone_book (
    id BIGSERIAL NOT NULL ,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone VARCHAR(12) NOT NULL,
    email VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

-- 02. Create table to store school schedule
CREATE TABLE IF NOT EXISTS tbl_school_schedule (
    id BIGSERIAL NOT NULL,
    class_name VARCHAR(50) NOT NULL,
    class_time TIMESTAMP NOT NULL,
    class_room VARCHAR(50) NOT NULL,
    teacher_name VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

--03. Create table to store user’s login history
CREATE TABLE IF NOT EXISTS tbl_login_history (
    id BIGSERIAL NOT NULL,
    user_nickname VARCHAR(50) NOT NULL,
    user_email VARCHAR(50) NOT NULL,
    login_time TIMESTAMP NOT NULL,
    logout_time TIMESTAMP NOT NULL,
    PRIMARY KEY (id)
);

-- 04. Create table to store bank accounts
CREATE TABLE IF NOT EXISTS tbl_bank_accounts (
    id BIGSERIAL NOT NULL,
    account_number BIGINT NOT NULL,
    account_owner_first_name VARCHAR(50) NOT NULL,
    account_owner_last_name VARCHAR(50) NOT NULL,
    account_balance MONEY NOT NULL,
    PRIMARY KEY (id)
);

-- 05. Create table to store bank transactions data
CREATE TABLE IF NOT EXISTS tbl_bank_transactions (
    id BIGSERIAL NOT NULL,
    account_number BIGINT NOT NULL,
    transaction_date TIMESTAMP NOT NULL,
    transaction_type VARCHAR(50) NOT NULL,
    transaction_amount MONEY NOT NULL,
    transaction_description VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);