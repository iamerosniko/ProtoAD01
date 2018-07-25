using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Tables
{
  [Table("AD_LeadershipDemographics")]

  public class LeadershipDemographics
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid LeadershipDemographicID { get; set; }
    public Guid CompanyProfileID { get; set; }
    public List<Genders> Genders { get; set; }
  }
}
