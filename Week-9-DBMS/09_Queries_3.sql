# backup

# mysqldump -u root -p college > CollegeDbBackup.sql
# mysqldump -u root -p college students courses > SpecificTables_backup.sql
# mysqldump -u root -p --no-data college > SchemaOnly_backup.sql   ---> without data

SELECT * FROM students INTO OUTFILE '/path/to/backup/Students_backup.csv' 
FIELDS TERMINATED BY ',' ENCLOSED BY '"' LINES TERMINATED BY '\n';


# restore

# mysql -u root -p TargetDBName < CollegeDbBackup.sql   --> target dbase must exist or else cretae db then command this

LOAD DATA INFILE '/path/to/backup/Students_backup.csv' 
INTO TABLE students
FIELDS TERMINATED BY ',' ENCLOSED BY '"' LINES TERMINATED BY '\n';

