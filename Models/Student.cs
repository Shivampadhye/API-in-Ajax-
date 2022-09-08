using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskWebAPI.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int16 Gender { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        //public DateTime? GetUpdatedDateTime()
        //{
        //    return updatedDateTime;
        //}

        //public void SetUpdatedDateTime(DateTime? value)
        //{
        //    updatedDateTime = value;
        //}
    }
}
