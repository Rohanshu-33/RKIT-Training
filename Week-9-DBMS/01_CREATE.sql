CREATE DATABASE IF NOT EXISTS RBCollege;

USE RBCollege;

CREATE TABLE Students(
	Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender ENUM("Male", "Female", "Others") NOT NULL,
    PhoneNumber VARCHAR(10) UNIQUE,
    Address VARCHAR(60) NOT NULL
);

-- ALTER TABLE Students ADD UNIQUE (LastName);
# 2 column uniqueness using distinct, pagination, index, view, cursor, stored procedure, partition, isolated table

SELECT * FROM Students ORDER BY FirstName DESC, LastName DESC limit 2 offset 1;

-- pagination: 
-- FIRST 10 ROWS
SELECT * FROM Students LIMIT 0, 10;
-- NEXT 10 ROWS
SELECT * FROM Students LIMIT 10, 10;

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

SELECT CONCAT(DAY(HireDate),"-",MONTH(HireDate), "-", YEAR(HireDate)) AS DATEs FROM Instructors;


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


# The below is for DBMS CRUD in C# Advance API
CREATE TABLE IF NOT EXISTS Users(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(20) NOT NULL,
    Email VARCHAR(30) NOT NULL UNIQUE,
    Password VARCHAR(12) NOT NULL
);

USE rbcorefulldemo;
create database if not exists rbcorefulldemo;

CREATE TABLE IF NOT EXISTS USR01(
	P01F01 INT PRIMARY KEY,
    P01F02 VARCHAR(100) NOT NULL,
    P01F03 VARCHAR(16) NOT NULL,
    P01F04 INT NOT NULL,
    P01F05 DATE NOT NULL
);
select * from RST02;
select * from RST01;


show tables;
describe rst02;