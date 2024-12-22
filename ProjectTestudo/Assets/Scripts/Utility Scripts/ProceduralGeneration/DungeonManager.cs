﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set; } // Singleton instance
    public bool isRandom = true;
    public bool isFinishedMakingRooms = false;
    public bool isFinishedRemovingWalls = false;
    public bool isFinishedCheckingPaths = false;
    public bool isFinishedAdjustingRooms = false;
    public bool isFinished = false;

    [Header("Random World Parameters")]
    [Range(5,100)]public int randMinWorldWidth = 25;
    [Range(5, 200)]public int randMaxWorldWidth = 100;
    [Space(3)]
    [Range(5, 100)] public int randMinWorldLength = 20;
    [Range(5, 200)] public int randMaxWorldLength = 100;
    [Space(3)]
    [Range(1, 10)] public int randMinWorldHeight = 1;
    [Range(11, 100)] public int randMaxWorldHeight = 3;
    [Space(3)]
    [Range(5, 100)] public int randMaxNumOfRooms = 25;
    [Space(10)]

    [Header("Random Room Parameters")]
    [Range(1,50)]public int randMinRoomWidth = 5;
    [Range(1,50)]public int randMaxRoomWidth = 15;
    [Space(3)]
    [Range(1, 50)] public int randMinRoomHeight = 5;
    [Range(1, 50)] public int randMaxRoomHeight = 15;
    [Space(3)]
    [Range(1, 50)] public int randMinRoomLength = 5;
    [Range(1, 50)] public int randMaxRoomLength = 15;
    [Space(3)]
    [Range(1, 25)] public int randMinNumberOfRooms = 3;
    [Range(1, 500)] public int randMaxNumberOfRooms = 10;
    [Space(10)]



    //[Header("Room Offsets")]
    //public float xOffset = 0.05f; // Offset between rooms on the X-axis
    //public float yOffset = 0.05f; // Offset between rooms on the Y-axis
    //public float zOffset = 0.05f; // Offset between rooms on the Z-axis





    [Header("World Parameters")]
    [Range(5, 500)] public int WorldWidth = 100;
    [Space(3)]
    [Range(1, 500)] public int WorldHeight = 5;
    [Space(3)]
    [Range(5, 500)] public int WorldLength = 100;
    [Space(3)]
    public int NumOfRooms = 0;
    [Space(10)]

    [Header("Room Parameters")]
    [Range(1, 50)] public int RoomWidth = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomHeight = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomLength = 15;
    [Space(3)]



    [Header("Prefabs")]
    public GameObject roomFloorPrefab; // Room floor prefab (thin cube)
    public GameObject corridorPrefab; // Corridor wall prefab (two walls, cieling and floor)
    [Space(10)]

    [Header("Collections")]
    public List<Room> rooms = new List<Room>();
    public List<Corridor> corridors = new List<Corridor>();

    private Vector3 currentWorldSize = Vector3.zero;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        NumOfRooms = WorldWidth * WorldLength;
    }


    public void Update()
    {
        if (!isFinished)
        {
            if (isRandom)
            {
                if (rooms.Count >= randMaxNumOfRooms)
                {
                    isFinished = true;
                    return;
                }
                GenerateRandomDungeon();
            }
            else
            {

                if (rooms.Count >= NumOfRooms)
                {
                    isFinished = true;
                    return;
                }
                GenerateGridDungeon();

            }
        }
        else
        {
            // 
        }
    }

    public void GenerateGridDungeon()
    {
        GenerateGridOfRooms();
    }

    void GenerateGridRoom(Vector3 worldSize, int width, int height, int length)
    {
        Room room = RoomFactory.CreateRoom(worldSize, width, height, length);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    void GenerateGridOfRooms()
    {
        currentWorldSize  = transform.position;

        for (int h = 0; h < WorldHeight; h++)
        {

            for (int i = 0; i < WorldWidth; i++)
            {

                for(int j = 0; j < WorldLength; j++)
                {
                    GenerateGridRoom(currentWorldSize, RoomWidth, RoomHeight, RoomLength);
                    currentWorldSize = currentWorldSize.Add(z:RoomLength);
                }
                currentWorldSize = currentWorldSize.WithZ(transform.position.z);
                currentWorldSize = currentWorldSize.Add(x: RoomWidth);
            }
            currentWorldSize = currentWorldSize.WithX(transform.position.x);
            currentWorldSize = currentWorldSize.Add(y: RoomHeight);

        }
    }


    void GenerateRandomRoom(Vector3 worldSize)
    {
        Room room = RoomFactory.CreateRandomRoom(worldSize, randMinRoomWidth, randMaxRoomWidth, randMinRoomHeight, randMaxRoomHeight, randMinRoomLength, randMaxRoomLength);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    public void GenerateRandomRooms()
    {
        int worldWidth = UnityEngine.Random.Range(randMinWorldWidth, randMaxWorldWidth);
        int worldLength = UnityEngine.Random.Range(randMinWorldLength, randMaxWorldLength);
        int worldHeight = UnityEngine.Random.Range(randMinWorldHeight, randMaxWorldHeight);
        Vector3 worldSize = new Vector3(worldWidth, worldHeight, worldLength);
        currentWorldSize = worldSize;
        int numberOfRooms = worldWidth * worldLength;
        for (int i = 0; i < numberOfRooms; i++)
        {
            GenerateRandomRoom(currentWorldSize);
        }

    }

    public void GenerateRandomDungeon()
    {
        int worldWidth = UnityEngine.Random.Range(randMinWorldWidth, randMaxWorldWidth);
        int worldLength = UnityEngine.Random.Range(randMinWorldLength, randMaxWorldLength);
        int worldHeight = UnityEngine.Random.Range(randMinWorldHeight, randMaxWorldHeight);

        Vector3 worldSize = new Vector3(worldWidth, worldHeight, worldLength);
        currentWorldSize = worldSize;
        int numberOfRooms = UnityEngine.Random.Range(randMinNumberOfRooms, randMaxNumberOfRooms);
        for (int i = 0; i < numberOfRooms; i++)
        {
            GenerateRandomRoom(currentWorldSize);
        }
    }






    private void OnDrawGizmos()
    {
        if (currentWorldSize != Vector3.zero)
        {
            Gizmos.color = Color.green;

            // Define corners
            Vector3 bottomLeft = Vector3.zero;
            Vector3 bottomRight = new Vector3(currentWorldSize.x, 0, 0);
            Vector3 topLeft = new Vector3(0, 0, currentWorldSize.z);
            Vector3 topRight = new Vector3(currentWorldSize.x, 0, currentWorldSize.z);

            // Draw bottom rectangle
            Gizmos.DrawLine(bottomLeft, bottomRight);
            Gizmos.DrawLine(bottomRight, topRight);
            Gizmos.DrawLine(topRight, topLeft);
            Gizmos.DrawLine(topLeft, bottomLeft);

            // Draw height lines
            Vector3 heightOffset = new Vector3(0, currentWorldSize.y, 0);
            Gizmos.DrawLine(bottomLeft, bottomLeft + heightOffset);
            Gizmos.DrawLine(bottomRight, bottomRight + heightOffset);
            Gizmos.DrawLine(topLeft, topLeft + heightOffset);
            Gizmos.DrawLine(topRight, topRight + heightOffset);

            // Draw top rectangle
            Gizmos.DrawLine(bottomLeft + heightOffset, bottomRight + heightOffset);
            Gizmos.DrawLine(bottomRight + heightOffset, topRight + heightOffset);
            Gizmos.DrawLine(topRight + heightOffset, topLeft + heightOffset);
            Gizmos.DrawLine(topLeft + heightOffset, bottomLeft + heightOffset);
        }
    }



}

