using UnityEngine;

public class Health : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            GameObject heart = GameObject.FindWithTag("Destroy");
            if (heart != null)
            {
                Destroy(heart); // détruit les vies
            }

            Destroy(collision.gameObject); // détruit l'ennemi
        }
    }
}