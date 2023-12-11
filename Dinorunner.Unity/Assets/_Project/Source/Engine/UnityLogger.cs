using UnityEngine;
using ILogger = NickoJ.DinoRunner.Core.ILogger;

namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// Wrapper for logging in core assembly.
    /// </summary>
    internal sealed class UnityLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}