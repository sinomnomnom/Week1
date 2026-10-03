using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WizardTower : MonoBehaviour
{
    public List<Rigidbody2D> balls = new List<Rigidbody2D>();
    public AudioSource audioSource;
    public AudioClip evilLaugh;
    public GameManager manager;
    public Collider2D body;

    public List<PopUpController> enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            collision.attachedRigidbody.simulated = false;
            balls.Add(collision.attachedRigidbody);
            audioSource.PlayOneShot(evilLaugh);
            manager.updateScore(1000);

            foreach (PopUpController controller in enemies)
            {
                controller.Activate();
            }

            if (balls.Count >= 3)
            {
                body.enabled = false;
                manager.updateScore(3000);
                foreach (Rigidbody2D ball in balls)
                {
                    ball.simulated = true;
                }
                balls.Clear();
            }
            else
            {
                manager.newBall();
            }

        }
    }
}
