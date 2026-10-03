using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public Collider2D collider;
    public SpriteRenderer spriteRenderer;

    public Sprite active;
    public Sprite inactive;

    public float force = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        collider.enabled = true;
        spriteRenderer.sprite = active;
    }

    public void Deactivate()
    {
        collider.enabled = false;
        spriteRenderer.sprite = inactive;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.rigidbody.AddForce(-collision.GetContact(0).normal * force, ForceMode2D.Impulse);
            if (collision.gameObject.TryGetComponent<BallController>(out BallController ballController))
            {
                if(ballController.mode == BallController.MagicMode.ULTRAMAGIC)
                {
                    Deactivate();
                }
            }
        }
    }
}
