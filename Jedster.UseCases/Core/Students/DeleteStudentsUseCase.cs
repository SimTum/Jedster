using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Students.Interfaces;

public class DeleteStudentsUseCase(IStudentRepository studentRepository) : IDeleteStudentsUseCase
{
    public async Task ExecuteAsync(int studentId)
    {
        await studentRepository.DeleteStudenteById(studentId);
    }  
}