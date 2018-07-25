using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Tables
{
  [Table("AD_Genders")]
  public class Genders
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid GenderID { get; set; }
    public Guid FirmLeadershipID { get; set; }
    public string NumberQuestion { get; set; }
    public string MinorityFemale { get; set; }
    public string MinorityMale { get; set; }
    public string WhiteFemale { get; set; }
    public string WhiteMale { get; set; }
    public string Lgbt { get; set; }
    public string Disabled { get; set; }
  }
}
