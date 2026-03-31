using System;
using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using Jedster.UseCases.Professores.Interfaces;

namespace Jedster.UseCases.Professores;

public class RegisterTeacherUsecase : IRegisterTeacherUsecase
{
    private readonly ITeacherRepository teacherRepository;
    public RegisterTeacherUsecase(ITeacherRepository teacherRepository)

    {
        this.teacherRepository = teacherRepository;
    }
    public async Task ExecuteAsync(Teacher teacher)
    {
        await this.teacherRepository.RegisterTeacherAsync(teacher);
    }
}
