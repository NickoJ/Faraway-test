using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.GameSystems.Bonuses
{
    public interface IBonusFactory
    {
        Bonus Build(BonusKind bonusKind);
    }
}