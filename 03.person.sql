CREATE TABLE IF NOT EXISTS tbl_persons (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    createdAt TIMESTAMP NOT NULL DEFAULT NOW(),
    updatedAt TIMESTAMP
);

-- change column name from createdAt to created_at
ALTER TABLE tbl_persons RENAME COLUMN createdAt TO created_at;

-- change column name from updatedAt to updated_at
ALTER TABLE tbl_persons RENAME COLUMN updatedAt TO updated_at;

-- add column age
ALTER TABLE tbl_persons ADD COLUMN IF NOT EXISTS age INT NOT NULL DEFAULT 0;

-- drop default contraint on age
ALTER TABLE tbl_persons ALTER COLUMN age DROP DEFAULT;

-- update first_name & last_name type
ALTER TABLE tbl_persons ALTER COLUMN first_name TYPE VARCHAR(100);
ALTER TABLE tbl_persons ALTER COLUMN last_name TYPE VARCHAR(100);