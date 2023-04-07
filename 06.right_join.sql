SELECT c.id,
    c.first_name,
    c.last_name
FROM tbl_orders AS o
    RIGHT JOIN tbl_customers AS c ON o.customer_id = c.id
WHERE o.id IS NULL;