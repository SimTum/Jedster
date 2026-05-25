using System;

namespace Jedster.CoreBusiness;

public class GroupStudents
{
    public int GroupId {get; set;}
    public Group? Group { get; set; }
    public int StudentId {get; set;}
    public IEnumerable<Student>? Students {  get; set; } 
}
