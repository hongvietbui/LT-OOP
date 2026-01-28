using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private List<Student> _students = new List<Student>();

    // Create
    public void AddStudent(Student student)
    {
        if (_students.Any(s => s.Id == student.Id))
        {
            throw new ArgumentException("ID sinh viên đã tồn tại!");
        }
        _students.Add(student);
    }

    // Read 
    public List<Student> GetAll()
    {
        return _students.OrderBy(s => s.Id).ToList(); 
    }

    // Tìm kiếm theo ID
    public Student FindById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    // Update
    public bool UpdateStudent(int id, string newName, int newAge, double newGpa)
    {
        var student = FindById(id);
        if (student == null) return false;

        student.Name = newName;
        student.Age = newAge;
        student.GPA = newGpa;
        return true;
    }

    // Delete
    public bool DeleteStudent(int id)
    {
        var student = FindById(id);
        if (student == null) return false;

        _students.Remove(student);
        return true;
    }

    // Tìm kiếm theo tên
    public List<Student> SearchByName(string keyword)
    {
        return _students
            .Where(s => s.Name.ToLower().Contains(keyword.ToLower()))
            .ToList();
    }
}