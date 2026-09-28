using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    [SerializeField] private int hitsToDestroy = 5;

    private int hitCount = 0;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.CompareTag("Player"))
        {
            gameManager.GameOver();

            Destroy(whatIHit.gameObject);
            Destroy(gameObject);
        }
        else if (whatIHit.CompareTag("Laser"))
        {
            TakeHit();

            Destroy(whatIHit.gameObject);
        }
    }

    private void TakeHit()
    {
        hitCount++;

        if (hitCount >= hitsToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
