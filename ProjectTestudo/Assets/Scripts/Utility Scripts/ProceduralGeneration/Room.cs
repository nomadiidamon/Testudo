using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    BoxCollider roomBounds;
    public Vector3 center;

    public bool isNorth, isSouth, isEast, isWest;
    public bool hasNorth, hasSouth, hasEast, hasWest;
    public GameObject[] walls = new GameObject[4];
    public Dictionary<Vector3, GameObject> wallsToLocation = new Dictionary<Vector3, GameObject>();

    Transform Top_Middle, Bottom_Middle, Left_Middle, Right_Middle;



    public Room(Vector3 position, int width, int height, int length, GameObject roomFloorPrefab)
    {
        if (position.HasObjectWithLayerInBox(LayerMask.NameToLayer("PG_Floor"), new Vector3(width, height, length)))
        {
            return;
        }

        if (position.HasObjectWithLayerInBox(LayerMask.NameToLayer("PG_Room"), new Vector3(width / 2, height / 2, length / 2)))
        {
            Debug.Log("Cant produce");
            return;
        }

        if (roomFloorPrefab == null)
        {
            Debug.LogError("Room floor prefab is null. Cannot create room.");
            return;
        }

        GameObject roomFloor = Object.Instantiate(roomFloorPrefab, position, Quaternion.identity);
        roomBounds = roomFloor.GetOrAdd<BoxCollider>();
        roomBounds.size = new Vector3(width, height, length);
        roomFloor.ScaleStaticChildrenWithMesh(new Vector3(width, height, length));
        //center = position + new Vector3(width / 2f, height / 2f, length / 2f);
        center = new Vector3(roomBounds.bounds.center.x, roomBounds.bounds.center.y, roomBounds.bounds.center.z);

        Top_Middle = roomFloor.FindChildByName("Top_Middle").GetOrAdd<Transform>();
        Bottom_Middle = roomFloor.FindChildByName("Bottom_Middle").GetOrAdd<Transform>();
        Left_Middle = roomFloor.FindChildByName("Left_Middle").GetOrAdd<Transform>();
        Right_Middle = roomFloor.FindChildByName("Right_Middle").GetOrAdd<Transform>();

        // get all the positions of the children that have the name "PG_Wall"

        List<GameObject> objects = roomFloor.transform.GetAllChildren();
        
        

        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name.Equals("PG_Wall"))
            {
                // if the room has a child with the name "PG_Wall",
                // compare the wall's position to top, bottom, left, and right middle
                wallsToLocation.Add(objects[i].transform.position, objects[i]);
                float one = Vector3.Distance(objects[i].transform.position, Top_Middle.position);
                float two = Vector3.Distance(objects[i].transform.position, Bottom_Middle.position);
                float three = Vector3.Distance(objects[i].transform.position, Left_Middle.position);
                float four = Vector3.Distance(objects[i].transform.position, Right_Middle.position);


                // if the wall is closer to the top middle, set its position to the top middle and add it to the wallsToLocation dictionary

                if (one < two && one < three && one < four)
                {
                    objects[i].transform.SwapPositionWith(Top_Middle);
                }
                // if the wall is closer to the bottom middle, set its position to the bottom middle and add it to the wallsToLocation dictionary
                else if (two < one && two < three && two < four)
                {
                    objects[i].transform.SwapPositionWith(Bottom_Middle);
                }
                // if the wall is closer to the left middle, set its position to the left middle and add it to the wallsToLocation dictionary
                else if (three < one && three < two && three < four)
                {
                    objects[i].transform.SwapPositionWith(Left_Middle);
                }
                // if the wall is closer to the right middle, set its position to the right middle and add it to the wallsToLocation dictionary
                else if (four < one && four < two && four < three)
                {
                    objects[i].transform.SwapPositionWith(Right_Middle);
                }
    
            }
        }



        // if the wall is closer to the top middle, set its position to the top middle and add it to the wallsToLocation dictionary

        // if the wall is closer to the bottom middle, set its position to the bottom middle and add it to the wallsToLocation dictionary

        // if the wall is closer to the left middle, set its position to the left middle and add it to the wallsToLocation dictionary

        // if the wall is closer to the right middle, set its position to the right middle and add it to the wallsToLocation dictionary



        // send a raycast from the walls outwards to see if it does not have a neighbor room in that direction
        // If a neighboring room is detected (layer "PG_Room"), set the "has" bool to true
        // If no neighboring room is detected, set the "is" bool to true




        // if it does not have a neighbor room in that direction, set that directions "is(direction)" bool to true
        // otherwise, set that directions "is(direction)" bool to false
        // if it does have a neighbor room in that direction, set that directions "has(direction)" bool to true
        // otherwise, set that directions "has(direction)" bool to false


        // if the room has a "is(direction)" bool set to true, set the wall in that direction to active
        // mark it as important
        // if the room has a "has(direction)" bool set to true, mark that direction wall as disposable
        // and add it to a disposable list


        roomFloor.layer = LayerMask.NameToLayer("PG_Room");
        roomBounds.gameObject.layer = LayerMask.NameToLayer("PG_Room");
    }

    //method that can activate or deactive the walls that can be called by outside scripts
    public void SetWallActive(Vector3 position, bool active, bool important = false, bool disposable = false)
    {
        if (wallsToLocation.ContainsKey(position))
        {
            wallsToLocation[position].SetActive(active);
            if (important || disposable)
            {
                wallsToLocation[position].GetOrAdd<BoxCollider>();
            }
        }
    }

    //method that can be called by outside scripts to get the position of the walls
    public Vector3 GetWallPosition(Vector3 position)
    {
        if (wallsToLocation.ContainsKey(position))
        {
            return wallsToLocation[position].transform.position;
        }
        return Vector3.zero;
    }

    //method that can be called by outside scripts to get the wall object
    public GameObject GetWall(Vector3 position)
    {
        if (wallsToLocation.ContainsKey(position))
        {
            return wallsToLocation[position];
        }
        return null;
    }
    public void DestroyWall(Vector3 position, bool checkInactive = false, bool checkDisposable = false)
    {
        if (wallsToLocation.ContainsKey(position))
        {
            GameObject wall = wallsToLocation[position];
            if ((checkInactive && !wall.activeSelf) || (checkDisposable && wall.GetComponent<BoxCollider>() != null))
            {
                Object.Destroy(wall);
            }
        }
    }
    public void DestroyAllWalls(bool checkInactive = false, bool checkDisposable = false)
    {
        foreach (KeyValuePair<Vector3, GameObject> wall in wallsToLocation)
        {
            DestroyWall(wall.Key, checkInactive, checkDisposable);
        }
    }

    public void DetectNeighborRooms()
    {
        RaycastHit hit;
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        float[] distances = { roomBounds.size.z, roomBounds.size.z, roomBounds.size.x, roomBounds.size.x };

        isNorth = DetectRoomInDirection(center, directions[0], distances[0]);
        isSouth = DetectRoomInDirection(center, directions[1], distances[1]);
        isEast = DetectRoomInDirection(center, directions[2], distances[2]);
        isWest = DetectRoomInDirection(center, directions[3], distances[3]);

        hasNorth = !isNorth;
        hasSouth = !isSouth;
        hasEast = !isEast;
        hasWest = !isWest;
    }

    private bool DetectRoomInDirection(Vector3 origin, Vector3 direction, float distance)
    {
        return !Physics.Raycast(origin, direction, distance);
    }
}
