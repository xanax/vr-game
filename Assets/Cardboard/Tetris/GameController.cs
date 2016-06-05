using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject singleBlock;
    public int initialHeight = 5;

    // Use this for initialization
    void Start () {
        for(int y = 0; y < initialHeight; y++)
        {
            bool lastClear = false;
            for (int x = 0; x < Grid.width; x++)
            {
                if(Random.Range(0,2) == 1 || lastClear)
                {
                    spawnSingleBlock(new Vector2(x, y));
                    lastClear = false;
                } else
                {
                    lastClear = true;
                }
            }
        } 
    }

    void spawnSingleBlock(Vector2 position)
    {
        GameObject group = (GameObject)Instantiate(singleBlock, position, Quaternion.identity);
        group.GetComponent<Group>().updateGrid();
        group.GetComponent<Group>().inactive = true;

    }

    // Update is called once per frame
    void Update ()
    {
	     if (Input.GetButtonDown("Fire3"))
        {
            SceneManager.LoadScene("main");
        }
    }
}
