namespace ApplicantsSystem.Tests.Mocks
{
    using AutoMapper;
    using Web.Infrastructure.Mapping;

    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
        }

        public static IMapper GetAutoMapper() => Mapper.Instance;
    }
}
