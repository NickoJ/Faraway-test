namespace NickoJ.DinoRunner.Core.Model.Bonuses
{
    public sealed class ChangeSpeedBonus : Bonus
    {
        private Player _player;
        
        public void Init(Player player, float duration)
        {
            _player = player;

            base.Init(duration);
        }

        public override void Apply()
        {
            throw new System.NotImplementedException();
        }

        public override void Revoke()
        {
            throw new System.NotImplementedException();
        }
    }
}