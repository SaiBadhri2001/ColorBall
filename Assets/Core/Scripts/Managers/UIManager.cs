using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TheColorBall.Core
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public GameObject ScoreField;
        public GameObject StartUI;
        public GameObject RestartUi;
        public TextMeshProUGUI CurrentScoreField;
        public TextMeshProUGUI HightScoreField;
        public UnityEvent OnDisplayRestartUI;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        private void Start()
        {
            RestartUi.SetActive(false);
            ScoreField.SetActive(true);
            StartCoroutine(StartUIProperties());
        }
        public void DisplayRestartUI()
        {
            ScoreManager.HighScoreCalculator();
            RestartUi.SetActive(true);
            ScoreField.SetActive(false);
            CurrentScoreField.text = ScoreManager.currentScore.ToString();
            HightScoreField.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
            OnDisplayRestartUI?.Invoke();
        }
        IEnumerator StartUIProperties()
        {
            yield return new WaitUntil(() => StaticDatas.isPlayStarted);
            StartUI.SetActive(false);
        }
    }
}