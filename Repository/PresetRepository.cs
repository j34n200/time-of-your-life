using time_of_your_life.Data;
using time_of_your_life.Interfaces;
using time_of_your_life.Models;

namespace time_of_your_life.Repository
{
    public class PresetRepository : BaseRepository<ClockProps>, IPresetRepository
    {
        protected readonly DataContext _appDbContext;
        public PresetRepository(DataContext context) : base(context)
        {
            _appDbContext = context;
        }

        public Task AddPreset(ClockProps props)
        {
            base.Add(props);

            _appDbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public IQueryable<ClockProps> GetPresets()
        {
            var result = base.GetAll();

            return result;
        }
        public ClockProps? GetPresetById(Guid id)
        {
            var result = base.GetById(id);

            return result;
        }

        public Task UpdatePreset(ClockProps clockProps)
        {
            base.Update(clockProps);

            _appDbContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
