using System;
using Jedster.CoreBuisness;

namespace Jedster.UseCases.Professores;

public interface IViewTeacherUseCase
{
    Task<IEnumerable<Teacher>> ExecuteAsync(string name = " ");
}