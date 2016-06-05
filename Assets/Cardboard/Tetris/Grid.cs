using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < width &&
                (int)pos.y >= 0);
    }
    public static void deleteRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }
    public static void decreaseRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            decreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }
    public static void deleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            int count = 0;
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
                count++;
            }
            int score;
            switch(count)
            {
                case 1:
                    score = 40;
                    break;
                case 2:
                    score = 100;
                    break;
                case 3:
                    score = 300;
                    break;
                case 4:
                    score = 1200;
                    break;
                default:
                    score = 0;
                    break;
            }
            FindObjectOfType<Canvas>().incScore(score);
        }
    }
}
