using System;
using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores.Interfaces;

namespace Jedster.UseCases.Teachers;

public class RegisterTeacherUsecase(ITeacherRepository teacherRepository) : IRegisterTeacherUsecase
{
    public async Task ExecuteAsync(Teacher teacher)
    {
        await teacherRepository.RegisterTeacherAsync(teacher);
    }
}
