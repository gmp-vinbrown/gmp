using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

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
