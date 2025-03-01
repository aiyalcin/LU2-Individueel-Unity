using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TileMenuManager : MonoBehaviour
{
    public Tilemap Tilemap; // Reference to your Tilemap
    public TileBase[] Tiles; // Array of all available tiles
    public Button[] TileButtons; // Array of buttons corresponding to tiles

    private TileBase _selectedTile; // Currently selected tile

    private void Start()
    {
        // Assign button click listeners
        for (int i = 0; i < TileButtons.Length; i++)
        {
            int index = i; // Capture the index for the closure
            TileButtons[index].onClick.AddListener(() => SelectTile(index));
        }
    }

    private void SelectTile(int tileIndex)
    {
        _selectedTile = Tiles[tileIndex];
        Debug.Log("Selected Tile: " + _selectedTile.name);
    }

    public TileBase GetSelectedTile()
    {
        return _selectedTile;
    }
}