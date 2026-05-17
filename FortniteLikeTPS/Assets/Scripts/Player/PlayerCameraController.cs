using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform target;          // プレイヤーの頭あたり
    public Vector3 offset = new Vector3(0, 2, -4);
    public float rotateSpeed = 120f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    float yaw;
    float pitch;

    void LateUpdate()
    {
        if (target == null) return;

        // 位置
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPos = target.position + rot * offset;
        transform.position = desiredPos;

        // 向き
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }

    public void TickLook(Vector2 lookInput)
    {
        yaw += lookInput.x * rotateSpeed * Time.deltaTime;
        pitch -= lookInput.y * rotateSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    public Vector3 GetForward()
    {
        return transform.forward;
    }
}

