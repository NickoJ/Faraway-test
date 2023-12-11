using TMPro;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.InGame.Score
{
    public sealed class InGameScoreView : MonoBehaviour, IInGameScoreView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject recordFlag;

        public void UpdateScore(ulong score, bool isRecord)
        {
            scoreText.text = score.ToString();
            recordFlag.SetActive(isRecord);
        }
    }
}