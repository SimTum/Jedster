using Jedster.CoreBusiness;

namespace Jedster.UseCases.Students;

public interface IViewStudentsUseCase
{
    Task<IEnumerable<Student>> ExecuteAsync(string studentName = "");
    Task<Student> ExecuteAsync(int studentId);
}