using Data;
using Infrastructure.Core;
using Infrastructure.Factory;
using Infrastructure.Services.StaticData;
using Infrastructure.StaticData.Level;
using UnityEngine.SceneManagement;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<LevelId>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(IGameStateMachine stateMachine, SceneLoader sceneLoader,
            IGameFactory gameFactory, IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _staticData = staticData;
        }

        public void Enter(LevelId level)
        {
            _sceneLoader.Load(level.ToString(), OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitCurrentLevel();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitCurrentLevel()
        {
            LevelId activeScene = DataExtensions.GetCurrentLevelId();

            switch (activeScene)
            {
                case LevelId.ShootSystemTest:
                    InitGame();
                    break;
            }
        }

        private void InitGame()
        {
            InitPlayer();
            _gameFactory.CreateHud();
        }

        private void InitPlayer()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);
            
            _gameFactory.CreatePlayer(levelData.PlayerSpawner.Position);
        }
    }
}