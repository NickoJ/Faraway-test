using System;

namespace NickoJ.DinoRunner.Scripts.Dino
{
    /// <summary>
    /// DinoViews' API.
    /// </summary>
    public interface IDinoView
    {
        event Action OnUpdate;

        void UpdateView(float speed, float y, bool flying);
    }
}