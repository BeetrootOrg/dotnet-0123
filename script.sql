CREATE TABLE IF NOT EXISTS tbl_phone_book (
	id BIGSERIAL PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	phone VARCHAR(15) NOT NULL,
	email VARCHAR(100)NOT NULL
)

CREATE TABLE IF NOT EXISTS tbl_school_schedule (
	id BIGSERIAL PRIMARY KEY,
	day VARCHAR(50) NOT NULL,
	class_room VARCHAR(50) NOT NULL,
	lesson VARCHAR(50) NOT NULL,
	start_lesson TIME NOT NULL,
	end_lesson TIME NOT NULL
)

CREATE TABLE IF NOT EXISTS tbl_login_history (
	id BIGSERIAL PRIMARY KEY,
	user_login VARCHAR(100) NOT NULL,
	user_email VARCHAR(100) NOT NULL,
	login_time TIMESTAMP NOT NULL,
    logout_time TIMESTAMP NOT NULL
)

CREATE TABLE IF NOT EXISTS tbl_bank_accounts (
	id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	birthday DATE NOT NULL CHECK(birthday > '1900-01-01'),
	phone VARCHAR(15) NOT NULL,
   	balance MONEY NOT NULL
)

CREATE TABLE IF NOT EXISTS tbl_bank_transactions (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    account_number BIGINT NOT NULL,
    date TIMESTAMP NOT NULL,
    type VARCHAR(50) NOT NULL,
    amount MONEY NOT NULL,
    description VARCHAR(50) NOT NULL
)