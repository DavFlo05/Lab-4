using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }

    public Transform GetPlayer()
    {
        return player;
    }
}
