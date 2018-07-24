using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_HighCompensatedPartners")]
  public class HighCompensatedPartners
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HighCompensatedPartnerID { get; set; }
    public string Race { get; set; }
    public int Men { get; set; }
    public int Women { get; set; }
    public Guid CompanyProfileID { get; set; }
  }
}
