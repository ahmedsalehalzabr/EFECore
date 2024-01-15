// See https://aka.ms/new-console-template for more information
using EFEClore;
using EFEClore.Models;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();
//اضافة الى قاعدة البيانات وعند كل عملية رن يضيف
var book = new Book()
{
    Name= "book 1",
    Author = "Author 1",
    Created = DateTime.Now,
};
  db.Books.Add(book);
  db.SaveChanges();

var uniform = new Uniform()
{
    Name = "book 1",
   
    Created = DateTime.Now,
};
db.uniforms.Add(uniform);
db.SaveChanges();


//اضافة لقاعدةة البيانات
//var department = new Department()
//{
//    Name = "Ahmed 02",
//    des="1234"
//};
//var context = new ValidationContext(department);
//var errors = new List<ValidationResult>();
//if(!Validator.TryValidateObject(department, context, errors, true))
//{
//foreach(var validationResult in errors)
//    {
//        Console.WriteLine(validationResult);
//    }
//}
//else
//{
//    db.Departments.Add(department);
//    db.SaveChanges();

//}

//هذا الامر في الباكج مانجر
// امر عمل اسكربت اس كيو ال سرفر لكل المقريشن  لحفظ نسخة او عمل بك اب 
//script-migration
//عمل اسكربت من اسم المقريشن المحدد ولكل الذي بعدها
// script-migration namemigration 
//عمل اسكربت محدد من مقريشن الى مقريشن اخر يعمل لكل الي وسط المحدد
//// script-migration namemigration1 namemigration2