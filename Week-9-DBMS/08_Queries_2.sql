# subqueries

# get name of students enrolled in courses having max credits
SELECT
	FirstName, LastName
FROM
	students
WHERE
	Id IN (
		SELECT
			StudentId
		FROM
			studentcourses
		WHERE
			CourseId
		IN (
			SELECT
				Id
			FROM
				courses
			WHERE
				Credits = (
					SELECT
						MAX(Credits)
					FROM
						courses
                        )
			)
		);

# alternate to above
SELECT DISTINCT
    s.StudentId
FROM
    studentcourses AS s
        INNER JOIN
    courses AS c ON s.CourseId = c.Id
WHERE
    c.Credits = (SELECT 
            MAX(Credits)
        FROM
            courses);

# give details of departments that have no instructors yet.
SELECT
	*
FROM
	departments
WHERE
	Id
NOT IN (
	SELECT DISTINCT
		DepartmentId
	FROM
		instructors
	);



# view

# create view to get instructor info along with courses they teach.
# firstname, lastname, coursename
CREATE VIEW InstructorCourseDetails AS
SELECT FirstName, LastName, CourseName
FROM instructors
INNER JOIN teaches
ON instructors.Id = teaches.InstructorId
INNER JOIN courses
ON courses.Id = teaches.CourseId;

SELECT * FROM InstructorCourseDetails;
DROP VIEW InstructorCourseDetails;



# index

SHOW INDEX FROM students;
CREATE INDEX LastNameIndex ON students(LastName);
CREATE UNIQUE INDEX FirstNameIndex ON students(FirstName);
DROP INDEX FirstNameIndex ON students;

-- types of indexing: primary (primary key), unique, composite, spatial, regular, fulltext


-- Revisit topics:

use rbcollege;
CREATE TABLE IF NOT EXISTS RBC01(
	C01F01 int primary key,
    C01F02 text,
    C01F03 decimal(10, 2)
);

SELECT C01F01, C01F02, C01F03 FROM RBC01;

insert into RBC01 values(1, "rohanshu", 45000.00),
(2, "navneet", 25000.99),
(3, "meet", null);

# if, if null
select C01F02 as username, ifnull(C01F03, 0) as C01F03 from RBC01;
select C01F02 as username, if(C01F03 is null, 0, C01F03) as salary from RBC01;
select C01F02 as username, if(C01F03 is not null, C01F03, 0) as salary from RBC01;

# is null, is not null
select C01F02 from RBC01 where C01F03 is null;
select C01F02 from RBC01 where C01F03 is not null;
