using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_HighCompensatedPartners")]
  public class HighCompensatedPartners
  {
    public int HighCompensatedPartnerID { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
  }
}
