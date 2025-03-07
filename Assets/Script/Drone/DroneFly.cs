using UnityEngine;

public class DroneFly : MonoBehaviour
{
    public Transform ownerPos;
    public float height = 10f;
    public float radius = 5f;
    public float speed = 5f;
    public float acceleration = 2f; // Gia tốc
    public float turnSpeed = 2f; // Tốc độ lượn
    public float wobbleAmount = 0.01f;
    public float wobbleSpeed = .1f; // Tốc độ lắc lư
    private Vector3 standardPos;
    private float currentSpeed;

    void Start()
    {
        standardPos = new Vector3(ownerPos.position.x, height, ownerPos.position.z);
        transform.position = standardPos;
        currentSpeed = 0f; // Bắt đầu với tốc độ 0
    }

    void Update()
    {
        standardPos = new Vector3(ownerPos.position.x, height, ownerPos.position.z);
        float distance = Vector3.Distance(transform.position, standardPos);

        if (distance > 2f)
        {
            FlyToTarget();
        }
        else{
            Wobble();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(standardPos, radius);
    }

    void FlyToTarget()
    {
        // Tính toán gia tốc
        if (currentSpeed < speed)
        {
            currentSpeed += acceleration * Time.deltaTime; // Tăng tốc độ
        }

        Vector3 direction = (standardPos - transform.position).normalized;

        // Xử lý lượn
        Vector3 targetPosition = standardPos + Vector3.up * Mathf.Sin(Time.time * turnSpeed) * 2f; // Thêm yếu tố lượn
        direction = (targetPosition - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
    }
    public void Wobble()
    {
        // Tạo hiệu ứng lắc lư
        float wobbleX = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        float wobbleZ = Mathf.Cos(Time.time * wobbleSpeed) * wobbleAmount;

        transform.position = new Vector3(transform.position.x + wobbleX, transform.position.y, transform.position.z + wobbleZ);
    }

}