using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public Vector3 followOffset;

    void LateUpdate()
    {
        var posX = target.position.x + followOffset.x;
        var posZ = target.position.z + followOffset.z;
        var posY = target.position.y + followOffset.y;
            
        Vector3 newPos = new Vector3(posX, posY, posZ);
        transform.position = newPos;
            
        transform.LookAt(target);
    }
}
