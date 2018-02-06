using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_HoursReducedLawyers")]
  public class HoursReducedLawyers
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HoursReducedLawyerID { get; set; }
    public string Gender { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }
    public int CompanyProfileID { get; set; }

  }
}
