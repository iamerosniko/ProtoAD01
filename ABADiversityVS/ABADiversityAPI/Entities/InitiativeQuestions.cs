using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_InitiativeQuestions")]
  public class InitiativeQuestions
  {
    public int InitiativeQuestionID { get; set; }
    public string QuestionDesc { get; set; }
  }
}
