using System;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set; } // Singleton instance
    public Room room;
    public Corridor corridor;

    [Header("World Parameters")]
    [Range(5,100)]public int minWorldWidth = 25;
    [Range(5, 200)]public int maxWorldWidth = 100;
    [Space(3)]

    [Range(5, 100)] public int minWorldLength = 20;
    [Range(5, 200)] public int maxWorldLength = 100;
    [Space(3)]

    [Range(1, 5)] public int minWorldHeight = 1;
    [Range(1, 5)] public int maxWorldHeight = 3;
    [Space(3)]

    [Range(5, 100)] public int maxNumOfRooms = 25;
    [Space(10)]

    [Header("Room Parameters")]
    [Range(1,50)]public int minRoomWidth = 5;
    [Range(1,50)]public int maxRoomWidth = 15;
    [Space(3)]

    [Range(1, 50)] public int minRoomHeight = 5;
    [Range(1, 50)] public int maxRoomHeight = 15;
    [Space(3)]

    [Range(1, 50)] public int minRoomLength = 5;
    [Range(1, 50)] public int maxRoomLength = 15;
    [Space(3)]

    [Range(1, 25)] public int minNumberOfRooms = 3;
    [Range(1, 500)] public int maxNumberOfRooms = 10;
    [Space(10)]


    [Header("Corridor Parameters")]
    [Range(1, 50)] public int minCorridorWidth = 3;
    [Range(1, 50)] public int maxCorridorWidth = 5;
    [Space(3)]

    [Range(1, 50)] public int minCorridorHeight = 3;
    [Range(1, 50)] public int maxCorridorHeight = 5;
    [Space(3)]

    [Range(1, 50)] public int minCorridorLength = 3;
    [Range(1, 50)] public int maxCorridorLength = 5;
    [Space(3)]

    [Range(1, 50)] public int minNumberOfCorridors = 2;
    [Range(1, 50)] public int maxNumberOfCorridors = 5;
    [Space(10)]


    [Header("Prefabs")]
    public GameObject roomFloorPrefab; // Room floor prefab (thin cube)
    public GameObject corridorPrefab; // Corridor wall prefab (two walls, cieling and floor)
    [Space(10)]

    [Header("Collections")]
    private List<Room> rooms = new List<Room>();
    private List<Corridor> corridors = new List<Corridor>();

    private Vector3 currentWorldSize;

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
        if (rooms.Count >= maxNumOfRooms) {
            return;
        } else
        {

            GenerateDungeon();
        }
    }


    public void GenerateDungeon()
    {
        int worldWidth = UnityEngine.Random.Range(minWorldWidth, maxWorldWidth);
        int worldLength = UnityEngine.Random.Range(minWorldLength, maxWorldLength);
        int worldHeight = UnityEngine.Random.Range(minWorldHeight, maxWorldHeight);

        Vector3 worldSize = new Vector3(worldWidth, worldHeight, worldLength);
        currentWorldSize = worldSize;
        int numberOfRooms = UnityEngine.Random.Range(minNumberOfRooms, maxNumberOfRooms);
        for (int i = 0; i < numberOfRooms; i++)
        {
            GenerateRoom(currentWorldSize);
        }

        int numberOfCorridors = UnityEngine.Random.Range(minNumberOfCorridors, maxNumberOfCorridors);
        for (int i = 0; i < numberOfCorridors; i++)
        {
            GenerateCorridor(currentWorldSize);
        }
    }

    void GenerateRoom(Vector3 worldSize)
    {
        Room room = RoomFactory.CreateRoom(worldSize, minRoomWidth, maxRoomWidth, minRoomHeight, maxRoomHeight, minRoomLength, maxRoomLength);
        if (room != null)
        {
            rooms.Add(room);
        }
    }

    void GenerateCorridor(Vector3 worldSize)
    {
        Corridor corridor = CorridorFactory.CreateCorridor(worldSize, minCorridorWidth, maxCorridorWidth, minCorridorHeight, maxCorridorHeight);
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

