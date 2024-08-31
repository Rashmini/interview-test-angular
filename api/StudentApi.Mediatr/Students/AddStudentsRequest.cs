using StudentApi.Models.Students;
using StudentApi.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class AddStudentRequest : IRequest<AddStudentResponse>
    {
        public Student Student { get; set; }
    }

    public class AddStudentResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Student Student { get; set; }
    }

    public class AddStudentHandler : IRequestHandler<AddStudentRequest, AddStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public AddStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<AddStudentResponse> Handle(AddStudentRequest request, CancellationToken cancellationToken)
        {
            var student = request.Student;

            // Check if all required fields are present
            if (student == null || 
                string.IsNullOrEmpty(student.FirstName) ||
                string.IsNullOrEmpty(student.LastName) ||
                string.IsNullOrEmpty(student.Email) ||
                string.IsNullOrEmpty(student.Major))
            {
                return Task.FromResult(new AddStudentResponse
                {
                    Success = false,
                    Message = "Invalid student data. All fields are required."
                });
            }

            // Add student
            var success = _studentsService.AddStudent(student);

            var response = new AddStudentResponse
            {
                Success = success,
                Message = success ? "Student added successfully!" : "Failed to add student!",
                Student = success ? student : null
            };

            return Task.FromResult(response);
        }
    }
}
