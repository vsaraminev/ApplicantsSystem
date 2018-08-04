namespace ApplicantsSystem.Services
{
    using AutoMapper;
    using Data;

    public abstract class BaseService
    {
        protected BaseService(ApplicantsSystemDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        public ApplicantsSystemDbContext DbContext { get; set; }

        public IMapper Mapper { get; set; }
    }
}
