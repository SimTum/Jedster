using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Teachers.Interfaces;


namespace Jedster.UseCases.Teachers;

public class EditTeacherUseCase(ITeacherRepository teacherRepository) : IEditTeacherUseCase
{
    public async Task ExecuteAsync(Teacher teacher)
    {
        await teacherRepository.EditTeacherAsync(teacher);
    }
    
}