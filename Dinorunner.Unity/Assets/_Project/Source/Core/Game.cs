using System;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core
{
    public sealed class Game : IDisposable
    {
        private readonly IGameLoop _gameLoop;

        public Game(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));

            var gameState = new GameState();
            var player = new Player();

            _gameLoop.OnTick += Tick;
        }

        private void Tick(float dt)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _gameLoop.OnTick -= Tick;
        }
    }
}