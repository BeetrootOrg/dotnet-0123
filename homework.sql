-- 1. Table for ‘phone book’
CREATE TABLE IF NOT EXISTS tbl_phone_book (
    id serial PRIMARY KEY,
    code_country character varying(5),
    phone_number character varying(15),
    first_name character varying(255) NOT NULL,
    last_name character varying(255),
    created_at timestamp without time zone DEFAULT now(),
	UNIQUE (code_country, phone_number)
);

-- 2. Table to store school schedule
CREATE TABLE IF NOT EXISTS tbl_school_schedule (
    id serial PRIMARY KEY,
    date date NOT NULL,
    start time NOT NULL,
    finish time NOT NULL,
    room character varying(255) NOT NULL,
    subject character varying(255) NOT NULL,
    teacher character varying(255) NOT NULL,
    UNIQUE(date, start, finish, room),
	CHECK (start < finish)
);

-- 3. Table to store user’s login history
CREATE TABLE IF NOT EXISTS tbl_users_login_history (
    id serial PRIMARY KEY,
    user_name character varying(255),
    is_logged boolean NOT NULL,
    date_time timestamp with time zone NOT NULL DEFAULT now(),
    created_at timestamp without time zone NOT NULL DEFAULT now()
);

-- 4. Table to store bank accounts
CREATE TABLE IF NOT EXISTS tbl_bank_accounts (
    id bigserial PRIMARY KEY,
    account_number character varying(255) NOT NULL,
    currency_name character varying(32) NOT NULL,
    amount numeric(15,5) NOT NULL DEFAULT 0,
    first_name character varying(255) NOT NULL,
    second_name character varying(255),
    surname character varying(255),
    is_blocked boolean NOT NULL DEFAULT false,
	is_actual boolean NOT NULL,
    date_opened timestamp,
    date_closed timestamp,
    created_at timestamp NOT NULL DEFAULT now(),
	UNIQUE (account_number)
);

-- 5. Table to store bank transactions data
CREATE TABLE IF NOT EXISTS tbl_bank_transactions (
    id bigserial PRIMARY KEY,
    account_number_sender character varying(255) NOT NULL,
    account_number_receiver character varying(255) NOT NULL,
    currency_name character varying(32) NOT NULL,
    amount numeric(15,5),
	is_success boolean NOT NULL DEFAULT true,
    created_at timestamp without time zone NOT NULL DEFAULT now(),
	CHECK (account_number_sender <> account_number_receiver AND amount > 0)
)