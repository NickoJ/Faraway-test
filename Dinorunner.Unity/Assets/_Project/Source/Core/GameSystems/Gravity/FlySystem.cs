using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Gravity
{
    /// <summary>
    /// Makes player fly when flying is enabled.
    /// </summary>
    internal sealed class FlySystem : GameSystem, IInitGameSystem, IUpdateGameSystem
    {
        private readonly Player _player;
        private readonly IPlayerConfig _config;

        private float _flyDelay;
        
        public FlySystem(Player player, IPlayerConfig config, ILogger logger = null) : base(false, logger)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _config = config ?? throw new ArgumentNullException(nameof(config));

            _player.OnFly += PlayerFlyHandler;
        }

        void IInitGameSystem.Init()
        {
            _flyDelay = _config.FlyDelay;
            _player.YSpeed = 0f;
        }

        void IUpdateGameSystem.Update(float dt)
        {
            if (_flyDelay >= 0)
            {
                _flyDelay -= dt;
                return;
            }

            _player.Y = Math.Min(_player.Y + _config.FlyUpSpeed * dt, _config.FlyY);
        }

        private void PlayerFlyHandler(bool isFlying)
        {
            if (isFlying)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
    }
}