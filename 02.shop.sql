CREATE TABLE IF NOT EXISTS tbl_shop(
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price MONEY NOT NULL CHECK(price > 0::money),
    description TEXT NOT NULL,
    createdAt TIMESTAMP NOT NULL DEFAULT NOW(),
    quantity INT NOT NULL CHECK(quantity >= 0)
);
-- add column unit
ALTER TABLE tbl_shop
ADD COLUMN unit SMALLINT NOT NULL DEFAULT 0 CHECK (
        unit >= 0
        AND unit <= 1
    );
-- change column quantity type
ALTER TABLE tbl_shop
ALTER COLUMN quantity TYPE NUMERIC(7, 3);
-- delete quantity check contraint
ALTER TABLE tbl_shop DROP CONSTRAINT tbl_shop_quantity_check;
-- add quantity check contraint
ALTER TABLE tbl_shop
ADD CONSTRAINT tbl_shop_quantity_check CHECK (
        quantity >= 0
        AND (
            unit <> 0
            OR quantity % 1 = 0
        )
    );