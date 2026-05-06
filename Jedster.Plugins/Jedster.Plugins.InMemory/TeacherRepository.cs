using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class TeacherRepository : ITeacherRepository
{
    private List<Teacher> _teachers;


    public TeacherRepository()
    {
        _teachers = new List<Teacher>
        {
            new Teacher
            {
                TeacherId = 1, Name = "Simon Tumanov", Email = "Simon@mail.com", Hours = 0
            },
            new Teacher
            {
                TeacherId = 2, Name = "Laura Albuquerque", Email = "Laura@mail.com", Hours = 0
            },
            new Teacher
            {
                TeacherId = 3, Name = "Cody Capatch", Email = "Cody@mail.com", Hours = 0
            }
        };
    }

    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_teachers);

        return _teachers.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task RegisterTeacherAsync(Teacher teacher)
    {
        if (_teachers.Any(x => x.Name.Equals(teacher.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxID = _teachers.Max(x => x.TeacherId);
        teacher.TeacherId = maxID + 1;

        _teachers.Add(teacher);
        return Task.CompletedTask;

    }

    public Task UpdateTeacherAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}

