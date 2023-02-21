using System.Diagnostics;
using System.Net;

namespace BookLibrary.Models
{
    public class Seed
    {

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BookAppDbContext>();

                context!.Database.EnsureCreated();


                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            Name = "James Clear"
                        },
                        new Author()
                        {
                            Name = "Muhammad Salih Al-Munajjid"
                        },
                        new Author()
                        {
                            Name = "Ibrahim al-Sakran"
                        },
                        new Author() { 
                            Name = " Robert Kiyosaki"
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                           Name = "Atomic Habits",
                           Description = "James Clear, an expert on habit formation, reveals practical strategies that will teach you how to form good habits, break bad ones, and master the tiny behaviors that lead to remarkable results",
                           AuthorId = 1,   
                           category = Category.SelfHelp,
                        },
                        new Book()
                        {
                            Name = "مفسدات القلوب",
                            Description = "يتناول الكتب بعضا من مكائد الشيطان ابن آدم ليصده عن ذكر الله وطاعته وخشيته ويفسد عليه قلبه كاتباع اهوى والشهوة والغفلة والكبر والجدال بالباطل وحب الدنيا ...",
                            AuthorId = 2,
                            category = Category.SelfHelp,
                        },
                        new Book()
                        {
                            Name = "Another Book",
                            Description = "Another Description",
                            AuthorId = 3,
                            category = Category.Fantasy
                        },
                        new Book()
                        {
                            Name = "Poor Dad Rich Dad",
                            Description = "Rich Dad Poor Dad is a 1997 book written by Robert T. Kiyosaki and Sharon Lechter. It advocates the importance of financial literacy, financial independence and building wealth through investing in assets, real estate investing, starting and owning businesses, as well as increasing one's financial intelligence",
                            AuthorId = 4,
                            category = Category.Development
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
