using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI text;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject ballPrefab;
    public GameObject resetPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int delta)
    {
        score += delta;
        text.text = score.ToString();
        audioSource.PlayOneShot(audioClip);
    }

    public void newBall()
    {
        Instantiate(ballPrefab, resetPoint.transform.position, Quaternion.identity);
    }
}
