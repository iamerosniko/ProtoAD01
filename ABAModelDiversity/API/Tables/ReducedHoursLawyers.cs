using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Tables
{
  [Table("AD_ReducedHoursLawyers")]

  public class ReducedHoursLawyers
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ReducedHoursLawyerID { get; set; }
    public Guid CompanyProfileID { get; set; }

    public List<Regions> Regions { get; set; }
  }
}
