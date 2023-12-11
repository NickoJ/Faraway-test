using NickoJ.DinoRunner.Core;
using NickoJ.DinoRunner.Core.Model;
using NickoJ.DinoRunner.Engine;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Bonuses
{
    public sealed class BonusesInstaller : Installer
    {
        [SerializeField] private BonusItemView[] bonuses;
        
        private BonusesController _bonusesController;

        public override void Install(IServiceLocator serviceLocator)
        {
            IGameState state = serviceLocator.Get<IGame>().State;
            var storage = new BonusViewStorage(transform, bonuses);

            _bonusesController = new BonusesController(state, storage);
        }
    }
}