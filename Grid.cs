using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public static Transform[,] grid = new Transform[4, 4];

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static void printGrid()
    {
        string[,] textArr = new string[1, 4];

        for (int y = 0; y < 4; y++)
        {
            textArr[0, y] = y + "\t";
            for (int x = 0; x < 4; x++)
                if (grid[x, y] == null)
                    textArr[0, y] += "0";
                else
                    textArr[0, y] += "1";

//            Debug.Log(textArr[0, y]);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
