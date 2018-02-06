using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_FirmInitiatives")]
  public class FirmInitiatives
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FirmInitiativeID { get; set; }
    //foreignkey
    public int InitiativeQuestionID { get; set; }
    public bool IfYes { get; set; }
    public string Comments { get; set; }
    public int CompanyProfileID { get; set; }
  }
}
