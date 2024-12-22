using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set; } // Singleton instance
    //public Room room;
    //public Corridor corridor;
    public bool isRandom = true;

    [Header("Random World Parameters")]
    [Range(5,100)]public int randMinWorldWidth = 25;
    [Range(5, 200)]public int randMaxWorldWidth = 100;
    [Space(3)]
    [Range(5, 100)] public int randMinWorldLength = 20;
    [Range(5, 200)] public int randMaxWorldLength = 100;
    [Space(3)]
    [Range(1, 5)] public int randMinWorldHeight = 1;
    [Range(1, 5)] public int randMaxWorldHeight = 3;
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


    [Header("Random Corridor Parameters")]
    [Range(1, 50)] public int randMinCorridorWidth = 3;
    [Range(1, 50)] public int randMaxCorridorWidth = 5;
    [Space(3)]
    [Range(1, 50)] public int randMinCorridorHeight = 3;
    [Range(1, 50)] public int randMaxCorridorHeight = 5;
    [Space(3)]
    [Range(1, 50)] public int randMinCorridorLength = 3;
    [Range(1, 50)] public int randMaxCorridorLength = 5;
    [Space(3)]
    [Range(1, 50)] public int randMinNumberOfCorridors = 2;
    [Range(1, 50)] public int randMaxNumberOfCorridors = 5;
    [Space(10)]










    [Header("World Parameters")]
    [Range(5, 500)] public int WorldWidth = 100;
    [Space(3)]
    [Range(1, 5)] public int WorldHeight = 1;
    [Space(3)]
    [Range(5, 500)] public int WorldLength = 100;
    [Space(3)]
    [Range(5, 1000)] public int NumOfRooms = 25;
    [Space(10)]

    [Header("Room Parameters")]
    [Range(1, 50)] public int RoomWidth = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomHeight = 15;
    [Space(3)]
    [Range(1, 50)] public int RoomLength = 15;
    [Space(3)]

    [Header("Corridor Parameters")]
    [Range(1, 50)] public int CorridorWidth = 5;
    [Space(3)]
    [Range(1, 50)] public int CorridorHeight = 5;
    [Space(3)]
    [Range(1, 50)] public int CorridorLength = 5;
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
    }


    public void Update()
    {
        if (rooms.Count >= randMaxNumOfRooms) {
            return;
        } else
        {
            if (isRandom)
            {
                GenerateRandomRooms();
            }
            else
            {
                GenerateGridOfRooms();

            }
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
                    currentWorldSize.Add(z:RoomLength);
                }
                currentWorldSize.WithZ(transform.position.z);
                currentWorldSize.Add(x:RoomWidth);
            }
            currentWorldSize.WithX(transform.position.x);
            currentWorldSize.Add(y: RoomHeight);

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

        int numberOfCorridors = UnityEngine.Random.Range(randMinNumberOfCorridors, randMaxNumberOfCorridors);
        for (int i = 0; i < numberOfCorridors; i++)
        {
            GenerateCorridor(currentWorldSize);
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

    void GenerateGridRoom(Vector3 worldSize, int width, int height, int length)
    {
        Room room = RoomFactory.CreateRoom(worldSize, width, height, length);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    void GenerateCorridor(Vector3 worldSize)
    {
        Corridor corridor = CorridorFactory.CreateCorridor(worldSize, randMinCorridorWidth, randMaxCorridorWidth, randMinCorridorHeight, randMaxCorridorHeight);
        if (corridor != null)
        {
            corridors.Add(corridor);
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

