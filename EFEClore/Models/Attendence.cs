using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEClore.Models
{
    //تغيير اسم الجدول وكذالك الاسكيما تبع الجدول بطريقة الانتيشن
    //[Table("StudentsAtts", Schema = "std")]
    public class Attendence
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        //تغيير اسم الكولوم وكذالك نوع الاسم بطريقة الانتيشن 
        //تغيير نوع الاسم int او string ينفع لاكن خطاء بيحصل تعارض في النوع في قاعدة البيانات
        //[Column("theName",TypeName = "varchar(20)")]
        public string? Name { get; set; }

        //علاقه ون 
        [ForeignKey("student")]
        public int studentId { get; set; }
        //عندما اريد ربط كولوم ومايكونش موجود في الداتابيس
        //[NotMapped]
        public DateTime theDate { get; set; }
        public Student student { get; set; }
        // عندما اريد ربط جدول ومايكونش موجود في الداتابيس يوجد طريقتين 1. فلونت اي بي أي 2. الداتا انتيشن 
        
    }
}
