using Microsoft.Build.Framework;
using Nest;
using aspcore7mvc.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore7mvc.Models.Domain
{
    public class PersonLocation
    {
        public int Id { get; set; }
        [Required]
        public string? LocationName { get; set; }
        [Required]
        
        public int  PersonID { get; set; }
        [ForeignKey("PersonID")]
        public DateTime LocDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModifiedAt { get; set;}
        public Person  Name { get; set; }
        //public string Person Name { get; set; }
    }
}
