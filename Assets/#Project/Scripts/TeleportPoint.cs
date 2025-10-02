using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnnemyBehaviour ennemy)) // instance que si c'est necessaire
        {
            ennemy.Teleport();
        }
    }
}
