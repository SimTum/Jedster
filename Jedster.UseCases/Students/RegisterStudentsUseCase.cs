using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Students;

public class RegisterStudentsUseCase(IStudentRepository studentRepository) : IRegisterStudentsUseCase
{
    public async Task ExecuteAsync(Student student)
    {
        await studentRepository.RegisterStudentAsync(student);
    }
}