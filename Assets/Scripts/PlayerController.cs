using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private int jumpCount = 0;

    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private Animator anim;

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnJump()
    {
        if (jumpCount >= 2) return;

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        anim.SetBool("IsJump", true);
        jumpCount++;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Stage"))
        {
            jumpCount = 0;
            anim.SetBool("IsJump", false);
        }
    }
}
