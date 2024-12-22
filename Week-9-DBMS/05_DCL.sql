# Data Control Language

# 1) Check users

SELECT * FROM mysql.user where User="rohanshu";

# 2) Create new user

CREATE USER 'rohanshu'@'localhost' IDENTIFIED BY 'root@123';

# 3) Grant

GRANT ALL PRIVILEGES
ON college.*
TO 'rohanshu'@'localhost';

GRANT SELECT, INSERT
ON college.*
TO 'rohanshu'@'localhost';

GRANT SELECT(Id, FirstName), INSERT(Id)
ON college.students
TO 'rohanshu'@'localhost';

# 4) Revoke

REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'rohanshu'@'localhost';

REVOKE SELECT, INSERT
ON college.students
FROM 'rohanshu'@'localhost';

SHOW GRANTS FOR 'rohanshu'@'localhost';