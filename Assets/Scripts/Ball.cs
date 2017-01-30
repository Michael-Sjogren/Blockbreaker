using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private AudioSource audio;

    // Use this for initialization
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0)){
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f , 10f);
                audio.Play();
            }
        }
	}


    public void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
        if (hasStarted)
        {
            audio.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
