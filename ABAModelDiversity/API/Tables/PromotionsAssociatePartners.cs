using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Tables
{
  [Table("AD_PromotionsAssociatePartners")]

  public class PromotionsAssociatePartners
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PromotionsAssociatePartnerID { get; set; }
    public Guid CompanyProfileID { get; set; }
    public List<Regions> Regions { get; set; }
  }
}
