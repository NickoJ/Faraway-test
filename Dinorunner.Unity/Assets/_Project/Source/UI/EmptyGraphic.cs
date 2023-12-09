using UnityEngine;

namespace NickoJ.DinoRunner.UI
{
    [RequireComponent(typeof(CanvasRenderer))]
    public sealed class EmptyGraphic : UnityEngine.UI.Graphic
    {
        protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vh)
        {
            vh.Clear();
        }        
    }
}
