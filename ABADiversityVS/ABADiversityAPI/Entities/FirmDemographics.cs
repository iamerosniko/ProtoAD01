using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_FirmDemographics")]
  public class FirmDemographics
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FIrmDemographicsID { get; set; }
    public string Race { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }

    public int CompanyProfileID { get; set; }
  }

}
