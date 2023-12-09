using Cysharp.Threading.Tasks;
using NickoJ.DinoRunner.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace NickoJ.DinoRunner.Engine
{
    internal static class GameInit
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static async void Initialize()
        {
            var gameLoop = new GameLoop();
            PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, gameLoop );

            var game = new Game(gameLoop);
            
            if (SceneManager.sceneCount != 1 || SceneManager.GetActiveScene().buildIndex != 0)
            {
                return;
            }

            // This scene is loaded once and we don't need to unload it.
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Scene_Game");
            await handle;
        }
    }
}
