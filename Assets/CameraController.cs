using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 offset;
    private Transform playerTrasform;
    // Start is called before the first frame update
    void Awake()
    {
        playerTrasform = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTrasform.position + offset;
    }
}