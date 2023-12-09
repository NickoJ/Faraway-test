namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    public abstract class Bonus : IBonus
    {
        private float _timeLeft;

        public bool IsActive => _timeLeft > 0;

        protected void Init(float duration)
        {
            _timeLeft = duration;
        }

        public void Update(float dt)
        {
            _timeLeft -= dt;
        }

        public abstract void Apply();

        public abstract void Revoke();
    }
}