using UnityEngine;

public class GridSystem
{
    private int _width;
    private int _height;
    private float Cellsize;
    private int[,] _gridArray;
    public GridSystem(int width, int height, float cellsize)
    {
        _width = width;
        _height = height;

        _gridArray = new int[_width, _height];
        Debug.Log("GridSystem created with width: " + _width + " and height: " + _height);
        Cellsize = cellsize;

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0,_height), GetWorldPosition(_width, _height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width, _height), Color.white, 100f);
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * Cellsize;
    }
}
 