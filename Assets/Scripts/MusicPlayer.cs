using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer instance = null;
	// Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        } else
            {
                Destroy(gameObject);
            }
    }
	void start () {
  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
