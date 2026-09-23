using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Paddle : MonoBehaviour
{

    public float force = 1;
    public float maxAngle = 30;
    public float minAngle = -10;
    public float gravity = -1f;

    public float bounciness = .1f;

    private float angularVelocity = 0;

    [SerializeField]
    private Rigidbody2D rb;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Fire();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            Fire();
        }

        angularVelocity += Time.deltaTime * gravity;

        transform.Rotate(0,0,angularVelocity*Time.deltaTime);
        //rb.MoveRotation(transform.rotation.eulerAngles.z+angularVelocity * Time.deltaTime);

        Debug.Log(((maxAngle + minAngle) / 2 + 180));

        if (transform.rotation.eulerAngles.z > maxAngle % 360 && transform.rotation.eulerAngles.z < ((maxAngle + minAngle) /2+180))
        {
            transform.rotation = Quaternion.Euler(0,0, maxAngle % 360);
            angularVelocity = -angularVelocity * bounciness;
        }
        if (transform.rotation.eulerAngles.z < ((minAngle + 360) % 360) && transform.rotation.eulerAngles.z > ((maxAngle + minAngle) / 2 + 180))
        {
            transform.rotation = Quaternion.Euler(0, 0, ((minAngle + 360) % 360));
            angularVelocity = -angularVelocity * bounciness;
        }
    }
    public void Fire()
    {
        angularVelocity += force;
    }
}
