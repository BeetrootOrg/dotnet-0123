SELECT first_name,
    last_name,
    age
FROM tbl_persons
WHERE gender = 'M';
SELECT *
FROM tbl_persons
WHERE age >= 18
    AND age <= 30;
SELECT *
FROM tbl_persons
WHERE NOT(
        age >= 18
        AND age <= 30
    );
SELECT *
FROM tbl_persons
WHERE age < 18
    OR age > 30;
SELECT *
FROM tbl_persons
WHERE address IS NULL;
SELECT *
FROM tbl_persons
WHERE address IS NOT NULL;
SELECT COUNT(1) AS count_persons
FROM tbl_persons;
SELECT COUNT(1) AS count_persons
FROM tbl_persons
WHERE age >= 18
    AND age <= 30;
SELECT COUNT(1),
    last_name
FROM tbl_persons
GROUP BY last_name;
SELECT MAX(age) AS max_age,
    last_name
FROM tbl_persons
GROUP BY last_name;
SELECT AVG(age) AS avg_age,
    last_name
FROM tbl_persons
GROUP BY last_name
HAVING AVG(age) > 30
ORDER BY avg_age DESC;
SELECT COUNT(1),
    age
FROM tbl_persons
GROUP BY age
HAVING COUNT(1) > 1;