using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // Đối tượng mà camera sẽ theo dõi
    public float smoothSpeed = 0.125f; // Tốc độ di chuyển mượt mà của camera
    public Vector3 offset; // Độ lệch giữa camera và nhân vật

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target chưa được gán cho CameraFollow2D!");
            return;
        }

        // Tính toán vị trí mong muốn
        Vector3 desiredPosition = target.position + offset;

        // Giữ nguyên trục Z để tránh camera bị lệch
        desiredPosition.z = transform.position.z;

        // Di chuyển camera một cách mượt mà
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}