using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_FirmLeaderships")]
  public class FirmLeaderships
  {
    public int FirmLeadershipID { get; set; }
    public string Category { get; set; }
    public string GenderRace { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
  }
}
