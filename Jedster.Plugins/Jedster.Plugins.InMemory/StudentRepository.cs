using System;
using System.Reflection.Metadata;
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class StudentRepository : IStudentRepository
{
    private List<Student> _students;

    public StudentRepository()
    {
        _students = new List<Student>
        {
            new Student
            {
                StudentId = 1, RG = "Document", GroupId = 1, CPF = "11122233344", Name = "Name1",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1, 
                Contract = new Contract()
                {
                    ContractId = 1, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 1
                }
            },
            new Student
            {
                StudentId = 2, RG = "Document", GroupId = 1, CPF = "11122233344", Name = "Name2",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1, 
                Contract = new Contract()
                {
                    ContractId = 2, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 2
                }
            },
            new Student
            {
                StudentId = 3, RG = "Document", GroupId = 1, CPF = "11122233344", Name = "Name3",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1, 
                Contract = new Contract()
                {
                    ContractId = 3, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 3
                }
            },
            new Student
            {
                StudentId = 4, RG = "Document", GroupId = 2, CPF = "11122233344", Name = "Name4",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 4, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 4
                }
            },
            new Student
            {
                StudentId = 5, RG = "Document", GroupId = 2, CPF = "11122233344", Name = "Name5",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId =5, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 5
                }
            },
            new Student
            {
                StudentId = 6, RG = "Document", GroupId = 3, CPF = "11122233344", Name = "Name6",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 6, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 6
                }
            },
            new Student
            {
                StudentId = 7, RG = "Document", GroupId = 3, CPF = "11122233344", Name = "Name7",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 7, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 7
                }
            },
            new Student
            {
                StudentId = 8, RG = "Document", GroupId = 3, CPF = "11122233344", Name = "Name8",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 8, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 8
                }
            },
            new Student
            {
                StudentId = 9, RG = "Document", GroupId = 3, CPF = "11122233344", Name = "Name9",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 9, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 9
                }
            },
            new Student
            {
                StudentId = 10, RG = "Document", GroupId = 3, CPF = "11122233344", Name = "Name10",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 10, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 10
                }
            },
            new Student
            {
                StudentId = 11, RG = "Document", GroupId = 4, CPF = "11122233344", Name = "Name11",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 11, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 11
                }
            },
            new Student
            {
                StudentId = 12, RG = "Document", GroupId = 4, CPF = "11122233344", Name = "Name12",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 12, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 12
                }
            },
            new Student
            {
                StudentId = 13, RG = "Document", GroupId = 4, CPF = "11122233344", Name = "Name13",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 13, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 13
                }
            },
            new Student
            {
                StudentId = 14, RG = "Document", GroupId = 5, CPF = "11122233344", Name = "Name14",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 14, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 14
                }
            },
            new Student
            {
                StudentId = 15, RG = "Document", GroupId = 5, CPF = "11122233344", Name = "Name15",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 15, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 15
                }
            },
            new Student
            {
                StudentId = 16, RG = "Document", GroupId = 5, CPF = "11122233344", Name = "Name16",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 16, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 16
                }
            },
            new Student
            {
                StudentId = 17, RG = "Document", GroupId = 6, CPF = "11122233344", Name = "Name17",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 17, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 17
                }
            },
            new Student
            {
                StudentId = 18, RG = "Document", GroupId = 6, CPF = "11122233344", Name = "Name18",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 18, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 18
                }
            },
            new Student
            {
                StudentId = 19, RG = "Document", GroupId = 6, CPF = "11122233344", Name = "Name19",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 19, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 19
                }
            },
            new Student
            {
                StudentId = 20, RG = "Document", GroupId = 7, CPF = "11122233344", Name = "Name20",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 20, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 20
                }
            },
            new Student
            {
                StudentId = 21, RG = "Document", GroupId = 7, CPF = "11122233344", Name = "Name21",
                BirthDate = new DateOnly(2000, 01, 02),
                TextbookId = 1,
                Contract = new Contract()
                {
                    ContractId = 21, HoursRemaining = 40, HoursMissed = 0, HoursCompleted = 0, StudentId = 21
                }
            }
        };
    }

    public async Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
    {
        if (string.IsNullOrEmpty(name)) return await Task.FromResult(_students);

        return _students.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        if (_students.Any(x => x.StudentId == studentId))
            return await Task.FromResult(_students.FirstOrDefault(x => x.StudentId == studentId));
        else
        {
            return null;
        }
    }


    public Task EditStudentAsyc(Student student)
    {
        if (_students.Any(x =>
                x.Name.Equals(student.Name, StringComparison.OrdinalIgnoreCase) && x.StudentId != student.StudentId))
            return Task.CompletedTask;
        var studentToUpdate = _students.FirstOrDefault(x => x.StudentId == student.StudentId);
        if (studentToUpdate != null)
        {
            studentToUpdate.Name = student.Name;
            studentToUpdate.RG = student.RG;
            studentToUpdate.CPF = student.CPF;
            studentToUpdate.BirthDate = student.BirthDate;
            studentToUpdate.TextbookId = student.TextbookId;
            studentToUpdate.GroupId = student.GroupId;
        }

        return Task.CompletedTask;
    }

    public Task RegisterStudentAsync(Student student)
    {
        if (_students.Any(x => x.Name.Equals(student.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxId = _students.Max(x => x.StudentId);
        student.StudentId = maxId + 1;

        _students.Add(student);
        return Task.CompletedTask;
    }

    public Task DeleteStudenteById(int studentId)
    {
        var studentToDelete = _students.FirstOrDefault(x => x.StudentId == studentId);
        if (studentToDelete != null)
        {
            _students.Remove(studentToDelete);
        }

        return Task.CompletedTask; 
    }
}