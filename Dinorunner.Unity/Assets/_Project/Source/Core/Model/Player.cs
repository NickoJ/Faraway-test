using System;
using NickoJ.DinoRunner.Core.Config;

namespace NickoJ.DinoRunner.Core.Model
{
    public sealed class Player
    {
        private readonly IPlayerConfig _config;

        private float _baseSpeed = 0f;
        private int _speedModificator = 0;
        private float _currentSpeed = 0f;
        private bool _speedValid = false;

        public float BaseSpeed
        {
            get => _baseSpeed;
            set
            {
                if (Math.Abs(_baseSpeed - value) < 0.001f) return;
                
                _baseSpeed = value;
                _speedValid = false;
            }
        }

        public int SpeedModificator
        {
            get => _speedModificator;
            set
            {
                if (_speedModificator == value) return;

                _speedModificator = value;
                _speedValid = false;
            }
        }
        
        public float CurrentSpeed => _currentSpeed;

        public float Y { get; internal set; }

        public float YSpeed { get; internal set; }
        
        public event Action<float> OnCurrentSpeedChanged;

        public Player(IPlayerConfig config)
        {
            _config = config;
        }
        
        public void Jump()
        {
            if (Y == 0)
            {
                YSpeed = _config.JumpSpeed;
            }
        }

        internal void Validate()
        {
            if (_speedValid) return;

            _currentSpeed = BaseSpeed + BaseSpeed * (SpeedModificator / 100f);
            
            _speedValid = true;
            OnCurrentSpeedChanged?.Invoke(_currentSpeed);            
        }
    }
}