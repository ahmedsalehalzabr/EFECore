// See https://aka.ms/new-console-template for more information
using EFEClore;
using EFEClore.Models;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();

//اضافة لقاعدةة البيانات
//var department = new Department()
//{
//    Name = "Ahmed"
//};

//db.Departments.Add(department);
//db.SaveChanges();

// تعديل او تعديل الاسم رقم 1
var department = db.Departments.Find(1);

if (department != null)
{
    Console.WriteLine(department.Name);

    //تعديل
    //department.Name = "Class 1";
    //db.SaveChanges();

   
    //حذف 
    db.Departments.Remove(department);
    db.SaveChanges();
}
else
{
    Console.WriteLine("Nothing");
}