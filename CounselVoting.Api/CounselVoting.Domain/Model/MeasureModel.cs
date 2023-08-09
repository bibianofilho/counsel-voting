using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CounselVoting.Domain.Enums;

namespace CounselVoting.Domain.Model
{
    public class MeasureModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MeasureId { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
        public MeasureStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public MeasureRuleModel? MeasureRule { get; set; }

        
    }
}
