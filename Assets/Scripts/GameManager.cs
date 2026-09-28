using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;

    public bool gameOver = false;
    public int meteorCount = 0;

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);

        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

    public void OnRestart(InputValue value)
    {
        if (value.isPressed && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }
    }

    void SpawnMeteor()
    {
        Instantiate(
            meteorPrefab,
            new Vector3(Random.Range(-8, 8), 7.5f, 0),
            Quaternion.identity
        );
    }

    void BigMeteor()
    {
        meteorCount = 0;

        Instantiate(
            bigMeteorPrefab,
            new Vector3(Random.Range(-8, 8), 7.5f, 0),
            Quaternion.identity
        );
    }
}