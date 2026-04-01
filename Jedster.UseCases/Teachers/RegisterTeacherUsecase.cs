using System;
using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores.Interfaces;

namespace Jedster.UseCases.Teachers;

public class RegisterTeacherUsecase : IRegisterTeacherUsecase
{
    private readonly ITeacherRepository _teacherRepository;
    public RegisterTeacherUsecase(ITeacherRepository teacherRepository)

    {
        this._teacherRepository = teacherRepository;
    }
    public async Task ExecuteAsync(Teacher teacher)
    {
        await this._teacherRepository.RegisterTeacherAsync(teacher);
    }
}
