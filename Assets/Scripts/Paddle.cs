using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
    Vector3 paddlePos;
    public bool autoPlay = false;
    private Ball ball;
    // Use this for initialization
    void Start () {
       paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
       ball = GameObject.FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }else
        {
            AutoPlay();
        }
        
	}

    void MoveWithMouse()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 14.5f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0f, 14.5f);
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0f, 14.5f);
        this.transform.position = paddlePos;
    }
}
