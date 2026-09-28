using UnityEngine;
using Unity.Cinemachine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float destroyPositionY = -11f;

    private GameManager gameManager;
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

        impulseSource =
            GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        Move();

        if (transform.position.y < destroyPositionY)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(
            Vector3.down * speed * Time.deltaTime
        );
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
            gameManager.MeteorDestroyed();

            if (impulseSource != null)
            {
                impulseSource.GenerateImpulse();
            }

            Destroy(whatIHit.gameObject);
            Destroy(gameObject);
        }
    }
}