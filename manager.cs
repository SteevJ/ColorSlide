using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject[] pieces;

    public void spawnNext(int side)
    {
        int randColor = Random.Range(0, pieces.Length);
        Vector3 spawnLoc = new Vector3(0, 0, 0);

        if (side == 0)
        {
            // x = :, y = 0
            spawnLoc.Set(23.5f + (3 * randPos(0)), 19.5f, 0.0f);
        }
        else if (side == 1)
            // x = 3, y = :
            spawnLoc.Set(32.5f, 19.5f - (3 * randPos(1)), 0.0f);
        else if (side == 2)
            // x = :, y = 3
            spawnLoc.Set(23.5f + (3 * randPos(2)), 10.5f, 0.0f);
        else
            // x = 0, y = :
            spawnLoc.Set(23.5f, 19.5f - (3 * randPos(3)), 0.0f);

        Instantiate(pieces[randColor], spawnLoc, Quaternion.identity);
    }

    int randPos(int direction)
    {
        int y = 0;
        List<int> posList = new List<int>();

        switch (direction)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    if (Grid.grid[i, y] == null)
                        posList.Add(i);
                }
                break;
            case 1:
                y = 3;
                for (int i = 0; i < 4; i++)
                {
                    if (Grid.grid[y, i] == null)
                        posList.Add(i);
                }
                break;
            case 2:
                y = 3;
                for (int i = 0; i < 4; i++)
                {
                    if (Grid.grid[i, y] == null)
                        posList.Add(i);
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    if (Grid.grid[y, i] == null)
                        posList.Add(i);
                }
                break;
        }

//        string boi = "";
//        for (int i = 0; i < posList.Count; i++)
//        {
//            boi += " " + posList[i];
//        }
//        Debug.Log(boi);

        int test = Random.Range(0, posList.Count);
        Debug.Log(test);
        return posList[test];
    }

    // Use this for initialization
    void Start() {
        spawnNext(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
