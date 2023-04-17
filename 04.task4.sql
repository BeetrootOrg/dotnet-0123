CREATE TABLE IF NOT EXISTS tbl_bank_account
(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    username VARCHAR(255) NOT NULL,
	city VARCHAR(255) NOT NULL,
    balance MONEY NOT NULL
);