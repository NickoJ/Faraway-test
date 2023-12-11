using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    /// <summary>
    /// Interface for bonus storage.
    /// </summary>
    public interface IBonusStorage
    {
        Bonus Build(BonusKind bonusKind);
        void Release(Bonus bonus);
    }
}