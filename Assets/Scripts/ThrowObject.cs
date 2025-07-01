using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    // public Transform target;         // Mục tiêu
    public float speed = 30f;        // Tốc độ bắn
    public static float gravity = 9.8f;     // Gia tốc trọng trường
    public int resolution = 30;      // Số điểm để vẽ quỹ đạo

    private static Vector3 velocity;        // Vận tốc ban đầu
    private static float flightTime = 10;        // Thời gian bay
    // private bool isMoving = false;   // Kiểm tra xem đạn có đang di chuyển



    public static Vector3 CalculateArc(Transform startPoint, Transform target)
    {
        // if (target == null) return;

        // Tính toán khoảng cách
        Vector3 startPosition = startPoint.position;
        Vector3 targetPosition = target.position;
        Vector3 direction = targetPosition - startPosition;

        float horizontalDistance = new Vector2(direction.x, direction.z).magnitude;
        float verticalDistance = direction.y;
        // Xác định chiều cao cực đại (hmax)
        float hmax = Mathf.Max(targetPosition.y + 2f, startPosition.y + 2f); // Cao hơn mục tiêu ít nhất 2 đơn vị

        // Tính thời gian từ điểm bắt đầu đến đỉnh quỹ đạo
        float timeToPeak = Mathf.Sqrt(2 * (hmax - startPosition.y) / gravity);

        // Tính thời gian từ đỉnh quỹ đạo đến mục tiêu
        float timeFromPeak = Mathf.Sqrt(2 * (hmax - targetPosition.y) / gravity);

        // Tổng thời gian bay
        flightTime = timeToPeak + timeFromPeak;

        // Tính vận tốc ban đầu
        float initialVelocityY = Mathf.Sqrt(2 * gravity * (hmax - startPosition.y));
        float initialVelocityX = horizontalDistance / flightTime;

        Vector3 horizontalDirection = new Vector3(direction.x, 0, direction.z).normalized;
        velocity = horizontalDirection * initialVelocityX;
        velocity.y = initialVelocityY;
        return velocity;

    }



}
