using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    public float life = 3f;
    private int counter;
    private const string PREF_NAME = "Counter Value";

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void Start()
    {
        counter = PlayerPrefs.GetInt(PREF_NAME);
        score.SetText($"score : {counter}"); // commence à zero
    }
    
    public void IncreaseCounter()
    {
        if () // si l'objet est détruit alors
        {
            counter++; // augmente le compteur de 1
            PlayerPrefs.SetInt(PREF_NAME, counter); // pour que ca reste en mémoire. si on relance une deuxieme fois le jeu il garde le nombre de la derniere fois
            score.SetText($"score : {counter}"); // affiche le compteur à la place du texte
        }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
