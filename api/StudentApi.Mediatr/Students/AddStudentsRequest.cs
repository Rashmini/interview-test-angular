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
            // Add a student
            var success = _studentsService.AddStudent(request.Student);

            var response = new AddStudentResponse
            {
                Success = success,
                Message = success ? "Student added successfully!" : "Failed to add student!"
            };

            return Task.FromResult(response);
        }
    }
}
