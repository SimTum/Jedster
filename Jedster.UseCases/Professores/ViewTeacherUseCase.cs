using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using System;
using System.Reflection.Metadata;

namespace Jedster.UseCases.Professores;



public class ViewTeacherUseCase : IViewTeacherUseCase
{

    public readonly ITeacherRepository teacherRepository;

    public ViewTeacherUseCase(ITeacherRepository teacherRepository)
    {
        this.teacherRepository = teacherRepository;
    }
    public async Task<IEnumerable<Teacher>> ExecuteAsync(String name = " ")
    {
        return await teacherRepository.GetTeachersByNameAsync(name);
    }

}
