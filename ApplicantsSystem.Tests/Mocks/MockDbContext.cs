namespace ApplicantsSystem.Tests.Mocks
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class MockDbContext
    {
        public static ApplicantsSystemDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicantsSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicantsSystemDbContext(options);
        }
    }
}
