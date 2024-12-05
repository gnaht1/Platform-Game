using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip gameWinnerSound;

    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;
    private bool isMuted = false;
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null) { 
            uiManager.GameOver();
            SoundManager.instance.PlaySound(gameOverSound);
            return;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            uiManager.GameOver();
            SoundManager.instance.PlaySound(gameWinnerSound);

            return;
        }
    }
}