using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.7f; // tous les combien de temps il part
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform target; // le point d'arriver
    Pool<EnnemyBehaviour> pool;

    public float minHeight = 0f; //min hauteur
    public float maxHeight = 10f; // max hauteur

    void Start()
    {
        pool = new(gameObject, prefab, 6); // creation de l'ennemie, il y en a 6 qui se créent
        StartCoroutine(SpawnPoint()); // debut de la coroutine
    }

    private IEnumerator SpawnPoint()
    {
        while (true) // boucle infinie
        {
            yield return new WaitForSeconds(cooldown);

            float randomX = Random.Range(minHeight, maxHeight); // random du spawn sur l'axe X
            Vector3 spawnPos = new Vector3(randomX, transform.position.y, transform.position.z);

            EnnemyBehaviour ennemy = pool.Get(spawnPos, Quaternion.identity);
            ennemy.sp = this;
            ennemy.SetTarget(target);
        }
    }

    public void Teleport(EnnemyBehaviour ennemy)
    {
        pool.Add(ennemy);
    }
}