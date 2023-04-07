SELECT o.id,
    o.order_date,
    c.first_name,
    c.last_name,
    e.first_name,
    e.last_name
FROM tbl_orders AS o
    JOIN tbl_customers AS c ON o.customer_id = c.id
    JOIN tbl_employees AS e ON o.employee_id = e.id;