# backup

# mysqldump -u root -p college > CollegeDbBackup.sql
# mysqldump -u root -p college students courses > SpecificTables_backup.sql
# mysqldump -u root -p --no-data college > SchemaOnly_backup.sql   ---> without data

SELECT * FROM students INTO OUTFILE 'C:\\ProgramData\\MySQL\\MySQL Server 8.0\\Uploads\\Students_backup.csv' 
FIELDS TERMINATED BY ',' ENCLOSED BY '"' LINES TERMINATED BY '\n';

# allowed paths for backup
SHOW VARIABLES LIKE 'secure_file_priv';

# for custom path, comment below lines in my.cnf file or my.ini file and restart mysql server
-- [mysqld]
-- secure-file-priv=""


# restore

# mysql -u root -p TargetDBName < CollegeDbBackup.sql   --> target dbase must exist or else cretae db then command this

LOAD DATA INFILE '/path/to/backup/Students_backup.csv' 
INTO TABLE students
FIELDS TERMINATED BY ',' ENCLOSED BY '"' LINES TERMINATED BY '\n';

