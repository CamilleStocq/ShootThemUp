using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private bool IsInvicible = false;

    void Start()
    {
        IsInvicible = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") && IsInvicible == false)
        {
            GameObject heart = GameObject.FindWithTag("Destroy");
            if (heart != null)
            {
                Destroy(heart); // détruit les vies
            }

            Destroy(collision.gameObject); // détruit l'ennemi

            StartCoroutine(InvicibleCoroutine());

            if (heart == null)
            {
                SceneManager.LoadScene(sceneName);
            } 
        }
    }

    IEnumerator InvicibleCoroutine()
    {
        IsInvicible = true;

        yield return new WaitForSeconds(1.5f);
        IsInvicible = false;
    }

}