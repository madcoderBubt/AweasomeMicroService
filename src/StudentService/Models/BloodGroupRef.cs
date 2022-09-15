using Infrastructure.Extensions;
using System.ComponentModel;

namespace StudentService.Models
{
    public class BloodGroupRef
    {
        public BloodGroupEnum StatusId { get; set; }
        public string StatusName { get; set; }

        public BloodGroupRef(BloodGroupEnum status)
        {
            StatusId = status;
            StatusName = status.GetDescription();
        }
    }
    public enum BloodGroupEnum
    {
        [Description("Unknown")]
        Unknown,
        [Description("A+")]
        A_Positive,
        [Description("A-")]
        A_Negative,
        [Description("B+")]
        B_Positive,
        [Description("B-")]
        B_Negative,
        [Description("AB+")]
        AB_Positive,
        [Description("AB-")]
        AB_Negative,
        [Description("O+")]
        O_Positive,
        [Description("O-")]
        O_Negative,
    }
}
