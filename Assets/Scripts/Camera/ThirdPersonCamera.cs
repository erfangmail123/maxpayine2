using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.6f, 1.6f, -2.2f);
    public float smoothSpeed = 10f;
    public float lookHeight = 1.4f;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPos = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        Vector3 lookPos = target.position + Vector3.up * lookHeight;
        transform.LookAt(lookPos);
    }
}
