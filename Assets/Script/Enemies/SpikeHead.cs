using UnityEngine;

public class SpikeHead : Enemy_Damage
{
    [SerializeField] private float speed;
    [SerializeField] private float range;

    protected Vector3 startingPosition;  // Để lớp con có thể truy cập
    protected Vector3 targetPosition;    // Để lớp con có thể truy cập
    private bool movingToTarget;

    private void Start()
    {
        // Lưu vị trí ban đầu để làm điểm xuất phát khi di chuyển
        startingPosition = transform.position;
        SetTargetPosition();
    }

    private void Update()
    {
        // Di chuyển qua lại hoặc lên xuống giữa vị trí bắt đầu và vị trí đích
        if (movingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                movingToTarget = false; // Đã đến vị trí đích, quay lại vị trí ban đầu
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
            {
                movingToTarget = true; // Đã đến vị trí ban đầu, quay lại vị trí đích
            }
        }
    }

    protected virtual void SetTargetPosition()
    {
        // Thiết lập vị trí đích cách vị trí ban đầu theo phạm vi di chuyển (range)
        targetPosition = startingPosition + new Vector3(range, 0, 0); // Di chuyển theo trục X
    }
}
