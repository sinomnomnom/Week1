using UnityEngine;

public class PointsTrigger : MonoBehaviour
{
    public int pointValue = 100;
    public GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.updateScore(pointValue);
    }
}
