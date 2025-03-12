using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class roomfirstdun : Simplerandomwalkdungeongen
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

        if(randomWalkRooms)
        {
            floor = createRoomsRandomly(roomList);
        }
        else
        {
            floor = CreateSimpleRooms(roomList);
                }


        floor = CreateSimpleRooms(roomList);
        List<Vector2Int> roomCenters = new List<Vector2Int>();
        foreach(var room in roomList)
        {
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }

        HashSet<Vector2Int> corridors = ConnectRooms(roomCenters);
        floor.UnionWith(corridors);
        tilemapVisualizer.PaintFloorTiles(floor);
        wallgen.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> createRoomsRandomly(List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomsList.Count; i++)
        {
            var roomBounds = roomsList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = RandomWalk( randomWalkParam,roomCenter);
            foreach (var position in roomFloor)
            {
if(position.x>=(roomBounds.xMin+offset)&& position.x<=(roomBounds.xMax-offset)&& 
                    position.y>=(roomBounds.yMin-offset)&&position.y<=(roomBounds.yMax-offset))
                {
                    floor.Add(position);
                }
            }
        }
        return floor;

    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var currrentRoomCenter = roomCenters[Random.Range(0, roomCenters.Count)];
        roomCenters.Remove(currrentRoomCenter);

        while(roomCenters.Count>0)
        {
            Vector2Int closest = FindClosestPointTo(currrentRoomCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(currrentRoomCenter, closest);
            currrentRoomCenter = closest;
            corridors.UnionWith(newCorridor);
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currrentRoomCenter, Vector2Int destination)
    {
       
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currrentRoomCenter;
        corridor.Add(position);
        while(position.y!=destination.y)
        {
            if(destination.y>position.y)
            {
                position += Vector2Int.up;

            }
            else 
                if(destination.y<position.y)
            {
                position += Vector2Int.down;
            }
            corridor.Add(position);
        }
        while (position.x!=destination.x)
        {
            if(destination.x>position.x)
            {
                position += Vector2Int.right;

            }else if(destination.x<position.x)
            {
                position += Vector2Int.left;
            }
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currrentRoomCenter, List<Vector2Int> roomCenters)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach(var position in roomCenters)
        {
            float currentDist = Vector2.Distance(position, currrentRoomCenter);
            if(currentDist<distance)
            {
                distance = currentDist;
                closest = position;
            }
        }
        return closest;
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

