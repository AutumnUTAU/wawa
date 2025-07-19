using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public float Knockback = 20f;
    public int hitDamage = 1;
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
        if (collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("player hit obstable ow");

            rb.AddForce(new Vector3(0, 10, -Knockback), ForceMode.Impulse);

        }

        if (collision.transform.CompareTag("Floor"))
        {
            playerController.canJump = true;
        }

    }
}