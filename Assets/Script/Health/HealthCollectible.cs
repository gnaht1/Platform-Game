using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            //Deactivate the health collectible
            gameObject.SetActive(false);
        }
    }
}
