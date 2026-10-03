using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RailController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public LineRenderer lineRenderer;

    public List<Rigidbody2D> managedBalls;

    public List<Vector2> nodePositions;

    public float maxNodeDist = 1;
    List<Rigidbody2D> ballsToRemove = new List<Rigidbody2D>();

    void Start()
    {
        Vector3[] positions3d  = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions3d);
        for (int i = 0; i<positions3d.Length; i++)
        {
            positions3d[i] = transform.TransformPoint(positions3d[i]);
        }
        foreach (var position3d in positions3d)
        {
            nodePositions.Add(new Vector2(position3d.x, position3d.y));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (managedBalls.Count <= 0) return;

        foreach (Rigidbody2D ball in managedBalls)
        {
            float speed = ball.linearVelocity.magnitude;
            Vector2 direction = getVectorToNextNode(ball.position, ball.linearVelocity);
            if (direction != Vector2.zero)
            {
                ball.linearVelocity = getVectorToNextNode(ball.position, ball.linearVelocity) * speed;
            }
            else
            {
               ballsToRemove.Add(ball);
            }
        }

        foreach(var ball in ballsToRemove)
        {
            managedBalls.Remove(ball);
            ball.gameObject.TryGetComponent<Collider2D>(out Collider2D col);
            if(col != null)
            {
                col.isTrigger = false;
                ball.gameObject.layer = 0;
            }
        }
        ballsToRemove.Clear();
    }

    Vector2 getVectorToNextNode(Vector2 pos, Vector2 velocity)
    {
        Vector2 direction = Vector2.zero;
        float minDist = maxNodeDist;
        float maxDot = 0;
        for(int i = 0; i < nodePositions.Count -1; i++)
        {
            if (Vector2.Dot(velocity, nodePositions[i+1] - pos) < 0)
            {
                continue;
            }
            if (minDist > Vector2.Distance(pos, nodePositions[i + 1])){
                if (maxDot < Vector2.Dot(velocity, nodePositions[i + 1] - nodePositions[i]))
                {
                    maxDot = Vector2.Dot(velocity, nodePositions[i + 1] - nodePositions[i]);
                    direction = Vector2.Normalize(nodePositions[i + 1] - nodePositions[i]);
                }
            }
        }
        return direction;
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collision w ball");
            if (!managedBalls.Contains(collision.attachedRigidbody))
            {
                managedBalls.Add(collision.attachedRigidbody);
                collision.isTrigger = true;
                collision.gameObject.layer = 3;
            }
        }
    }
}
