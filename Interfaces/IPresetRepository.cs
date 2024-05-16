using time_of_your_life.Models;

namespace time_of_your_life.Interfaces
{
    public interface IPresetRepository : IBaseRepository<ClockProps>
    {
        Task AddPreset(ClockProps clockProps);
        IQueryable<ClockProps> GetPresets();
        ClockProps? GetPresetById(Guid id);
        Task UpdatePreset(ClockProps clockProps);
    }
}