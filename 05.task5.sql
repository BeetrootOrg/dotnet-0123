CREATE TABLE IF NOT EXISTS tbl_bank_transactions_data
(
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    accaunt_from UUID NOT NULL,
	accaunt_to UUID NOT NULL,
	balance MONEY NOT NULL,
    operation_date TIMESTAMP NOT NULL
);