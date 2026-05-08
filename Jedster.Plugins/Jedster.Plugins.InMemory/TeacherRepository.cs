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

    public async Task<Teacher?>
        GetTeacherByIdAsync(int id)
    {
        if (_teachers.Any(x => x.TeacherId == id))
        {
            return await Task.FromResult(_teachers.FirstOrDefault(x => x.TeacherId == id));
        }
        else
        {
            return null;
        }
    }

    public Task RegisterTeacherAsync(Teacher teacher)
    {
        if (_teachers.Any(x => x.Name.Equals(teacher.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxId = _teachers.Max(x => x.TeacherId);
        teacher.TeacherId = maxId + 1;

        _teachers.Add(teacher);
        return Task.CompletedTask;
    }

    public Task EditTeacherAsync(Teacher teacher)
    {
        if (_teachers.Any(x =>
                x.Name.Equals(teacher.Name, StringComparison.OrdinalIgnoreCase) && x.TeacherId != teacher.TeacherId))
            return Task.CompletedTask;

        var teacherToUpdate = _teachers.FirstOrDefault(x => x.TeacherId == teacher.TeacherId);
        if (teacherToUpdate is not null)
        {
            teacherToUpdate.Name = teacher.Name;
            teacherToUpdate.Email = teacher.Email;
        }

        return Task.CompletedTask;
    }
}