using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_FirmDemographics")]
  public class FirmDemographics
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FIrmDemographicsID { get; set; }
    public string Varchar { get; set; }
    public string Race { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
    public int CompanyProfileID { get; set; }
  }

}
