using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Payment))]
    public class PaymentDTO
    {
        public PaymentDTO()
        {
            Registrations = new HashSet<EventRegistrationDTO>();
        }

        public int PaymentId { get; set; }
        public int TransactionTypeId { get; set; }
        public int MemberId { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual MemberDTO Member { get; set; }

        public virtual TransactionTypeDTO TransactionType { get; set; }

        [JsonIgnore]
        public virtual ICollection<EventRegistrationDTO> Registrations { get; set; }
    }
}
