using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CounselVoting.Domain.Model
{
    public class MeasureRuleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MeasureRuleId { get; set; }
        public long MeasureId { get; set; }
        public MeasureModel Measure { get; set; }
        public int MinNumberOfVotes { get; set; }
        public int MinPercentageOfYes { get; set; }       
        public ICollection<UserNamesMustVoteToPassModel> UserNamesMustVoteToPassList { get; set; } = new List<UserNamesMustVoteToPassModel>();
        public bool UserMustUploadPicture { get; set; }

    }
}
