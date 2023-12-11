namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    public sealed class FlyBonus : Bonus
    {
        private Player _player;

        public void Init(Player player, float duration)
        {
            _player = player;
            Init(duration);
        }
        
        public override void Apply()
        {
            _player.RequestFly();
        }

        public override void Revoke()
        {
            _player.RequestStopFly();
        }
    }
}