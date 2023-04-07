CREATE TABLE IF NOT EXISTS tbl_products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price MONEY NOT NULL,
    description TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS tbl_customers (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    phone_number VARCHAR(255) NOT NULL,
    address VARCHAR(1000) NOT NULL
);
CREATE TABLE IF NOT EXISTS tbl_employees (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    salary MONEY NOT NULL
);
CREATE TABLE IF NOT EXISTS tbl_orders (
    id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL,
    employee_id INTEGER NOT NULL,
    order_date TIMESTAMP NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES tbl_customers(id),
    FOREIGN KEY (employee_id) REFERENCES tbl_employees(id)
);
CREATE TABLE IF NOT EXISTS tbl_orders_products (
    id SERIAL PRIMARY KEY,
    order_id INTEGER NOT NULL,
    product_id INTEGER NOT NULL,
    FOREIGN KEY (order_id) REFERENCES tbl_orders(id),
    FOREIGN KEY (product_id) REFERENCES tbl_products(id)
);