using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject resetPoint;
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
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.transform.position = resetPoint.transform.position;
        }
    }
}
