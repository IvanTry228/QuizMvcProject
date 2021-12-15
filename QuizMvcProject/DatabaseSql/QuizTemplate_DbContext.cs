using DotNetExtra.QuizImplementation;
using Microsoft.EntityFrameworkCore;
using Quick_Quiz;
using System;
using System.Linq;

namespace QuizTemplateMvcDotnet6.DatabaseSql
{
    public class TestUserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class QuizTemplate_DbContext : DbContext
    {
        //public DbSet<TestUserEntity> TestUserEntitySet { get; set; }

        public DbSet<QuizPdd_Question> PddAllQuestions { get; set; }

        public DbSet<QuizPdd_Answer> PddAllAnswers { get; set; }

        public DbSet<QuizPdd_PictureeGetterUrl> PddAllPictureables { get; set; }

        public QuizTemplate_DbContext()
        {
            UpdateFillRelations();
            Console.WriteLine("QuizTemplate_DbContext successfullt created");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                SqlDbManager.sqlBuilderEntity.GetConnectionString(),
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizPdd_Question>()
                .HasMany(quest => quest.answersItemsList)
                .WithOne(answ => (QuizPdd_Question)answ.CurrentQuestion);

            modelBuilder.Entity<QuizPdd_Question>()
                .HasOne(quest => quest.currentIPictureGetterStringable)
                .WithOne(pictureUrl => pictureUrl.CurrentQuestion)
                .HasForeignKey<QuizPdd_PictureeGetterUrl>(pictureUrl => pictureUrl.currentQuestionId);

            //modelBuilder.Entity<Student>()
            //.HasOne<StudentAddress>(s => s.Address)
            //.WithOne(ad => ad.Student)
            //.HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);

            //modelBuilder.Entity<QuizPdd_Answer>()\
            //    .HasOne(a => a.)
            //    .WithMany(c => c.Users)
            //    .HasForeignKey(b => b.CompanyId);

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.Users)
            //    .WithOne(c => c.Company);

            //modelBuilder.Entity<Company>()
            //    .HasMany(p => p.Users).WithMany();
        }

        //test
        private void UpdateFillRelations()
        {
            PddAllQuestions.Include(c => c.answersItemsList).ToList();
            PddAllQuestions.Include(pict => pict.currentIPictureGetterStringable).ToList();

            //Companies.Include(c => c.Users).ToList();
        }
    }
}
