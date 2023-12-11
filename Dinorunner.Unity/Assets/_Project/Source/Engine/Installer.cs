using UnityEngine;

namespace NickoJ.DinoRunner.Engine
{
    public abstract class Installer : MonoBehaviour
    {
        public abstract void Install(IServiceLocator serviceLocator);
    }
}
