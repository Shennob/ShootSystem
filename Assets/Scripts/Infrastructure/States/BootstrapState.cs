using Infrastructure.AssetManagement;
using Infrastructure.Core;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.StaticData;
using Infrastructure.StaticData.Level;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(IGameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(LevelId.Init.ToString(), onLoaded: EnterLoadLevel);

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            RegisterAssetProvider();
            RegisterGameFactory();
        }

        private void RegisterGameFactory() =>
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssets>()));

        private void RegisterAssetProvider() => 
            _services.RegisterSingle<IAssets>(new AssetProvider());

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, LevelId>(LevelId.ShootSystemTest);
    }
}