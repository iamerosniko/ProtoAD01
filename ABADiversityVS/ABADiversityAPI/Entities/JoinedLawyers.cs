using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Entities
{
  public class JoinedLawyers
  {
    public int JoinedLawyerID { get; set; }
    public string Role { get; set; }
    public string Race { get; set; }
    public int Value { get; set; }
    public int Year { get; set; }
  }
}