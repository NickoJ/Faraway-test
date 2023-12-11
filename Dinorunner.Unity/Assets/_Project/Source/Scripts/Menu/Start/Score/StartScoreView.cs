using TMPro;
using UnityEngine;

namespace NickoJ.DinoRunner.Scripts.Menu.Start.Score
{
    /// <summary>
    /// Shows information about score of the last run and info about best run.
    /// </summary>
    public sealed class StartScoreView : MonoBehaviour, IStartScoreView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [SerializeField] private GameObject newRecordFlag;

        [SerializeField] private string bestScoreTemplate = "BEST: {0}";
        
        public void UpdateScore(ulong bestScore, ulong newScore, bool newRecord)
        {
            scoreText.text = newScore.ToString();
            bestScoreText.text = string.Format(bestScoreTemplate, bestScore);

            bestScoreText.gameObject.SetActive(!newRecord);
            newRecordFlag.SetActive(newRecord);
        }
    }
}