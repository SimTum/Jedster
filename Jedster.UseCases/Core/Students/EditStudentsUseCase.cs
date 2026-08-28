using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Students;

public class EditStudentsUseCase(IStudentRepository studentRepository) : IEditStudentsUseCase
{
    public async Task ExecuteAsync(Student student)
    {
        await studentRepository.EditStudentAsyc(student);
    }
}