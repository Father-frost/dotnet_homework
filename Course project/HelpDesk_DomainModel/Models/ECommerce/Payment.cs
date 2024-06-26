﻿
namespace HelpDesk_DomainModel.Models.ECommerce
{
    public class Payment : Entity<long>
    {
        public required Order Order { get; set; }
        public required DateTime Date { get; set; }
        public required decimal Amount { get; set; }
        public required string Source { get; set; }
        public required string MetaData { get; set; }
    }
}
