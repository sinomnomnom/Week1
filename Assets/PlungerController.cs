
using UnityEngine;
using UnityEngine.InputSystem;

public class PlungerController : MonoBehaviour
{
    public Sprite charged;
    public Sprite uncharged;

    public Collider2D col;

    public SpriteRenderer sprite;

    public InputAction fire;

    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fire.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.WasReleasedThisFrame())
        {
            Fire();
            sprite.sprite = uncharged;
        }

        if (fire.WasPressedThisFrame())
        {
            sprite.sprite = charged;
        }
    }

    public void Fire()
    {
        Collider2D[] contacts = new Collider2D[1];
        col.GetContacts(contacts);
        foreach(Collider2D contact in contacts)
        {
            if (contact ==  null) continue;
            if(contact.gameObject.tag == "Ball")
            {
                contact.attachedRigidbody.AddForce(Vector2.up*force, ForceMode2D.Impulse);
            }
        }
    }
}
