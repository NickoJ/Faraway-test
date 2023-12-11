using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    /// <summary>
    /// Interface for bonus system external usage.
    /// </summary>
    public interface IBonusSystem : IGameSystem
    {
        void AddBonus(BonusKind bonusKind);
    }
}