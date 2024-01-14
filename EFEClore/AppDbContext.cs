using EFEClore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEClore
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connections.sqlConStr);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<StudentBook> StudentBooks { get; set; }
        public DbSet<Attendence> attendences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent api كتابة الاكواد هنا يعني طريقة


            //للتعديل في بعض المقريشن بالاكواد بدل التعديل اليدوي داخل المقريشن
            //modelBuilder.Entity<Department>()
            //    .HasMany(p => p.Students)
            //    .WithOne(c => c.department)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Student>()
            //   .HasOne(s => s.grade)
            //   .WithOne(g => g.student)
            //   .OnDelete(DeleteBehavior.SetNull);

            //للتعديل في كل المقريشن تعديل طريقة الحذف كاسكيت او ريستركت
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //عندما اريد ربط جدول ومايكونش موجود في الداتابيس يوجد طريقتين 1. فلونت اي بي أي 2. الداتا انتيشن
            //هنا طريقه رقم 1
            //modelBuilder.Ignore<Attendence>();

            //اذا كنت اريد اعرف جدول انو معايا مثلا جدول الاتنتينس احذف تعريفه في جدول الاستيودنت
            //هذا محذوف public ICollection<Attendence> attendences { get; set; }
            // اعمل هنا
            // modelBuilder.Entity<Attendence>();

            //اذا انت تريد تعمل تعديلات هنا وميتعدلش في الداتا بيس اعمل كذا
            // modelBuilder.Entity<Attendence>().ToTable("NameTable", a => a.ExcludeFromMigrations());

            //تغيير اسم الجدول وكذالك الاسكيما
            modelBuilder.Entity<Attendence>().ToTable("newTableName", "newScemaName");

            //تغيير اسم الكولوم وكذالك نوع الاسم 
            modelBuilder.Entity<Attendence>().Property(x => x.Name)
                .HasColumnName("newName")
                .HasColumnType("varchar(50)");
            //عندما اريد ربط كولوم ومايكونش موجود في الداتابيس
            modelBuilder.Entity<Attendence>().Ignore(x => x.theDate);
        }


    }
}
