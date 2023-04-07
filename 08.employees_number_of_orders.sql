SELECT e.id,
    SUM(1) - COALESCE(
        (
            SELECT SUM(1)
            FROM tbl_orders AS o2
                RIGHT JOIN tbl_employees AS e2 ON o2.employee_id = e2.id
            WHERE e2.id = e.id
                AND o2.Id IS NULL
            GROUP BY e2.id
        ),
        0
    ) AS sum_orders
FROM tbl_orders AS o
    RIGHT JOIN tbl_employees AS e ON o.employee_id = e.id
GROUP BY e.id;