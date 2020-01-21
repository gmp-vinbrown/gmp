using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventFeeGroup))]
    public class EventFeeGroupDTO
    {
        public int EventFeeGroupId { get; set; }
        public int EventId { get; set; }
        public decimal Fee { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(350)]
        public string Description { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual EventDTO Event { get; set; }
    }
}
