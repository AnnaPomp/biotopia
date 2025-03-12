using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DarknessManager : MonoBehaviour
{
    [SerializeField] private Tilemap darknessTilemap;
    [SerializeField] private TileBase darknessTile;
    [SerializeField] private int revealRadius = 5;
    private HashSet<Vector2Int> exploredTiles = new HashSet<Vector2Int>();

    public void InitializeDarkness(HashSet<Vector2Int> floorPositions)
    {
        foreach (var pos in floorPositions)
        {
            darknessTilemap.SetTile((Vector3Int)pos, darknessTile);
        }
    }

    public void RevealArea(Vector2Int playerPos)
    {
        for (int x = -revealRadius; x <= revealRadius; x++)
        {
            for (int y = -revealRadius; y <= revealRadius; y++)
            {
                Vector2Int pos = playerPos + new Vector2Int(x, y);
                if (exploredTiles.Contains(pos) || darknessTilemap.GetTile((Vector3Int)pos) == null)
                    continue;

                exploredTiles.Add(pos);
                darknessTilemap.SetTile((Vector3Int)pos, null); // Remove darkness tile
            }
        }
    }
}
