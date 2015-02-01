using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace DataAccess
{
    public class DbInitializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            GetGenders().ForEach(g => context.Genders.Add(g));
        }

        private static List<Gender> GetGenders()
        {
            return new List<Gender>
            {
                new Gender {
                    ID = 1,
                    Name = "Male"
                },
                new Gender {
                    ID = 2,
                    Name = "Female"
                }
            };
        }
    }
}
