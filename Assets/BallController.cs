using UnityEngine;




public class BallController : MonoBehaviour
{
    public enum MagicMode
    {
        MAGIC, ULTRAMAGIC
    }

    public MagicMode mode = MagicMode.MAGIC;
    public ParticleSystem particles;

    public float timer = 0;
    public float lifetime = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enchant();
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == MagicMode.ULTRAMAGIC)
        {
            timer += Time.deltaTime;
            if(timer > lifetime)
            {
                timer = 0;
                Disenchant();
            }
        }
    }

    public void Enchant()
    {
        mode = MagicMode.ULTRAMAGIC;
        timer = 0;
        particles.Play();
    }

    public void Disenchant()
    {
        mode = MagicMode.MAGIC;
        particles.Pause();
        particles.Clear();
    }
}
