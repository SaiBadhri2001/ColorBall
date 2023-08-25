using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheColorBall.Core
{
    public class ScoreManager
    {
        public static int currentScore;
        public static int HighScore;
        public static void HighScoreCalculator()
        {
            if (currentScore > HighScore)
            {
                HighScore = currentScore;
                PlayerPrefs.SetInt("HighScore", HighScore);
            }
        }
        public static void UpdateCurrentScore(CollectablesType collectableType)
        {
            switch (collectableType)
            {
                case CollectablesType.TinyDiamond:
                    {
                        currentScore += 100;
                        break;
                    }
                case CollectablesType.HugeDiamond:
                    {
                        currentScore += 300;
                        break;
                    }
                case CollectablesType.Bomb:
                    {
                        currentScore -= 500;
                        break;
                    }
                case CollectablesType.BombDiamond:
                    {
                        currentScore += 100;
                        break;
                    }
            }
        }
        public static void DisplayCurrentScore(CollectablesType collectablesType)
        {
            Debug.Log("Colleced a " + collectablesType);
            GameManager.instance.scoreDisplay.text = currentScore.ToString();
        }
    }
}