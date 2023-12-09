using System;

namespace NickoJ.DinoRunner.Core.Model
{
    public sealed class GameState
    {
        private bool _started;

        public bool Started
        {
            get => _started;
            set
            {
                if (_started == value) return;

                _started = value;
                OnStarted?.Invoke(_started);
            }
        }

        public event Action<bool> OnStarted;
    }
}