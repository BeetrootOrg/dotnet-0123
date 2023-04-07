SELECT o.id,
    o.order_date,
    c.first_name AS customer_first_name,
    c.last_name AS customer_last_name,
    e.first_name AS employee_first_name,
    e.last_name AS employee_last_name
FROM tbl_orders AS o
    LEFT JOIN tbl_customers AS c ON o.customer_id = c.id
    LEFT JOIN tbl_employees AS e ON o.employee_id = e.id
ORDER BY o.order_date;