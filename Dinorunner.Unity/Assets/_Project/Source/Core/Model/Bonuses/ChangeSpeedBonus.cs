namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    public sealed class ChangeSpeedBonus : Bonus
    {
        private Player _player;
        private int _modificator;
        
        public void Init(Player player, int modificator, float duration)
        {
            _player = player;
            _modificator = modificator;

            base.Init(duration);
        }

        public override void Apply()
        {
            _player.SpeedModificator += _modificator;
        }

        public override void Revoke()
        {
            _player.SpeedModificator -= _modificator;
        }
    }
}