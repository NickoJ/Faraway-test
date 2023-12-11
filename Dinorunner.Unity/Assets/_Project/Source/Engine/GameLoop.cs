using Cysharp.Threading.Tasks;
using NickoJ.DinoRunner.Core;
using UnityEngine;

namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// GameLoop that's can be connected to PlayerLoop using UniTask.
    /// </summary>
    internal sealed class GameLoop : IPlayerLoopItem, IGameLoop
    {
        public event IGameLoop.TickDelegate OnTick; 

        public bool MoveNext()
        {
            OnTick?.Invoke(Time.deltaTime);
            return true;
        }
    }
}