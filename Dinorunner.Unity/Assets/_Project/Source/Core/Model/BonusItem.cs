using NickoJ.DinoRunner.Core.Model.Bonuses;

namespace NickoJ.DinoRunner.Core.Model
{
    public struct BonusItem
    {
        public readonly uint ID;
        public readonly BonusKind Kind;

        public float Pos;

        public BonusItem(uint id, BonusKind kind, float pos)
        {
            ID = id;
            Kind = kind;
            Pos = pos;
        }
    }
}