using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_FirmInitiatives")]
  public class FirmInitiatives
  {
    public int FirmInitiativeID { get; set; }
    //foreignkey
    public int InitiativeQuestionID { get; set; }
    public bool IfYes { get; set; }
    public string Comments { get; set; }
    public int Year { get; set; }
  }
}
