using UnityEngine;
using UnityEngine.InputSystem;



public class FlipperController : MonoBehaviour
{
    public Rigidbody2D rb;
    public HingeJoint2D joint;
    public float force = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            Fire();
        }
    }

    public void Fire()
    {
        rb.AddTorque(force);
    }
}
