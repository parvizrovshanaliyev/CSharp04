using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.StudentManagement;

/// <summary>
/// Contact details of a student such as email, phone, and address.
/// </summary>
public partial class Student
{
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}
