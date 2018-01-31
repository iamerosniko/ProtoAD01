using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_LeftLawyers")]
  public class LeftLawyers
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeftLawyerID { get; set; }
    public string Gender { get; set; }
    public string Races { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
    public int CompanyProfileID { get; set; }
  }
}
