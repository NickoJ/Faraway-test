using System;
using NickoJ.DinoRunner.Core.Config;
using NickoJ.DinoRunner.Core.Model;

namespace NickoJ.DinoRunner.Core.GameSystems.Gravity
{
    internal sealed class GravitySystem : GameSystem, IUpdateGameSystem
    {
        private readonly Player _player;
        private readonly IGravityConfig _config;

        public GravitySystem(Player player, IGravityConfig config) : base(true)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        void IUpdateGameSystem.Update(float dt)
        {
            if (_player.IsFlying) return;
            
            float y = _player.Y;
            float ySpeed = _player.YSpeed;

            if (y > 0 || ySpeed != 0)
            {
                y += ySpeed * dt;
                ySpeed += _config.Gravity * dt;

                if (y <= 0)
                {
                    y = 0;
                    ySpeed = 0;
                }
                
                _player.Y = y;
                _player.YSpeed = ySpeed;
            }
        }
    }
}