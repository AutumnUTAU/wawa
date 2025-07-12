using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationForce = 500.0f;

    public float sidewayForce = 500.0f;

    public float jumpPower = 100f;

    public bool canJump = false;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, 0, accelerationForce * Time.deltaTime));
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-sidewayForce * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(sidewayForce * Time.deltaTime, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
}
