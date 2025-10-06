using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject objetATrouver; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy")) 
        {
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
