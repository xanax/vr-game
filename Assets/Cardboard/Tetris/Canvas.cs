using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Canvas : MonoBehaviour {

    Text text;

    public int score;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: "+score;
	}

    public void incScore(int amount)
    {
        this.score += amount;
    }

}
