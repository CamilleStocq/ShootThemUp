using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    private int counter = 0;
    private const string PREF_NAME = "Counter Value";

    void Start()
    {
        PlayerPrefs.SetInt(PREF_NAME, 0);
        counter = 0;
        score.SetText($"score : {counter}");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            IncreaseCounter();
        }
    }

    public void IncreaseCounter()
    {
        counter++; // augmente le compteur de 1
        PlayerPrefs.SetInt(PREF_NAME, counter); // pour que ca reste en mémoire. si on relance une deuxieme fois le jeu il garde le nombre de la derniere fois
        score.SetText($"score : {counter}"); // affiche le compteur à la place du texte   
    }
}
