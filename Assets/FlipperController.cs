using UnityEngine;
using UnityEngine.InputSystem;



public class FlipperController : MonoBehaviour
{
    public Rigidbody2D rb;
    public HingeJoint2D joint;
    public float force = 100;
    public InputAction flip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flip.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (flip.WasPressedThisFrame())
        {
            Fire();
        }
    }

    public void Fire()
    {
        rb.AddTorque(force);
    }
}
