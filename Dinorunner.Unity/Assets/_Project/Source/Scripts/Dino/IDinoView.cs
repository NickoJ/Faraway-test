using System;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    public interface IDinoView
    {
        event Action OnUpdate;

        void UpdateView(float speed, float y, bool flying);
    }
}