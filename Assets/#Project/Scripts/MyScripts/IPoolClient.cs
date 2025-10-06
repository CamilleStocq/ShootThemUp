using UnityEngine;

public interface IPoolClient
{
    void Appear(Vector3 position, Quaternion rotation);
    void fall();
}
