using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    private float speed = 6f;
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
        Vector3 movement = new Vector3(
            moveInput.x,
            moveInput.y,
            0
        );

        transform.Translate(
            movement * speed * Time.deltaTime
        );
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