using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationForce = 500.0f;

    public float sidewayForce = 500.0f;

    public float jumpPower = 100f;

    public bool canJump = false;
    public int damage = 1;
    public int health;
    public int maxHealth = 5;
    public Vector3 originScale;
    private Rigidbody rb;
    public TextMeshProUGUI healthtxt;
    public TextMeshProUGUI scoretxt;
    public float crouchScaleLimit = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originScale = transform.localScale;
        health = maxHealth;
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

        if (Input.GetKey(KeyCode.S))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }
    }

    void Crouch(bool isCrouch)
    {
        if (isCrouch == false)
        {
            transform.localScale = originScale;
            return;
        }

        if ((originScale.y * 0.5) < crouchScaleLimit) return;
        transform.localScale = new Vector3(
            originScale.x,
            originScale.y * 0.5f,
            originScale.z
        );
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            health = health - damage;
            healthtxt.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();
        }
    }
}