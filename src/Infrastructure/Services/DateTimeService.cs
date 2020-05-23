using GlassZebra.Application.Common.Interfaces;
using System;

namespace GlassZebra.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
