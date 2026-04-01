using System;
using Jedster.CoreBuisness;

namespace Jedster.UseCases.Professores.Interfaces;


public interface IRegisterTeacherUsecase
{
    Task ExecuteAsync(Teacher teacher);
}
