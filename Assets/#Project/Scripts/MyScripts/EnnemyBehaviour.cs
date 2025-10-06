using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour, IPoolClient
{
    [HideInInspector] public Spawn sp;

    private Transform target;
    private float speed = 3f;

    public void Appear(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void fall()
    {
        gameObject.SetActive(false);
    }

    public void Teleport()
    {
        sp.Teleport(this);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    void Update()
    {
        // if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
