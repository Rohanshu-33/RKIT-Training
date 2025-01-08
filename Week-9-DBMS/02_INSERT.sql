INSERT INTO Students (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address)
VALUES 
('John', 'Doe', '2001-05-15', 'Male', '9876543210', '123 Elm Street'),
('Jane', 'Smith', '2000-08-22', 'Female', '8765432109', '456 Oak Avenue'),
('Alex', 'Johnson', '1999-12-01', 'Others', '7654321098', '789 Pine Road'),
('Emily', 'Brown', '2002-03-10', 'Female', '6543210987', '101 Maple Drive'),
('Michael', 'Davis', '2001-11-20', 'Male', '5432109876', '202 Birch Lane');


INSERT INTO Departments (DepartmentName, DepartmentHead)
VALUES 
('Computer Science', 'Dr. Alice Walker'),
('Mathematics', 'Dr. Bob Martin'),
('Physics', 'Dr. Carol Taylor'),
('Chemistry', 'Dr. David Wilson'),
('Biology', 'Dr. Emma Moore');


INSERT INTO Courses (CourseName, CourseCode, Credits, DepartmentId)
VALUES 
('Data Structures', 'CS101', 3, 1),
('Linear Algebra', 'MA201', 4, 2),
('Quantum Mechanics', 'PH301', 4, 3),
('Organic Chemistry', 'CH401', 3, 4),
('Molecular Biology', 'BI501', 3, 5);


INSERT INTO Instructors (FirstName, LastName, PhoneNumber, HireDate, DepartmentId)
VALUES 
('Alice', 'Walker', '9123456789', '2015-06-15', 1),
('Bob', 'Martin', '9345678123', '2017-08-20', 2),
('Carol', 'Taylor', '9456781234', '2019-09-12', 3),
('David', 'Wilson', '9567812345', '2016-04-25', 4),
('Emma', 'Moore', '9678123456', '2020-01-10', 5);


INSERT INTO InstructorCourses (InstructorId, CourseId)
VALUES 
(1, 1), -- Alice teaches Data Structures
(2, 2), -- Bob teaches Linear Algebra
(3, 3), -- Carol teaches Quantum Mechanics
(4, 4), -- David teaches Organic Chemistry
(5, 5), -- Emma teaches Molecular Biology
(1, 3), -- Alice teaches Quantum Mechanics
(4, 2); -- David teaches Linear Algebra 


INSERT INTO StudentCourses (StudentId, CourseId, Grade, YearOfPassing)
VALUES 
(1, 1, 'A', '2023-05-15'),
(2, 2, 'B', '2023-05-15'),
(3, 3, 'A', '2023-05-15'),
(4, 4, 'C', '2023-05-15'),
(5, 5, 'B', '2023-05-15'),
(1, 2, 'B', '2023-05-15'),
(3, 2, 'A', '2023-05-15');

-- other ways to insert in table
INSERT INTO students (id, first_name, last_name)
VALUES (1, 'John', 'Doe')
ON DUPLICATE KEY UPDATE first_name = 'John', last_name = 'Doe';

# if exists with id=1, then replaced with new values, else new row is inserted.
REPLACE INTO students (id, first_name, last_name)
VALUES (1, 'John', 'Doe');
