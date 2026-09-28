using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float destroyPositionY = 11f;

    void Update()
    {
        Move();

        if (transform.position.y > destroyPositionY)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
