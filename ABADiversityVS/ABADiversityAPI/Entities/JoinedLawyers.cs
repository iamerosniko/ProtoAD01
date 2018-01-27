using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_JoinedLawyers")]
  public class JoinedLawyers
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JoinedLawyerID { get; set; }
    public string Role { get; set; }
    public string Race { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
  }
}
