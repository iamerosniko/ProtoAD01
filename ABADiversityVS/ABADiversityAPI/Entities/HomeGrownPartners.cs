using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_HomegrownPartners")]
  public class HomegrownPartners
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HomegrownPartnersID { get; set; }
    public string Gender { get; set; }
    public int Minority { get; set; }
    public int White { get; set; }
    public int LGBT { get; set; }
    public int Disabled { get; set; }

    public int CompanyProfileID { get; set; }
    public int Year { get; set; }
  }
}
