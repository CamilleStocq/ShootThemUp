using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    private Score scoreManager;

    void Awake()
    {
        scoreManager = FindObjectOfType<Score>();
        Destroy(gameObject, life);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            scoreManager.IncreaseCounter();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
}
