using System;
using NickoJ.DinoRunner.Core.Config;

namespace NickoJ.DinoRunner.Core.Model
{
    /// <summary>
    /// Player
    /// </summary>
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

        /// <summary>
        /// Player's speed without modificators.
        /// </summary>
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

        /// <summary>
        /// Speed modificators that increase/decrease player's speed.
        /// </summary>
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

        /// <summary>
        /// Checks if player can stop or not.
        /// </summary>
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
        
        /// <summary>
        /// Current player speed.
        /// </summary>
        public float CurrentSpeed => _currentSpeed;

        /// <summary>
        /// Player Y position.
        /// </summary>
        public float Y { get; internal set; }

        /// <summary>
        /// Player Y velocity.
        /// </summary>
        public float YSpeed { get; internal set; }

        /// <summary>
        /// If player is flying or not.
        /// </summary>
        public bool IsFlying => _flyRequestCount > 0;

        /// <summary>
        /// If player is dead or not.
        /// </summary>
        public bool IsDead { get; internal set; }

        public event Action<float> OnCurrentSpeedChanged;
        public event Action<bool> OnFly;

        public Player(IPlayerConfig config, float minSpeed)
        {
            _config = config;
            _minSpeed = minSpeed;
        }
        
        /// <summary>
        /// Try to jump
        /// </summary>
        public void Jump()
        {
            if (Y == 0)
            {
                YSpeed = _config.JumpSpeed;
            }
        }

        /// <summary>
        /// Try to fly.
        /// </summary>
        internal void RequestFly()
        {
            _flyRequestCount++;

            if (_flyRequestCount == 1)
            {
                OnFly?.Invoke(true);
            }
        }

        /// <summary>
        /// Try to stop fly 
        /// </summary>
        internal void RequestStopFly()
        {
            int count = _flyRequestCount - 1;
            
            _flyRequestCount = Math.Max(count, 0);

            if (count == 0)
            {
                OnFly?.Invoke(false);
            }
        }

        /// <summary>
        /// Validate player if it's invalidated.
        /// </summary>
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