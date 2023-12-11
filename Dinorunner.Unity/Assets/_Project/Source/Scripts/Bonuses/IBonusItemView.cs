using System;
using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    public interface IBonusItemView
    {
        BonusKind Kind { get; }

        uint Id { get; set; }
        bool Visible { get; set; }

        void SetX(float x);
    }
}