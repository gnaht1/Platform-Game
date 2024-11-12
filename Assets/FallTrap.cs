using UnityEngine;

public class FallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasFallen = false;
    public Transform recoverPoint;
    [SerializeField] float damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            rb.isKinematic = false;
            hasFallen = true;

            

            Invoke("Recover", 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void Recover()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;

        transform.position = recoverPoint.position;
        hasFallen = false;
    }


}
