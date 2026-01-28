using System;
using System.Text;

class Program
{
    static StudentManager manager = new StudentManager();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; 
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== HỆ THỐNG QUẢN LÝ SINH VIÊN ===");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm theo ID");
            Console.WriteLine("4. Cập nhật thông tin");
            Console.WriteLine("5. Xóa sinh viên");
            Console.WriteLine("6. Tìm theo tên");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("----------------------------------");

            int choice = InputHelper.ReadInt("Chọn chức năng: ", 0, 6);

            switch (choice)
            {
                case 1: AddStudentUI(); break;
                case 2: ShowAllUI(); break;
                case 3: FindByIdUI(); break;
                case 4: UpdateUI(); break;
                case 5: DeleteUI(); break;
                case 6: SearchByNameUI(); break;
                case 0: exit = true; break;
            }

            if (!exit)
            {
                Console.WriteLine("\nẤn phím bất kỳ để quay lại menu...");
                Console.ReadKey();
            }
        }
    }

    static void AddStudentUI()
    {
        Console.WriteLine("\n--- THÊM SINH VIÊN MỚI ---");
        int id = InputHelper.ReadInt("Nhập ID: ", 1);

        if (manager.FindById(id) != null)
        {
            Console.WriteLine("Lỗi: ID này đã tồn tại!");
            return;
        }

        string name = InputHelper.ReadString("Nhập tên: ");
        int age = InputHelper.ReadInt("Nhập tuổi (18-100): ", 18, 100);
        double gpa = InputHelper.ReadDouble("Nhập GPA (0.0-4.0): ", 0, 4);

        try
        {
            manager.AddStudent(new Student(id, name, age, gpa));
            Console.WriteLine("Thêm thành công!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
    }

    static void ShowAllUI()
    {
        var list = manager.GetAll();
        DisplayList(list);
    }

    static void FindByIdUI()
    {
        int id = InputHelper.ReadInt("\nNhập ID cần tìm: ");
        var s = manager.FindById(id);
        if (s != null) Console.WriteLine(s);
        else Console.WriteLine("Không tìm thấy sinh viên!");
    }

    static void UpdateUI()
    {
        int id = InputHelper.ReadInt("\nNhập ID sinh viên cần sửa: ");
        var s = manager.FindById(id);
        if (s == null)
        {
            Console.WriteLine("Sinh viên không tồn tại.");
            return;
        }

        Console.WriteLine($"Đang sửa sinh viên: {s.Name}");
        string name = InputHelper.ReadString("Tên mới: ");
        int age = InputHelper.ReadInt("Tuổi mới: ", 18, 100);
        double gpa = InputHelper.ReadDouble("GPA mới: ", 0, 4);

        manager.UpdateStudent(id, name, age, gpa);
        Console.WriteLine("Cập nhật thành công!");
    }

    static void DeleteUI()
    {
        int id = InputHelper.ReadInt("\nNhập ID cần xóa: ");
        if (InputHelper.ReadString("Bạn chắc chắn muốn xóa? (y/n): ").ToLower() == "y")
        {
            if (manager.DeleteStudent(id)) Console.WriteLine("Đã xóa thành công.");
            else Console.WriteLine("Không tìm thấy ID để xóa.");
        }
    }

    static void SearchByNameUI()
    {
        string keyword = InputHelper.ReadString("\nNhập tên cần tìm: ");
        var list = manager.SearchByName(keyword);
        DisplayList(list);
    }

    static void DisplayList(System.Collections.Generic.List<Student> list)
    {
        Console.WriteLine("\n{0,-5} | {1,-20} | {2,-5} | {3,-5}", "ID", "Name", "Age", "GPA");
        Console.WriteLine(new string('-', 45));
        if (list.Count == 0) Console.WriteLine("Danh sách trống.");
        foreach (var s in list)
        {
            Console.WriteLine("{0,-5} | {1,-20} | {2,-5} | {3,-5:F2}", s.Id, s.Name, s.Age, s.GPA);
        }
    }
}