using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerFrameworkAPI.Models
{
    public partial class Skills
    {
        [Key]
        [Column("SkillID")]
        public int SkillId { get; set; }
        [Required]
        [Column("SFIASkillCode")]
        public string SFIASkillCode { get; set; }
        [Column("ProfessionID")]
        public int ProfessionId { get; set; }
        [Required]
        public string SkillText { get; set; }
        [Required]
        public int SkillLevel { get; set; }
        [Required]
        public int SFIASkillLevel { get; set; }
        [Required]
        public string SkillCode { get; set; }

        //[ForeignKey(nameof(ProfessionId))]
        //[InverseProperty(nameof(Professions.Skills))]
        //public virtual Professions Profession { get; set; }
    }
}
