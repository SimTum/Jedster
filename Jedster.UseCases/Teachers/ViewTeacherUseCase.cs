using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using System;
using System.Reflection.Metadata;
using Jedster.UseCases.Professores;
using Jedster.UseCases.Teachers.Interfaces;

namespace Jedster.UseCases.Teachers;



public class ViewTeacherUseCase(ITeacherRepository teacherRepository) : IViewTeacherUseCase
{
    public async Task<IEnumerable<Teacher>> ExecuteAsync(string name = " ")
    {
        return await teacherRepository.GetTeachersByNameAsync(name);
    }

    public async Task<Teacher> ExecuteAsync(int id)
    {
        return await teacherRepository.GetTeacherByIdAsync(id);
    }

}
