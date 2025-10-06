using UnityEngine;

public class Health : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            Destroy(gameObject);

            GameObject[] tousLesObjets = FindObjectsOfType<GameObject>();

            foreach (GameObject obj in tousLesObjets)
            {
                if (obj.CompareTag("Destroy"))
                {
                    Destroy(obj);
                    return;
                }
            }
        }
    }
}
