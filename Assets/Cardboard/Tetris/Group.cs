using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {
    float lastFall = 0;
    float repeatTime = .2f;
    float downRepeatTime = .15f;
    float lastInput = float.MinValue;
    float startTime = Time.time;
    float initialDelay = .5f;

    void Start()
    {
        // Default position not valid? Then it's game over
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            //Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Time.time - startTime < initialDelay)
        {
            return;
        }
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        // check if user let go of the stick; if so, reset the input bounce control
        if (Mathf.Abs(vAxis) < 0.1f && Mathf.Abs(hAxis) < 0.1f) {
            lastInput = float.MinValue;
        }

            if (hAxis < -0.1f && Time.time - lastInput > repeatTime)
            {
                // Modify position
                transform.position += new Vector3(-1, 0, 0);

                // See if valid
                if (isValidGridPos())
                {
                    // Its valid. Update grid.
                    updateGrid();
                    lastInput = Time.time;
                }

                else
                    // Its not valid. revert.
                    transform.position += new Vector3(1, 0, 0);
            } // Move Right
            else if (hAxis > 0.1f && Time.time - lastInput > repeatTime)
            {
                // Modify position
                transform.position += new Vector3(1, 0, 0);

                // See if valid
                if (isValidGridPos())
                {
                    // It's valid. Update grid.
                    updateGrid();
                    lastInput = Time.time;
                }
                else
                    // It's not valid. revert.
                    transform.position += new Vector3(-1, 0, 0);
            }// Rotate
        else if (Input.GetButtonDown("Fire1") && Time.time - lastInput > repeatTime)
        {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
                lastInput = Time.time;
            }
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }
        else if (Input.GetButtonDown("Fire2") && Time.time - lastInput > repeatTime)
        {
            transform.Rotate(0, 0, 90);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
                lastInput = Time.time;
            }
            else
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
        }
        else if (vAxis < -0.1f && Time.time - lastInput > downRepeatTime)
            {
                moveDown();
                lastInput = Time.time;
            }
            if (Time.time - lastFall >= 1)
            {
                moveDown();
            }
    }
    private void moveDown()
    {
        // Modify position
        transform.position += new Vector3(0, -1, 0);

        // See if valid
        if (isValidGridPos())
        {
            // It's valid. Update grid.
            updateGrid();
        }
        else
        {
            // It's not valid. revert.
            transform.position += new Vector3(0, 1, 0);

            // Clear filled horizontal lines
            Grid.deleteFullRows();

            // Spawn next Group
            FindObjectOfType<Spawner>().spawnNext();

            // Disable script
            enabled = false;
        }

        lastFall = Time.time;

    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);

            // Not inside Border?
            if (!Grid.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Grid.height; ++y)
            for (int x = 0; x < Grid.width; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

}
