using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;
using NickoJ.DinoRunner.Engine.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace NickoJ.DinoRunner.Engine
{
    /// <summary>
    /// Starts the game and initialized required data.
    /// </summary>
    internal static class GameInit
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static async void Initialize()
        {
            // Creates game loop and connects it to PlayerLoop via UniTask because it's easier.
            var gameLoop = new GameLoop();
            PlayerLoopHelper.AddAction(PlayerLoopTiming.Update, gameLoop );

            var logger = new UnityLogger();
            GameConfig gameConfig = await LoadGameConfig();

            var game = new Game(gameLoop, logger, gameConfig);

            ServiceLocator serviceLocator = InitializeServiceLocator(game);
            
            await LoadGameScene();

            Launch(serviceLocator);
        }

        /// <summary>
        /// Loads game config from Config file. Check addressable groups.
        /// </summary>
        /// <returns></returns>
        private static async UniTask<GameConfig> LoadGameConfig()
        {
            AsyncOperationHandle<GameConfig> handle = Addressables.LoadAssetAsync<GameConfig>("Config_Game");
            
            await handle;
            return handle.Result;
        }

        /// <summary>
        /// Initializes service locator.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        private static ServiceLocator InitializeServiceLocator(IGame game)
        {
            var serviceLocator = new ServiceLocator();

            serviceLocator.Register(game);
            
            return serviceLocator;
        }

        /// <summary>
        /// Loads GameScene from addressables.
        /// </summary>
        private static async Task LoadGameScene()
        {
            // If we are not in the main scene, we don't need to load the game scene.
            // This is because the game is launched in another scene.
            if (SceneManager.sceneCount != 1 || SceneManager.GetActiveScene().buildIndex != 0)
            {
                return;
            }

            // This scene is loaded once and we don't need to unload it.
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Scene_Game");
            
            await UniTask.WaitUntil(() => handle.IsDone);
        }

        /// <summary>
        /// Initialize all installers on the scene.
        /// </summary>
        /// <param name="serviceLocator"></param>
        private static void Launch(ServiceLocator serviceLocator)
        {
            Installer[] installers = Resources.FindObjectsOfTypeAll<Installer>();
            foreach (Installer installer in installers)
            {
                installer.Install(serviceLocator);
            }
        }
    }
}
