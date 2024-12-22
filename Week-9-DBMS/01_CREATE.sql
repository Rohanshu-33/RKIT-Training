CREATE DATABASE IF NOT EXISTS College;

USE College;

CREATE TABLE Students(
	Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender ENUM("Male", "Female", "Others") NOT NULL,
    PhoneNumber VARCHAR(10) UNIQUE,
    Address VARCHAR(60) NOT NULL
);


CREATE TABLE Departments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(30) NOT NULL UNIQUE,
    DepartmentHead VARCHAR(30)
);

CREATE TABLE Courses (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CourseName VARCHAR(50) NOT NULL,
    CourseCode VARCHAR(5) UNIQUE NOT NULL,
    Credits INT NOT NULL,
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) ON DELETE SET NULL
);


CREATE TABLE Instructors (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    PhoneNumber VARCHAR(10) UNIQUE,
    HireDate DATE NOT NULL,
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) ON DELETE SET NULL
);


CREATE TABLE InstructorCourses (
	Id INT AUTO_INCREMENT PRIMARY KEY, # composite primary key can't be made bcoz of referential constraint added
    InstructorId INT,
    CourseId INT NOT NULL,
    FOREIGN KEY (InstructorId) REFERENCES Instructors(Id) ON DELETE SET NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);


CREATE TABLE StudentCourses(
	StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    Grade VARCHAR(2),
    YearOfPassing DATE NOT NULL,
    PRIMARY KEY(StudentId, CourseId),
    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
);