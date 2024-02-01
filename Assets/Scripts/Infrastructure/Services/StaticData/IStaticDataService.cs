using Infrastructure.StaticData.Level;
using Infrastructure.StaticData.Player;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        LevelStaticData ForLevel(string sceneKey);
    }
}