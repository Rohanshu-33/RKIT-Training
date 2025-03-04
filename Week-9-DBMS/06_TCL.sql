# Transaction Control Language

# to make the transaction not to modify anything
SET TRANSACTION READ ONLY;
SET TRANSACTION READ WRITE;

-- SET autocommit = 0;
START TRANSACTION;

UPDATE instructors
SET salary = salary*1.2
WHERE TIMESTAMPDIFF(YEAR, HireDate, CURDATE()) > 8;

SAVEPOINT update_1;

UPDATE instructors
SET salary = salary*1.5
WHERE TIMESTAMPDIFF(YEAR, HireDate, CURDATE()) > 10;

SAVEPOINT update_2;

RELEASE SAVEPOINT update_2;

#ROLLBACK TO update_1;
COMMIT;

