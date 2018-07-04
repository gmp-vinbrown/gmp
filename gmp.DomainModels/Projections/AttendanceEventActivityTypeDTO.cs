using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(AttendanceEventActivityType))]
    public class AttendanceEventActivityTypeDTO
    {
        public int AttendanceEventActivityTypeId { get; set; }
        public int AttendanceId { get; set; }
        public int EventActivityTypeId { get; set; }

        public AttendanceDTO Attendance { get; set; }
        public EventActivityTypeDTO EventActivityType { get; set; }
    }
}
