using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MagnetController : MonoBehaviour
{
    public float force;
    public float timer = 0;
    public float releaseTime = 5f;

    private bool attached = false;
    private bool active = true;

    public Light2D light2d;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
        {
            timer += Time.deltaTime;
            if (timer > releaseTime){
                timer = 0;
                attached = false;
                active = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        light2d.enabled = true;
        audioSource.Play();
    }

    private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Ball")
        {
            collision.attachedRigidbody.AddForce((transform.position - collision.gameObject.transform.position)*force);
            attached = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.Pause();
        light2d.enabled = false;
        if(active == false)
        {
            Debug.Log("likey ball");
            if (collision.gameObject.tag == "Ball")
            {
                Debug.Log("def ball");
                collision.gameObject.TryGetComponent<BallController>(out BallController ballController);
                if(ballController != null)
                {
                    Debug.Log("enchant ball");
                    ballController.Enchant();
                }
            }
        }
        active = true;
        attached = false;
        timer = 0;
    }
}
