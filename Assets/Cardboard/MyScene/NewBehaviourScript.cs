using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject[,] map = new GameObject[20, 20];
	public GameObject[] tiles = new GameObject[4];

	void Start () {
		tiles[0] = GameObject.Find("Monkey");
		tiles[1] = GameObject.Find("Earth");
		tiles[2] = GameObject.Find("Sphere");
		//tiles[3] = GameObject.Find("Empty");
		randomMap ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void randomMap() {
		for (int x = 0; x < 10; x++) {
			for (int y = 0; y < 10; y++) {
				map[x,y] = (GameObject)Instantiate(tiles[(int)(Random.value * 3)]);
				map[x,y].transform.position = new Vector3(x-5 + (Random.value -.5f) / 1000f,y+10,0);
			}
		}
	}
}
