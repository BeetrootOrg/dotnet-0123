SELECT to_char(order_date, 'YYYY-MM'),
    SUM(p.price)
FROM tbl_orders AS o
    JOIN tbl_orders_products AS op ON o.id = op.order_id
    JOIN tbl_products AS p ON op.product_id = p.id
GROUP BY to_char(order_date, 'YYYY-MM');
