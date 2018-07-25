using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Tables
{
  [Table("AD_TopTenHighestCompensations")]

  public class TopTenHighestCompensations
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TopTenHighestCompensationID { get; set; }
    public Guid CompanyProfileID { get; set; }
    public List<Regions> Regions { get; set; }
  }
}
