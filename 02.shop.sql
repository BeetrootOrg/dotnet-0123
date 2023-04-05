CREATE TABLE IF NOT EXISTS tbl_shop(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price MONEY NOT NULL CHECK(price > 0::money),
    description TEXT NOT NULL,
    createdAt TIMESTAMP NOT NULL DEFAULT NOW(),
    quantity INT NOT NULL CHECK(quantity >= 0)
);