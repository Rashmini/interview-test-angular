﻿using StudentApi.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.Services
{
    public class StudentsService : IStudentsService
    {
        public List<Student> students = new List<Student>();

        public StudentsService()
        {
            students.Add(new Student
            {
                FirstName = "Marty",
                LastName = "McFly",
                Email = "back.future@test.com",
                Major = "History",
                AverageGrade = 85
            });

            students.Add(new Student {
                FirstName = "Emmett",
                LastName = "Brown",
                Email = "dr.brown@test.com",
                Major = "Physics",
                AverageGrade = 56
            });

            students.Add(new Student
            {
                FirstName = "Biff",
                LastName = "Tannen",
                Email = "biff@test.com",
                Major = "PE",
                AverageGrade = 28
            });
        }

        /// <summary>
        /// Adds a new student to the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool AddStudent(Student student)
        {       
            if (students.Any(s => s.Email == student.Email))
            {
                return false;
            }
                 
            students.Add(student);
            return true;
        }

        /// <summary>
        /// removes a student from the system
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool DeleteStudent(Student student)
        {
            var deletingStudent = students.FirstOrDefault(s => s.Email == student.Email);

            if (deletingStudent != null)
            {
                students.Remove(deletingStudent);
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Returns all of the students currently in the system
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
}
