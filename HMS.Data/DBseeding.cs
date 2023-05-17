using HMS.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data
{
    public class DBseeding
    {


        public static async Task seed(IApplicationBuilder applicationBuilder)
        {
            using (var x = applicationBuilder.ApplicationServices.CreateScope())
            {
                var contex = x.ServiceProvider.GetService<HMSDbContext>();
                var userManager = x.ServiceProvider.GetService<UserManager<User>>();

                contex.Database.EnsureCreated();

                if (!contex.Users.Any())
                {
                    var user = new User
                    {
                        UserType = Core.Enums.UserType.Administrator,
                        Email = "admin@admin.com",
                        FullName = "sadeg ashour",
                        DOB = DateTime.Now,
                        PhoneNumber = "0592548224",
                        ImageUrl = null,
                        UserName = "admin@admin.com",
                    };
                    var passWord = "Sadeg$2001";
                    await userManager.CreateAsync(user, passWord);


                }
            }
        }
    }
}
