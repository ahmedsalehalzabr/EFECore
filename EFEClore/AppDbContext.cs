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
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Uniform> uniforms { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent api كتابة الاكواد هنا يعني طريقة

            //عمل الاندكس يساعد على الوصول الى البيانات بسرعة في قاعدة البيانات
            // modelBuilder.Entity<Student>().HasIndex(x => x.Name);
            //لاكثر من فلد
            // modelBuilder.Entity<Student>().HasIndex(x => new { x.Name , x.Email}); 
            //عمل اندكس يونيك يعني فريد ماينفش يتكرر الاسم في الجداول 
            // modelBuilder.Entity<Student>().HasIndex(x => x.Name).IsUnique();
            //اندكس مع تغيير الاسم والفلتره الفلتر يعني ابحث عن الاسماء الي لا تكون نل  
            modelBuilder.Entity<Student>().HasIndex(x => x.Name).IsUnique()
                .HasDatabaseName("IX-my-index")
                .HasFilter("Name is not null");

            //للتعديل في كل المقريشن تعديل طريقة الحذف كاسكيت او ريستركت
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            //عمليات 
            modelBuilder.Entity<Invoice>().Property(x => x.qty)
                        .HasDefaultValue(1);

            modelBuilder.Entity<Invoice>().Property(x => x.createDate)
                       .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Invoice>().Property(x => x.fullName)
                       .HasComputedColumnSql("[customerTitle] + ' ' +[customerName]");

            modelBuilder.Entity<Invoice>().Property(x => x.total)
                      .HasComputedColumnSql("[price] * [qty]");


            //عمل سكونس يعني تسلسل في الارقام في جدول او عدة جدول 
            modelBuilder.HasSequence<int>("DeliveryOrder")
                .StartsAt(101)
                .IncrementsBy(1);
            modelBuilder.Entity<Book>().Property(p => p.DeliveryOrder)
                .HasDefaultValueSql("Next Value For DeliveryOrder");
            modelBuilder.Entity<Uniform>().Property(p => p.DeliveryOrder)
                .HasDefaultValueSql("Next Value For DeliveryOrder"); 
        }


    }
}
