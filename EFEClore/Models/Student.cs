using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEClore.Models
{
    //عمل الاندكس يساعد على الوصول الى البيانات في قاعدة البيانات
    //[Index("Name")]
    //[Index("Name", "Email")]لاكثر من فلد
    // عمل اندكس يونيك يعني فريد ماينفش يتكرر الاسم في الجداول 
    //[Index("Name", IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public DateTime Birthday { get; set; }

        public Grade grade { get; set; }

        [ForeignKey("department")]
        public int departmentId { get; set;}
        public Department department { get; set; }

        //علاقة مني
        public ICollection<StudentBook> Books { get; set; }
        // عندما اريد ربط جدول ومايكونش موجود في الداتابيس يوجد طريقتين 1. فلونت اي بي أي 2.الداتا انتيشن
        //1.Fluent api   2. Data Entition
        //هنا طريقة الداتا انتيشن
        // [NotMapped]
        public ICollection<Attendence> attendences { get; set; }
    }
}
