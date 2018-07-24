using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABADiversityAPI.Entities
{
  [Table("ABA_SizeCategory")]
  public class SizeCategory
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SizeCategoryID { get; set; }
    public string SizeCategoryDesc { get; set; }
  }
}
