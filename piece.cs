using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece : MonoBehaviour {

    int pieceSize;
    int gridSize;
    public int lastPressed = 0;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float blocksize = 3.0f;
    bool active = true;

    bool inBounds()
    {
        if (transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax)
        {
            return false;
        }
        return true;
    }

    bool isValidGridPos()
    {
        Vector2 v = transform.position;
//        Debug.Log("Transform:" + ((v.x - xMin) / pieceSize).ToString() + " " + (((gridSize-1) - (v.y - yMin) / pieceSize)).ToString());

        if (!inBounds())
            return false;

        if (Grid.grid[(int)((v.x - xMin) / pieceSize), (int)(((gridSize-1)-(v.y - yMin) / pieceSize))] != null)
            return false;

        return true;
    }

    void updateGrid()
    {
        for (int y = 0; y < gridSize; y++)
            for (int x = 0; x < gridSize; x++)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y] == transform)
                        Grid.grid[x, y] = null;

        Vector2 v = transform.position;
        Grid.grid[(int)((v.x - xMin) / pieceSize), (int)(((gridSize - 1) - (v.y - yMin) / pieceSize))] = transform;

    }

    // Use this for initialization
    void Start () {
        pieceSize = 3;
        gridSize = 4;
        xMin = 23.5f;
        xMax = xMin + (gridSize - 1) * pieceSize;
        yMin = 10.5f;
        yMax = yMin + (gridSize - 1) * pieceSize;
    }
	
	// Update is called once per frame
	void Update () {

        manager managerInst = FindObjectOfType<manager>();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lastPressed = 2;
//            Debug.Log(lastPressed);

            transform.position += new Vector3(0, 3, 0);
            while (isValidGridPos())
                transform.position += new Vector3(0, 3, 0);
            transform.position -= new Vector3(0, 3, 0);

            updateGrid();
//            Grid.printGrid();

            if (active)
            {
                managerInst.spawnNext(lastPressed);
                active = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastPressed = 3;
 //           Debug.Log(lastPressed);

            transform.position += new Vector3(3, 0, 0);
            while (isValidGridPos())
                transform.position += new Vector3(3, 0, 0);
            transform.position -= new Vector3(3, 0, 0);

            updateGrid();
//            Grid.printGrid();

            if (active)
            {
                managerInst.spawnNext(lastPressed);
                active = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lastPressed = 0;
//            Debug.Log(lastPressed);

            transform.position += new Vector3(0, -3, 0);
            while (isValidGridPos())
                transform.position += new Vector3(0, -3, 0);
            transform.position -= new Vector3(0, -3, 0);

            updateGrid();
//            Grid.printGrid();

            if (active)
            {
                managerInst.spawnNext(lastPressed);
                active = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastPressed = 1;
//            Debug.Log(lastPressed);

            transform.position += new Vector3(-3, 0, 0);
            while (isValidGridPos())
                transform.position += new Vector3(-3, 0, 0);
            transform.position -= new Vector3(-3, 0, 0);

            updateGrid();
//            Grid.printGrid();

            if (active)
            {
                managerInst.spawnNext(lastPressed);
                active = false;
            }
        }
    }
}
