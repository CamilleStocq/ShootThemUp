using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
// {
//     [SerializeField] private Text[] scoreText; // tmp score du joueur 
//     // [SerializeField] private Text hiScoreText; // tmp classement score

//     private List<int> hiScore = new List<int>();
//     private int currentScore = 0;
//     private int currentRank = 0;

//     void Start()
//     {
//         //hiScore = PlayerPrefs.GetInt("HiScore", 0); // historique des score du joueur
//         HighScore();
//         UpdateUI();
//     }

//     public void AddScore(int points)
//     {
//         currentScore += points;
//         UpdateUI();
//     }

//     public void NewScore(int newScore)
//     {
//         hiScore.Add(newScore);
//         hiScore.Sort((a, b) => b.CompareTo(a));

//         if (hiScore.Count > 10)
//         {
//             hiScore.RemoveAt(10);
//         }

//         PlayerPrefs.DeleteKey("hiScore");

//         for (int i = 0; i < hiScore.Count; i++)
//         {
//             int s = PlayerPrefs.GetInt("HiScore" + i, 0);
//         }

//         if (s > 0)
//         {
            
//         }
//     }


// }



{
    public Text[] scoreTexts;
    public Color normalColor = Color.white;
    public Color highlightColor = Color.cyan;

    private List<int> highScores = new List<int>();
    private int currentScore = 0;
    private int currentRank = -1;

    void Start()
    {
        LoadHighScores();
        UpdateUI();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateUI();
    }

    public void EndGame()
    {
        SaveNewScore(currentScore);
        UpdateUI();
    }

    void SaveNewScore(int newScore)
    {
        highScores.Add(newScore);
        highScores.Sort((a, b) => b.CompareTo(a)); // tri décroissant
        if (highScores.Count > 10)
            highScores.RemoveAt(10);

        PlayerPrefs.DeleteKey("HighScores");
        for (int i = 0; i < highScores.Count; i++)
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);

        // Trouver la position du score actuel
        currentRank = highScores.IndexOf(newScore);
    }

    void LoadHighScores()
    {
        highScores.Clear();
        for (int i = 0; i < 10; i++)
        {
            int s = PlayerPrefs.GetInt("HighScore" + i, 0);
            if (s > 0) highScores.Add(s);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < highScores.Count)
            {
                scoreTexts[i].text = (i + 1) + ". " + highScores[i];
                scoreTexts[i].color = (i == currentRank) ? highlightColor : normalColor;
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ---";
                scoreTexts[i].color = normalColor;
            }
        }
    }

    public void ResetScores()
    {
        highScores.Clear();
        PlayerPrefs.DeleteAll();
        UpdateUI();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
        currentRank = -1;
        UpdateUI();
    }
}
