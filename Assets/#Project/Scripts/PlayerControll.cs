using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        float moveX = 0;
        float moveZ = 0;

        if (keyboard.rightArrowKey.isPressed)
        {
            moveZ += 1;
        }

        if (keyboard.leftArrowKey.isPressed)
        {
            moveZ -= 1;
        }

        if (keyboard.upArrowKey.isPressed)
        {
            moveX -= 1f;
        }

        if (keyboard.downArrowKey.isPressed)
        {
            moveX += 1f;
        }

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += move * speed * Time.deltaTime;

    }
}
