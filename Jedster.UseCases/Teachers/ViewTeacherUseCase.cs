using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using System;
using System.Reflection.Metadata;
using Jedster.UseCases.Professores;

namespace Jedster.UseCases.Teachers;



public class ViewTeacherUseCase : IViewTeacherUseCase
{

    public readonly ITeacherRepository TeacherRepository;

    public ViewTeacherUseCase(ITeacherRepository teacherRepository)
    {
        this.TeacherRepository = teacherRepository;
    }
    public async Task<IEnumerable<Teacher>> ExecuteAsync(string name = " ")
    {
        return await TeacherRepository.GetTeachersByNameAsync(name);
    }

}
