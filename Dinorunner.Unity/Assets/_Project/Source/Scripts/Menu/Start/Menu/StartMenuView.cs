using System;
using UnityEngine;
using UnityEngine.UI;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Menu
{
    [RequireComponent(typeof(Canvas))]
    public sealed class StartMenuView : MonoBehaviour, IStartMenuView
    {
        [SerializeField] private Button startButton; 
        
        private Canvas _canvas;

        public bool Visible
        {
            get => _canvas.enabled;
            set => _canvas.enabled = value;
        }

        public event Action OnStartButtonClicked;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            startButton.onClick.AddListener(() => OnStartButtonClicked?.Invoke());
        }
    }
}