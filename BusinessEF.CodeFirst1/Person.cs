namespace BusinessEF.CodeFirst1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persons")]
    public partial class Person
    {
        [Key]
        public int BusinessEntityID { get; set; }

        [Required]
        public string PersonType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MidlleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int EmailPromotion { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Persons_Employee Persons_Employee { get; set; }
    }
}
