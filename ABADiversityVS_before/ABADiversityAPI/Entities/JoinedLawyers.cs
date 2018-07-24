using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_JoinedLawyers")]
  public class JoinedLawyers
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JoinedLawyerID { get; set; }
    public string Races { get; set; }
    public int EquityPartners { get; set; }
    public int NonEquityPartners { get; set; }
    public int Associates { get; set; }
    public int Counsels { get; set; }
    public int OtherLawyers { get; set; }
    public Guid CompanyProfileID { get; set; }
  }
}
