using System;
using NickoJ.DinoRunner.Core.Config;

namespace NickoJ.DinoRunner.Core.Model
{
    public sealed class Player
    {
        private readonly IPlayerConfig _config;
        private readonly float _minSpeed;

        private bool _canStop = true;
        private float _baseSpeed = 0f;
        private int _speedModificator = 0;
        private float _currentSpeed = 0f;
        private bool _speedValid = false;

        private int _flyRequestCount = 0;

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

        public bool CanStop
        {
            get => _canStop;
            set
            {
                if (_canStop == value) return;

                _canStop = value;
                _speedValid = false;
            }
        }
        
        public float CurrentSpeed => _currentSpeed;

        public float Y { get; internal set; }

        public float YSpeed { get; internal set; }

        public bool IsFlying => _flyRequestCount > 0;

        public bool IsDead { get; internal set; }

        public event Action<float> OnCurrentSpeedChanged;
        public event Action<bool> OnFly;

        public Player(IPlayerConfig config, float minSpeed)
        {
            _config = config;
            _minSpeed = minSpeed;
        }
        
        public void Jump()
        {
            if (Y == 0)
            {
                YSpeed = _config.JumpSpeed;
            }
        }

        internal void RequestFly()
        {
            _flyRequestCount++;

            if (_flyRequestCount == 1)
            {
                OnFly?.Invoke(true);
            }
        }

        internal void RequestStopFly()
        {
            int count = _flyRequestCount - 1;
            
            _flyRequestCount = Math.Max(count, 0);

            if (count == 0)
            {
                OnFly?.Invoke(false);
            }
        }

        internal void Validate()
        {
            if (_speedValid) return;

             float speed = BaseSpeed + BaseSpeed * (SpeedModificator / 100f);

             _currentSpeed = Math.Max(speed, _canStop ? 0f : _minSpeed);
                
            _speedValid = true;
            OnCurrentSpeedChanged?.Invoke(_currentSpeed);            
        }
    }
}