using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    /// <summary>
    /// BonusViewsStorages' API.
    /// </summary>
    public interface IBonusViewsStorage
    {
        IBonusItemView GetView(BonusKind kind);
        void ReleaseView(IBonusItemView view);
    }
}