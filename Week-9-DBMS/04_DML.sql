# Data Manipulation Language Queries

# 1) UPDATE

# affects to all the rows
# below don't work in safe mode because there is no WHERE statement with key as parameter.
# in safe mode, you cannot update a table without specifying primary key in WHERE statement
UPDATE instructors
SET salary = 55000;

# disable safe mode
SET SQL_SAFE_UPDATES = 0;

# enable safe mode
SET SQL_SAFE_UPDATES = 1;


# limit query

UPDATE instructors
SET salary = 45000
WHERE DepartmentId > 2
LIMIT 3;


# update using switch case

UPDATE instructors
SET salary = CASE
    WHEN TIMESTAMPDIFF(YEAR, HireDate, CURDATE()) >= 7 THEN salary * 1.4
    WHEN TIMESTAMPDIFF(YEAR, HireDate, CURDATE()) BETWEEN 4 AND 6 THEN salary * 1.2
    ELSE salary
END;

# ------------------------------------------

# 2) DELETE

# delete all rows

DELETE FROM tbl_name;

# delete rows with condition

DELETE FROM instructors WHERE salary > 1000000;

# delete duplicate rows from a table

DELETE i1
FROM instructors i1
JOIN instructors i2
ON i1.PhoneNumber = i2.PhoneNumber AND i1.Id > i2.Id;
# Id with large value will be deleted (if auto increment then duplicate data will have higher id.)

# ------------------------------------------

# 3) MERGE

# merging 2 tables

INSERT INTO students (student_id, name, age, score)
SELECT student_id, name, age, score
FROM new_students
WHERE student_id NOT IN (SELECT student_id FROM students);

# ------------------------------------------

# 4) INSERT - already done
