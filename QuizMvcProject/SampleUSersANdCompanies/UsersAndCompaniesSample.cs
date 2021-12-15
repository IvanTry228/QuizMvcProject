using DotNetExtra.CustomUtilities;
using DotNetExtra.QuizImplementation;
using Microsoft.EntityFrameworkCore;

namespace QuizTemplateMvcDotnet6.SampleUsersAndCompanies
{
    //public class UsersAndCompaniesSample
    //{
    //    public void CallTestLoad()
    //    {
    //        using (UsersCompaniesContext dbTest = new UsersCompaniesContext())
    //        {
    //            int countIncrementEmployers = 10;
    //            List<User> bufferEntities = new List<User>();

    //            for (int i = 0; i < countIncrementEmployers; i++)
    //            {
    //                User bufferUser = new User { Name = AllUsersNames.GetRandomName(), Company = ContextOpearionsExtensions.GetSelectRandom(dbTest.Companies) };
    //                bufferEntities.Add(bufferUser);
    //            }

    //            dbTest.Users.AddRange(bufferEntities);

    //            var randomCompany = dbTest.Companies.GetRandomItem();
    //            randomCompany.TestLogCompany();

    //            randomCompany = dbTest.Companies.GetRandomItem();
    //            randomCompany.TestLogCompany();

    //            dbTest.SaveChanges();
    //        }
    //    }
    //}

    //public class UsersCompaniesContext : DbContext //test
    //{
    //    //test 1
    //    public DbSet<Company> Companies { get; set; }
    //    public DbSet<User> Users { get; set; }
    //    //test 1

    //    public UsersCompaniesContext()
    //    {
    //        UpdateFillRelations();
    //        Console.WriteLine("DataBaseNewQuizContext successfullt created DataBaseContext");
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseMySql(
    //            CustomSqlConfig.mysqlstr + CustomSqlConfig.database_quiztest,
    //            new MySqlServerVersion(new Version(8, 0, 11))
    //        );
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<User>()
    //            .HasOne(u => u.Company)
    //            .WithMany(c => c.Users)
    //            .HasForeignKey(b => b.CompanyId);

    //        base.OnModelCreating(modelBuilder);

    //        //modelBuilder.Entity<Company>()
    //        //    .HasMany(c => c.Users)
    //        //    .WithOne(c => c.Company);

    //        //modelBuilder.Entity<Company>()
    //        //    .HasMany(p => p.Users).WithMany();
    //    }

    //    //test
    //    private void UpdateFillRelations()
    //    {
    //        Companies.Include(c => c.Users).ToList();
    //    }

    //    //test one-many
    //}

    //public class Company
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string GradleReview { get; set; }

    //    public virtual ICollection<User> Users { get; set; } = new List<User>();

    //    public void TestLogCompany()
    //    {
    //        string allUsers = "";
    //        foreach (var item in Users)
    //        {
    //            allUsers += item.Id + item.Name + " ";
    //        }

    //        Console.WriteLine("Company TestLogCompany Id = " + Id + Name + " Users.Count = " + Users.Count + " allUsers =" + allUsers);
    //    }
    //}

    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int CompanyId { get; set; }
    //    public Company Company { get; set; }
    //}

    //public class AllUsersNames
    //{
    //    public static readonly List<string> usersNamesAll = new List<string>()
    //    {
    //        "Tommy",
    //        "Jack",
    //        "Sanya",
    //        "Billy",
    //        "Larisa"
    //        };

    //    public static string GetRandomName()
    //    {
    //        return usersNamesAll.GetRandomItem();
    //    }
    //}

}