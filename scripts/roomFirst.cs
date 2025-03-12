using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomFirst : Simplerandomwalkdungeongen
{
    [SerializeField]
    private int minRoomW = 4, minRoomH = 4;
    [SerializeField]
    private int dunW = 20, dunH = 20;
    [SerializeField]
    [Range(0, 10)]
    private int offset = 1;
    [SerializeField]
    private bool randomWalkRooms = false;


    protected override void RunProcGen()
    {
        CreateRooms();
    }

    private void CreateRooms()
    {
        var roomList = Proceduralgen.BinarySpacePart(new BoundsInt((Vector3Int)startpos, new Vector3Int
            (dunW, dunH, 0)), minRoomW, minRoomH);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        floor = CreateSimpleRooms(roomList);
        tilemapVisualizer.PaintFloorTiles(floor);
        wallgen.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateSimpleRooms(List<BoundsInt> roomList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomList)
        {
            for (int col = offset; col < room.size.x - offset; col++)
            {
                for (int row = offset; row < room.size.y - offset; row++)
                {
                    Vector2Int pos = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(pos);
                }
            }
        }
        return floor;
    }
}
