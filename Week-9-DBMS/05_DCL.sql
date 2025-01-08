# Data Control Language

# 1) Check users

SELECT * FROM mysql.user where User="rohanshu";

# 2) Create new user

CREATE USER 'rohanshu'@'localhost' IDENTIFIED BY 'root@123';

# 3) Grant

GRANT ALL PRIVILEGES
ON rbcollege.*
TO 'rohanshu'@'localhost';

GRANT SELECT, INSERT
ON rbcollege.*
TO 'rohanshu'@'localhost';

GRANT SELECT(Id, FirstName), INSERT(Id)
ON rbcollege.students
TO 'rohanshu'@'localhost';

# 4) Revoke

REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'rohanshu'@'localhost';

REVOKE SELECT, INSERT
ON rbcollege.students
FROM 'rohanshu'@'localhost';

SHOW GRANTS FOR 'rohanshu'@'localhost';