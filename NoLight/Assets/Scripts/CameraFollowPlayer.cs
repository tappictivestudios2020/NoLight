using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform player;
    [SerializeField]private Vector3 offset;
    //private float smoothTime = 10f;

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 playerPosition = player.position + offset;
        //Vector3 smoothCamera = Vector3.Lerp(transform.position,playerPosition,smoothTime*Time.fixedDeltaTime);
        transform.position = playerPosition;
    }

}
