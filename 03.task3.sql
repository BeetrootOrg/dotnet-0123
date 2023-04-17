CREATE TABLE IF NOT EXISTS tbl_users_login_history
(
    Id BIGSERIAL PRIMARY KEY,
    login VARCHAR(255) NOT NULL,
	password VARCHAR(255) NOT NULL,
    login_time TIMESTAMP NOT NULL
); 