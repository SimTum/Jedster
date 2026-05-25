using System;

namespace Jedster.CoreBusiness;

public class TeacherGroups
{
    public int TeacherId {get; set;}
    public int GroupId { get; set; }
    public Teacher? Teacher { get; set; }
    public IEnumerable<Group>? Groups { get; set; }
}
