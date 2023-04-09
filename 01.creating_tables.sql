CREATE TABLE IF NOT EXISTS tbl_phonebook
(
    id BIGSERIAL PRIMARY KEY,
    firstname VARCHAR(100),
    lastname VARCHAR(100),
	country_code VARCHAR(4) NOT NULL CHECK(length(country_code) < 5),
	phone_number VARCHAR(10) NOT NULL CHECK(length(phone_number) = 10),
	UNIQUE (country_code, phone_number),
	CHECK (firstname IS NOT NULL OR lastname IS NOT NULL)
);

CREATE TABLE IF NOT EXISTS tbl_schedule
(
    id BIGSERIAL PRIMARY KEY,
    lesson_subject VARCHAR(100) DEFAULT 'LECTURE',
    lecturer VARCHAR(200) NOT NULL,
	lesson_start TIMESTAMP NOT NULL,
	lesson_end TIMESTAMP NOT NULL,
	CHECK (lesson_start < lesson_end),  
	UNIQUE (lecturer, lesson_start)
);

CREATE TABLE IF NOT EXISTS tbl_bank_accounts
(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	iban VARCHAR(34) NOT NULL UNIQUE, 
	account_holder VARCHAR(250) NOT NULL,
	opening_date TIMESTAMP NOT NULL CHECK(opening_date <= NOW()),
	balance MONEY NOT NULL CHECK(balance + credit_line >= 0::money),
	credit_line MONEY DEFAULT '0' CHECK(credit_line >= 0::money)
);

CREATE TABLE IF NOT EXISTS tbl_transactions
(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
	operation VARCHAR NOT NULL CHECK(operation = 'DEPOSIT' OR operation = 'WITHDROW'),
	counterparties VARCHAR(250) DEFAULT 'UNKNOWN',
	date TIMESTAMP NOT NULL CHECK(date <= NOW()),
	sum MONEY NOT NULL CHECK (sum > 0::money)
); 

CREATE TABLE IF NOT EXISTS tbl_login_history
(
    id BIGSERIAL PRIMARY KEY,
    browser VARCHAR(20) DEFAULT 'UNKNOWN',
	ipaddress VARCHAR(45) NOT NULL,
	date TIMESTAMP NOT NULL CHECK(date <= NOW()),
	type VARCHAR(6) CHECK (type = 'login' OR type = 'logout') 
);



