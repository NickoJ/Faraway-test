using UnityEngine;

namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// Installers' base class.
    /// </summary>
    public abstract class Installer : MonoBehaviour
    {
        /// <summary>
        /// Used to send dependencies into the creating controller.
        /// </summary>
        /// <param name="serviceLocator">service locator</param>
        public abstract void Install(IServiceLocator serviceLocator);
    }
}
