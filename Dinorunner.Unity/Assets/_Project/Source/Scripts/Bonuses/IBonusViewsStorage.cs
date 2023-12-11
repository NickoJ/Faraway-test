using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    public interface IBonusViewsStorage
    {
        IBonusItemView GetView(BonusKind kind);
        void ReleaseView(IBonusItemView view);
    }
}