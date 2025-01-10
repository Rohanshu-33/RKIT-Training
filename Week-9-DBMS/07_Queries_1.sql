# LIKE

SELECT
	FirstName, Gender
FROM
	students
WHERE
	FirstName LIKE 'Joh_';  # single occurence match

SELECT
	FirstName, Gender
FROM
	students
WHERE
	FirstName LIKE 'J%';   # multiple occurence match


# Aggregate queries - COUNT, SUM, AVG, MAX, MIN

# count number of instructors in each department
SELECT
	DepartmentId, COUNT(Id) as TotalInstructors
FROM
	instructors
GROUP BY
	DepartmentId;

# sum of salary overall
SELECT
	SUM(salary) AS Salary
FROM
	instructors;

# high paying instructors
SELECT
	*
FROM
	instructors
WHERE
	salary = (SELECT MAX(salary) FROM instructors);

# low paying instructors
SELECT
	*
FROM
	instructors
WHERE
	salary = (
		SELECT
			MIN(salary)
		FROM
			Instructors
		);

# avg of salary of all instructors
SELECT
	AVG(salary) AS AVG_Salary
FROM
	instructors;


# Joins

# retrieve head of dept for each instructor
SELECT
	i.FirstName, i.LastName, d.DepartmentHead, d.DepartmentName
FROM
	instructors AS i
INNER JOIN
	departments AS d
ON
	i.DepartmentId = d.Id;

# get all courses and their department names, including courses that do not belong to any department
SELECT
	CourseName, DepartmentName
FROM
	courses
LEFT JOIN
	departments
ON
	courses.DepartmentId = departments.Id;

# get all departments and the courses they offer, including departments with no courses
SELECT
	CourseName, DepartmentName
FROM
	courses
RIGHT JOIN
	departments
ON
	courses.DepartmentId = departments.Id;

# get all courses and departments, including unmatched records from both:
SELECT
	CourseName, DepartmentName
FROM
	courses
LEFT JOIN
	departments
ON
	courses.DepartmentId = departments.Id
    
UNION   # UNION removes duplicates, UNION ALL keeps them

SELECT
	CourseName, DepartmentName
FROM
	courses
RIGHT JOIN
	departments
ON
	courses.DepartmentId = departments.Id;


# get all possible combinations of students and courses
SELECT
	*
FROM
	students 
CROSS JOIN
	courses;


# get students, the courses they are enrolled in, and the departments offering those courses
SELECT
	FirstName, LastName, CourseName, DepartmentName
FROM
	students
INNER JOIN
	studentcourses
ON
	students.Id = studentcourses.StudentId
INNER JOIN
	courses
ON
	courses.Id = studentcourses.CourseId
INNER JOIN
	departments
ON
	courses.DepartmentId = departments.Id;