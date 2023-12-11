using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    public interface IBonusSystem : IGameSystem
    {
        void AddBonus(BonusKind bonusKind);
    }
}