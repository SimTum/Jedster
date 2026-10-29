using System;
using Jedster.CoreBusiness;

namespace Jedster.UseCases.Professores.Interfaces;


public interface IRegisterTeacherUsecase
{
    Task ExecuteAsync(Teacher teacher);
}
