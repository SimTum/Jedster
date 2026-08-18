using Jedster.CoreBuisness;
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
                TeacherId = 1, Name = "Simon Tumanov", Email = "Simon@mail.com", RG = "Simon's_Doc", 
                BirthDate = (new DateOnly(2000,08,11)), CPF = "718.542.131-48", 
                Hours = 20, HoursWeighed = 26
            },
            new Teacher
            {
                TeacherId = 2, Name = "Laura Albuquerque", Email = "Laura@mail.com", RG = "Laura's_Doc", 
                BirthDate = (new DateOnly(1999,03,01)), CPF = "111.111.111-11", 
                Hours = 30, HoursWeighed = 30
            },
            new Teacher
            {
                TeacherId = 3, Name = "Cody Capatch", Email = "Cody@mail.com", RG = "Simon's_Doc", 
                BirthDate = (new DateOnly(1825,05,29)), CPF = "222.222.222-22", 
                Hours = 12, HoursWeighed = 15
            },
            new Teacher
            {
                TeacherId = 3, Name = "Jhonny", Email = "Jhonny@mail.com", RG = "Jhonny's_Doc", 
                BirthDate = (new DateOnly(
                    2003,04,12)), CPF = "333.333.333-33", 
                Hours = 18, HoursWeighed = 21
            }
            
        };
    }

    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_teachers);

        return _teachers.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
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

    public Task DeleteTeacherByIdAsync(int id)
    {
        var teacherToDelete = _teachers.FirstOrDefault(x => x.TeacherId == id);
        
        if (teacherToDelete is not null)
        {
            _teachers.Remove(teacherToDelete);
        } 
        return Task.CompletedTask;
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