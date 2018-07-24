using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_InitiativeQuestions")]
  public class InitiativeQuestions
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InitiativeQuestionID { get; set; }
    public string QuestionDesc { get; set; }
  }
}
