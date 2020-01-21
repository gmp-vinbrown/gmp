using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(TransactionType))]
    public class TransactionTypeDTO
    {
        public TransactionTypeDTO()
        {
            Payments = new HashSet<PaymentDTO>();
        }

        public int TransactionTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<PaymentDTO> Payments { get; set; }
    }
}
