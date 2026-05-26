using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Students;

public class ViewStudentsUseCase(IStudentRepository studentRepository) : IViewStudentsUseCase
{
    public async Task<IEnumerable<Student>> ExecuteAsync(string studentName = "")
    {
        return await studentRepository.GetStudentsByNameAsync(studentName);
    }

    public async Task<Student> ExecuteAsync(int studentId)
    {
        return await studentRepository.GetStudentByIdAsync(studentId);
    }
}