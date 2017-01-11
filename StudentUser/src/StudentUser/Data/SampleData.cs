using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using StudentUser.Models;

namespace StudentUser.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    FirstName = "Stephan",
                    LastName ="Malther",
                    Age = 40,
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    FirstName = "Mike",
                    LastName = "Coder",
                    Age = 28,
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }
            var programming = new Course
            {
                Name = "programming",
                Description = " Course for crazy poeple",
                Days = "EveryDay",
                Instructor = "Josh",
                Loction = "Phoenix"
            };
                

           

            if (!context.Course.Any())
            {
                context.Course.Add(programming);
                context.SaveChanges();   
            }
            var mikeProgramming = new UserCourse
            {
                UserId = mike.Id,
                CourseId = programming.Id
            };

            if (!context.UserCourse.Any())
            {
                context.UserCourse.Add(mikeProgramming);
                context.SaveChanges();
            }
            
        }

    }
}
