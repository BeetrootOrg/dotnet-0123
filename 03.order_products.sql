SELECT o.id,
    p.name,
    p.price,
    p.description
FROM tbl_orders_products AS op
    JOIN tbl_orders AS o ON op.order_id = o.id
    JOIN tbl_products AS p ON op.product_id = p.id;