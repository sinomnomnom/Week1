using UnityEngine;
using DigitalRuby.Tween;

public class ActiveBumper : MonoBehaviour
{
    public float force = 1;
    public AudioClip bounceSound;
    public AudioSource audioSource;
    public float bounceSize = 1;
    public float bounceSpeed = 1;
    public GameObject sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collision w ball");
            collision.rigidbody.AddForce(-collision.GetContact(0).normal * force, ForceMode2D.Impulse);
            audioSource.PlayOneShot(bounceSound);

            System.Action<ITween<Vector3>> bounce = (t) =>
            {
                sprite.transform.localScale = t.CurrentValue;
            };

            Vector3 endScale = sprite.transform.localScale * bounceSize;
            sprite.Tween("spriteSize", sprite.transform.localScale, endScale, bounceSpeed/2, TweenScaleFunctions.QuadraticEaseOut, bounce)
                .ContinueWith(new Vector3Tween().Setup(endScale, sprite.transform.localScale, bounceSpeed/2, TweenScaleFunctions.Linear, bounce));
        }
    }
}

