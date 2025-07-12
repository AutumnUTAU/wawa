using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
 
    private Rigidbody rb;

    private PlayerController playerController;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
  
        if (collision.transform.CompareTag("Floor"))
        {
            playerController.canJump = true;
        }

    }
}