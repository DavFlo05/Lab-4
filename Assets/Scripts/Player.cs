using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;
    private bool canShoot = true;

    private Vector2 moveInput;

    void Update()
    {
        Movement();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnShoot(InputValue value)
    {
        if (value.isPressed && canShoot)
        {
            Shooting();
        }
    }

    void Movement()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0);

        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.x > horizontalScreenLimit ||
            transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(
                transform.position.x * -1f,
                transform.position.y,
                0
            );
        }

        if (transform.position.y > verticalScreenLimit ||
            transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y * -1f,
                0
            );
        }
    }

    void Shooting()
    {
        Instantiate(
            laserPrefab,
            transform.position + new Vector3(0, 1, 0),
            Quaternion.identity
        );

        canShoot = false;

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);

        canShoot = true;
    }
}