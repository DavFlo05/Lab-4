using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private GameObject bigMeteorPrefab;
    [Header("Meteor Spawning")]
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private int meteorsForBigMeteor = 5;
    private int meteorCount = 0;
    private bool gameOver = false;

    void Start()
    {
        Instantiate(
            playerPrefab,
            transform.position,
            Quaternion.identity
        );

        InvokeRepeating(
            nameof(SpawnMeteor),
            spawnDelay,
            spawnRate
        );
    }
    public void MeteorDestroyed()
    {
        meteorCount++;

        if (meteorCount >= meteorsForBigMeteor)
        {
            SpawnBigMeteor();

            meteorCount = 0;
        }
    }
    public void GameOver()
    {
        gameOver = true;

        CancelInvoke(nameof(SpawnMeteor));
    }

    public void OnRestart(InputValue value)
    {
        if (value.isPressed && gameOver)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }
    }

    private void SpawnMeteor()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-8f, 8f),
            7.5f,
            0f
        );

        Instantiate(
            meteorPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
    private void SpawnBigMeteor()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-8f, 8f),
            7.5f,
            0f
        );

        Instantiate(
            bigMeteorPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}