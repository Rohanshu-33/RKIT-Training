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
DROP INDEX LastNameIndex ON students;
