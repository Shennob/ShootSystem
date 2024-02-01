using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure.Core
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) => 
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
    }
}