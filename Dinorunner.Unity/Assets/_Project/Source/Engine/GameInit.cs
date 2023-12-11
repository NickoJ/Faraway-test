using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.GameSystems.Bonuses;
using NickoJ.DinoRunner.Engine.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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

            UnityLogger logger = new UnityLogger();
            GameConfig gameConfig = await LoadGameConfig();

            var game = new Game(gameLoop, logger, gameConfig);

            ServiceLocator serviceLocator = InitializeServiceLocator(game);
            
            await LoadGameScene();

            Launch(serviceLocator);
        }

        private static async UniTask<GameConfig> LoadGameConfig()
        {
            AsyncOperationHandle<GameConfig> handle = Addressables.LoadAssetAsync<GameConfig>("Config_Game");
            
            await handle;
            return handle.Result;
        }

        private static ServiceLocator InitializeServiceLocator(Game game)
        {
            var serviceLocator = new ServiceLocator();

            serviceLocator.Register<IGame>(game);
            serviceLocator.Register(game.GetSystem<IBonusSystem>());

            return serviceLocator;
        }

        private static async Task LoadGameScene()
        {
            // If we are not in the main scene, we don't need to load the game scene.
            // This is because the game is launched in another scene.
            if (SceneManager.sceneCount != 1 || SceneManager.GetActiveScene().buildIndex != 0)
            {
                return;
            }

            // This scene is loaded once and we don't need to unload it.
            await Addressables.LoadSceneAsync("Scene_Game");
        }

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
