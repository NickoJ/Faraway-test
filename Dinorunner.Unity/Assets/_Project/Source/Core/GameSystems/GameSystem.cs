namespace NickoJ.DinoRunner.Core.GameSystems
{
    internal abstract class GameSystem : IGameSystem
    {
        private readonly ILogger _logger;
        private readonly IInitGameSystem _init;
        private readonly IUpdateGameSystem _update;
        private readonly IFinishGameSystem _finish;

        private GameSystemState _state;
        
        protected GameSystem(bool started, ILogger logger = null)
        {
            _state = started ? GameSystemState.NotInitialized : GameSystemState.Finished;
            _logger = logger;

            _init = this as IInitGameSystem;
            _update = this as IUpdateGameSystem;
            _finish = this as IFinishGameSystem;
        }

        public void Start()
        {
            if (_state == GameSystemState.Finished)
            {
                _state = GameSystemState.NotInitialized;
            }
        }

        public void Stop()
        {
            if (_state is not (GameSystemState.Finished or GameSystemState.Finishing))
            {
                _state = GameSystemState.NeedToFinish;
            }
        }

        public void Tick(float dt)
        {
            if (_state == GameSystemState.NotInitialized)
            {
                _init?.Init();
                _state = _state == GameSystemState.NeedToFinish
                    ? GameSystemState.NeedToFinish
                    : GameSystemState.Initialized;
            }

            if (_state == GameSystemState.Initialized)
            {
                _update?.Update(dt);
            }

            if (_state == GameSystemState.NeedToFinish)
            {
                _state = GameSystemState.Finishing;
            }

            if (_state == GameSystemState.Finishing)
            {
                _finish?.Finish();
                _state = GameSystemState.Finished;
            }
        }

        protected void Log(string message)
        {
            _logger.Log(message);
        }
    }
}