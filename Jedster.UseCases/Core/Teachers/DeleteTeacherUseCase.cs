using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Teachers.Interfaces;

namespace Jedster.UseCases.Teachers;

public class DeleteTeacherUseCase (ITeacherRepository teacherRepository) : IDeleteTeacherUseCase
{
    public async Task ExecuteAsync(int id)
    {
        await teacherRepository.DeleteTeacherByIdAsync(id);
    } 
}