# Data Definition Language Queries

# 1) DESCRIBE
DESCRIBE students;

# ----------------------------------------

# 2) EXPLAIN
EXPLAIN SELECT * FROM courses WHERE Credits > 3 ORDER BY CourseName DESC;

# ----------------------------------------

# 3) CREATE - already done

# ----------------------------------------

# 4) ALTER

# 4.1 - add column
ALTER TABLE instructors ADD salary INT;

# 4.2 - modify column
ALTER TABLE instructors MODIFY salary FLOAT;

# 4.3 - rename column
ALTER TABLE students CHANGE DateOfBirth DOB DATE;

# 4.4 - drop a column
#ALTER TABLE instructors DROP COLUMN salary;

# 4.5 - add primary key
ALTER TABLE tbl_name ADD PRIMARY KEY (col_name);

# 4.6 - add unique
ALTER TABLE tbl_name ADD UNIQUE (col_name);

# 4.7 - add foreign key
ALTER TABLE tbl_name
ADD CONSTRAINT foreign_key_constraint_name  FOREIGN KEY (col_name)
REFERENCES tbl_name(col_name);

# 4.8 - drop primary key
ALTER TABLE tbl_name
DROP PRIMARY KEY;

# 4.9 - drop foreignn key
ALTER TABLE tbl_name
DROP FOREIGN KEY fkey_constraint_name;

# 4.10 - change table name
ALTER TABLE instructorcourses
RENAME TO teaches;

# ----------------------------------------

# 5) DROP - Permanently deletes table/database/view
DROP TABLE tbl_name;
DROP DATABASE dbase_name;
DROP VIEW view_name;

# ----------------------------------------


# 6) TRUNCATE - Removes all rows and reset autoincrement value. Preserve table structure.
TRUNCATE TABLE tbl_name;


