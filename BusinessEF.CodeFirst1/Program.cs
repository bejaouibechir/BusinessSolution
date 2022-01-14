using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEF.CodeFirst1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CodeFirstModel context = new CodeFirstModel();
            context.Persons.Add(new Person
            {
                PersonType = "kklk ",
                FirstName = "lkl ",
                LastName = "lkl ",
                EmailPromotion = 1,
                MidlleName = "klk ",
                Title = "lkl",
                ModifiedDate = new DateTime(2022, 1, 14)
            });
            context.SaveChanges();
        }
    }
}
