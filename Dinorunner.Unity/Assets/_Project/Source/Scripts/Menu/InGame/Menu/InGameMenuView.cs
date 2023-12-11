using System;
using UnityEngine;
using UnityEngine.UI;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Menu
{
    [RequireComponent(typeof(Canvas))]
    public sealed class InGameMenuView : MonoBehaviour, IInGameMenuView
    {
        [SerializeField] private Button jumpButton; 
        
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

            jumpButton.onClick.AddListener(() => OnJump?.Invoke());
        }
    }
}