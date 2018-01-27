using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
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
