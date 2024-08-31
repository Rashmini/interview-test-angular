using StudentApi.Models.Students;
using StudentApi.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Students
{
    public class DeleteStudentRequest : IRequest<DeleteStudentResponse>
    {
        public Student Student {get; set;}
    }

    public class DeleteStudentResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequest, DeleteStudentResponse>
    {
        private readonly IStudentsService _studentsService;

        public DeleteStudentHandler(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        public Task<DeleteStudentResponse> Handle(DeleteStudentRequest request, CancellationToken cancellationToken)
        {
            // Delete student
            var success = _studentsService.DeleteStudent(request.Student);
            return Task.FromResult(new DeleteStudentResponse
            {
                Success = success,
                Message = success? "Student deleted successfully!" : "Failed to delete student!"
            });
        }
    }
}
