using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 

namespace CounselVoting.Domain.Model
{
    public class UserNamesMustVoteToPassModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public long MeasureRuleId { get; set; }
        public MeasureRuleModel MeasureRule { get; set; }

    }
}
