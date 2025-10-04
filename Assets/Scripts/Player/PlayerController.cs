using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float rotateSpeed = 10f;
    public Joystick joystick; // reference to Joystick script
    public Transform cameraTransform;
    public Animator animator;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        float h = joystick != null ? joystick.Horizontal() : Input.GetAxis("Horizontal");
        float v = joystick != null ? joystick.Vertical() : Input.GetAxis("Vertical");

        Vector3 move = forward * v + right * h;
        if (move.magnitude > 0.1f)
        {
            controller.Move(move * moveSpeed * Time.deltaTime);
            Quaternion targetRot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }

        float speed = new Vector2(h, v).magnitude;
        if (animator) animator.SetFloat("Speed", speed);
    }
}