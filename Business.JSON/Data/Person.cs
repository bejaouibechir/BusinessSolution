﻿using System;

namespace Business.JSON.Data
{
    public class Person
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int EmailPromotion { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;


    }
}
