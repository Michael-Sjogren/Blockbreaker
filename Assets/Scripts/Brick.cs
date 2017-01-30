using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    public AudioClip brickCrack;
    public static int breakableCount = 0;
    private bool isBreakable;
    // Use this for initialization
    public int maxhp = 3;
    private int damageTaken = 0;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public ParticleSystem smoke;

    void Start () {
        
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            smoke.transform.position = this.transform.position;
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(brickCrack, transform.position);
            handleHits(); 
        }
    }

    public void handleHits()
    {
        damageTaken++;
        if (damageTaken >= maxhp)
        {
            smoke.Play();
            Destroy(gameObject);
            breakableCount--;
          
            levelManager.isBrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }



   void LoadSprites()
    {
        int spriteIndex = damageTaken - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
