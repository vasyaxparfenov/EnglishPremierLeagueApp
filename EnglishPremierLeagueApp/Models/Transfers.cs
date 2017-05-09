using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnglishPremierLeagueApp.Models
{
    public partial class Transfers
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        [Range(0,2)]
        public TransferStatus Status { get; set; }
        public decimal Fee { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }

        public virtual Teams From { get; set; }
        public virtual Players Player { get; set; }
        public virtual Teams To { get; set; }
    }
}
