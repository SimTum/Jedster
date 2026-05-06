using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Teachers.Interfaces;


namespace Jedster.UseCases.Teachers;

public class EditTeacherUseCase : IEditTeacherUseCase
{
    private readonly ITeacherRepository teacherRepository;

    public EditTeacherUseCase(ITeacherRepository teacherRepository)
    {
        this.teacherRepository = teacherRepository;
    }

    public async Task ExecuteAsync(Teacher teacher)
    {
        await this.teacherRepository.UpdateTeacherAsync(teacher);
    }

    public Task<Teacher> ExecuteAsync(int id)
    {
        throw new NotImplementedException();
    }
}