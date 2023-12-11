using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    /// <summary>
    /// Detects jump requests from the player.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public sealed class InGameMenuView : MonoBehaviour, IInGameMenuView
    {
        [SerializeField] private EventTrigger jumpButton; 
        
        private Canvas _canvas;

        public bool Visible
        {
            get => _canvas.enabled;
            set => _canvas.enabled = value;
        }

        public event Action OnJump;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            var entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerDown
            };
            entry.callback.AddListener( _ => OnJump?.Invoke() );
            jumpButton.triggers.Add(entry);
        }
    }
}