using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleMobileInput : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 360f;
    public FixedJoystick moveJoystick; // لینک به UI joystick

    private CharacterController controller;
    private Vector3 moveDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (moveJoystick == null) return;

        float horizontal = moveJoystick.Horizontal;
        float vertical = moveJoystick.Vertical;

        Vector3 input = new Vector3(horizontal, 0, vertical);
        if (input.sqrMagnitude > 0.01f)
        {
            moveDir = input.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(moveDir), rotationSpeed * Time.deltaTime);
        }

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
