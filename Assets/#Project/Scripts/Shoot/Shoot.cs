using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // le modele du bullet
    [SerializeField] private Transform ShootingBall; //position
    [SerializeField] private float bulletSpeed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab,ShootingBall.position,ShootingBall.rotation );
        bullet.GetComponent<Rigidbody>().linearVelocity = ShootingBall.forward * bulletSpeed;

        // Vector3 mousePos = Input.mousePosition; // viser avec le pointeur de la souris
    }
}
