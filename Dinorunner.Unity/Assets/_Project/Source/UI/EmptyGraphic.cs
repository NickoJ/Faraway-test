using UnityEngine;

namespace NickoJ.DinoRunner.UI
{
    /// <summary>
    /// Graphic for unity UI that doesn't draw anything but help with touch detecting.
    /// </summary>
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class EmptyGraphic : UnityEngine.UI.Graphic
    {
        protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vh)
        {
            vh.Clear();
        }        
    }
}
