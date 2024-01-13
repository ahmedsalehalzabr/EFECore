// See https://aka.ms/new-console-template for more information
using EFEClore;
using EFEClore.Models;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();

//اضافة لقاعدةة البيانات
var department = new Department()
{
    Name = "Ahmed 02",
    des="1234"
};
var context = new ValidationContext(department);
var errors = new List<ValidationResult>();
if(!Validator.TryValidateObject(department, context, errors, true))
{
foreach(var validationResult in errors)
    {
        Console.WriteLine(validationResult);
    }
}
else
{
    db.Departments.Add(department);
    db.SaveChanges();

}
