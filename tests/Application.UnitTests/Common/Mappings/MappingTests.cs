using AutoMapper;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;
using NUnit.Framework;
using System;
using GlassZebra.Application.Game.Dtos;

namespace GlassZebra.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Test]
        [TestCase(typeof(Domain.Entities.Game), typeof(GameDto))]
        [TestCase(typeof(GamePlayer), typeof(GamePlayerDto))]
        [TestCase(typeof(GameRound), typeof(GameRoundDto))]
        [TestCase(typeof(QuestionCategory), typeof(QuestionCategoryDto))]
        [TestCase(typeof(GameRound), typeof(GameRoundDto))]
        [TestCase(typeof(Question), typeof(QuestionDto))]
        [TestCase(typeof(QuestionCategory), typeof(QuestionCategoryDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
