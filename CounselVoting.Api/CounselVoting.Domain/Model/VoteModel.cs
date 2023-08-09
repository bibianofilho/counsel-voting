using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using CounselVoting.Domain.Enums;

namespace CounselVoting.Domain.Model
{
    public class VoteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoteId { get; set; }
        [Required]
        public long MeasureId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public VoteType VoteType { get; set; }
        [Required]
        public DateTime VotedAt { get; set; }
    }
}
