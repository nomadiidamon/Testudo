using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridDungeonManager : MonoBehaviour
{
    public static GridDungeonManager Instance { get; private set; } // Singleton instance
    public bool generate = false;
    public bool isFinished = false;
    public bool isFinishedMakingRooms = false;
    public bool dungeonIsPathable = false;



    [Header("Prefabs")]
    public GameObject roomFloorPrefab;
    public GameObject roomDoorPrefab;
    [Space(10)]

    [Header("World Parameters")]
    [Range(1, 500)] public int WorldWidth = 100;
    [Range(1, 500)] public int WorldHeight = 5;
    [Range(1, 500)] public int WorldLength = 100;
    public int NumOfRooms = 0;
    [Space(10)]

    [Header("Room Parameters")]
    [Range(1, 50)] public int RoomWidth = 15;
    [Range(1, 50)] public int RoomHeight = 15;
    [Range(1, 50)] public int RoomLength = 15;
    [Space(10)]

    [Header("Room Distance")]
    [Range(0, 5)] public float distanceFactor = 0.5f;

    [Header("Collections")]
    public List<Room> rooms = new List<Room>();
    public List<Wall> walls = new List<Wall>();
    public List<Wall> boundaryWalls = new List<Wall>();

    private Vector3 currentWorldSize = Vector3.zero;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        NumOfRooms = WorldWidth * WorldLength;
    }

    void Update()
    {
        if (!isFinished)
        {
            if (rooms.Count >= NumOfRooms)
            {
                isFinishedMakingRooms = true;
            }
            else
            {
                GenerateGridDungeon();
                SetWorldBoundaries();
            }

            if (isFinishedMakingRooms)
            {
                CheckPaths();

                //if (!IsPathable())
                //{
                    RemoveWalls();

                //}
            }




        }
    }


    public void GenerateGridDungeon()
    {
        GenerateGridOfRooms();
    }

    void GenerateGridRoom(Vector3 position, int width, int height, int length)
    {
        GameObject roomObject = Instantiate(roomFloorPrefab, position, Quaternion.identity);
        Room room = roomObject.GetComponent<Room>();
        if (room != null)
        {
            room.roomBounds.size = new Vector3(width, height, length);
            rooms.Add(room);
            walls.Add(room.northWall);
            walls.Add(room.eastWall);
            walls.Add(room.southWall);
            walls.Add(room.westWall);
        }
    }

    void GenerateGridOfRooms()
    {
        currentWorldSize = transform.position;

        for (int h = 0; h < WorldHeight; h++)
        {

            for (int i = 0; i < WorldWidth; i++)
            {

                for (int j = 0; j < WorldLength; j++)
                {
                    if (currentWorldSize.HasObjectWithLayerInBox(LayerMask.NameToLayer("PG_Room"), new Vector3(RoomLength / 2, RoomWidth / 2, RoomHeight / 2)))
                    {
                        continue;
                    }
                    GenerateGridRoom(currentWorldSize, RoomWidth, RoomHeight, RoomLength);
                    currentWorldSize = currentWorldSize.Add(z: 1 * distanceFactor);
                }
                currentWorldSize = currentWorldSize.WithZ(transform.position.z);
                currentWorldSize = currentWorldSize.Add(x: 1 * distanceFactor);
            }
            currentWorldSize = currentWorldSize.WithX(transform.position.x);
            currentWorldSize = currentWorldSize.Add(y: 1 * distanceFactor);

        }

    }

    public void SetWorldBoundaries()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].IsBoundary();
        }

        for (int i = 0; i < walls.Count; i++)
        {
            if (walls[i].iAmBoundaryWall)
            {
                boundaryWalls.Add(walls[i]);
                walls[i].gameObject.SetMaterialColor(Color.white);
            }
        }
    }

    public void RemoveWalls()
    {
        //randomly deactivate walls
        int randomNum = UnityEngine.Random.Range(0, 15);
        int max = rooms.Count;
        for (int i = max; i < (max % (randomNum +1)); i--)
        {
            int newRandomNum = UnityEngine.Random.Range(0, 15);
            rooms[i].DisableWall(newRandomNum);
        }
         
    }

    public void CheckPaths()
    {
        // Test dungeon for pathing

        //if traversable set dungeonIsPathable to true

        // otherwise set it to false and call remove walls again
    }

    public bool IsPathable()
    {
        if (dungeonIsPathable)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
