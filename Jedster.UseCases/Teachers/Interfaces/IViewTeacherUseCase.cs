using System;
using Jedster.CoreBusiness;

namespace Jedster.UseCases.Professores;

public interface IViewTeacherUseCase
{
    Task<IEnumerable<Teacher>> ExecuteAsync(string name = " ");
}