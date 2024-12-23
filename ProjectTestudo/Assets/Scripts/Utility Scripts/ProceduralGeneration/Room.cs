using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public BoxCollider roomBounds;
    public Vector3 center;
    public Wall northWall = new Wall();
    public Wall southWall = new Wall();
    public Wall eastWall = new Wall();
    public Wall westWall = new Wall();

    //public Wall northWall, southWall, eastWall, westWall;

    public GameObject northEast, southEast, southWest, northWest;
    public GameObject roomFloor;

    public List<Wall> walls = new List<Wall>();
    public Dictionary<Vector3, Wall> wallsToLocation = new Dictionary<Vector3, Wall>();

    public Transform Top_Middle, Bottom_Middle, Left_Middle, Right_Middle;

    /// <summary>
    ///                                     All Room variables are initialized here,
    ///                                 ***THEY ARE ALSO RELATIVE TO THE FLOOR OBJECT ***     
    ///                                     Floor should have an opposite side for cieling
    /// </summary>
    /// <param name="position"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="length"></param>
    /// <param name="roomFloorPrefab"></param>
    public Room(Vector3 position, int width, int height, int length, GameObject roomFloorPrefab)
    {

        if (roomFloorPrefab == null)
        {
            Debug.LogError("Room floor prefab is null. Cannot create room.");
            return;
        }

        GameObject roomFloor = Object.Instantiate(roomFloorPrefab, position, Quaternion.identity);
        roomBounds = roomFloor.GetOrAdd<BoxCollider>();
        roomBounds.size = new Vector3(width, height, length);
        roomFloor.ScaleNonStaticChildrenWithMesh(new Vector3(width, height, length));
        center = new Vector3(roomBounds.bounds.center.x, roomBounds.bounds.center.y, roomBounds.bounds.center.z);

        Top_Middle = roomFloor.FindChildByName("Top_Middle").GetOrAdd<Transform>();
        Bottom_Middle = roomFloor.FindChildByName("Bottom_Middle").GetOrAdd<Transform>();
        Left_Middle = roomFloor.FindChildByName("Left_Middle").GetOrAdd<Transform>();
        Right_Middle = roomFloor.FindChildByName("Right_Middle").GetOrAdd<Transform>();

        Top_Middle.position = roomBounds.bounds.center + new Vector3(0, 0, roomBounds.size.z / 2);
        Bottom_Middle.position = roomBounds.bounds.center - new Vector3(0, 0, roomBounds.size.z / 2);
        Left_Middle.position = roomBounds.bounds.center - new Vector3(roomBounds.size.x / 2, 0, 0);
        Right_Middle.position = roomBounds.bounds.center + new Vector3(roomBounds.size.x / 2, 0, 0);

        // get all the positions of the children that have the name "PG_Wall"
        List<GameObject> objects = roomFloor.transform.GetAllChildren();

        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] != null)
            {

                switch (objects[i].name)
                {
                    // wall objects to control which is active and which is not
                    case "PG_Wall_North":
                        northWall.myWall = objects[i];
                        northWall.myPosition = Top_Middle.position;
                        walls.Add(northWall);
                        wallsToLocation.Add(northWall.myTransform.position, northWall);
                        break;
                    case "PG_Wall_South":
                        southWall.myWall = objects[i];
                        southWall.myTransform.position = Bottom_Middle.position;
                        walls.Add(southWall);
                        wallsToLocation.Add(southWall.myTransform.position, southWall);
                        break;
                    case "PG_Wall_East":
                        eastWall.myWall = objects[i];
                        eastWall.myTransform.position = Right_Middle.position;
                        walls.Add(eastWall);
                        wallsToLocation.Add(eastWall.myTransform.position, eastWall);
                        break;
                    case "PG_Wall_West":
                        westWall.myWall = objects[i];
                        westWall.myTransform.position = Left_Middle.position;
                        walls.Add(westWall);
                        wallsToLocation.Add(westWall.myTransform.position, westWall);
                        break;

                    //corners for future reference
                    case "Top_RightCorner":
                        northEast = objects[i];
                        northEast.transform.position = Top_Middle.position + Right_Middle.position;
                        break;
                    case "Bottom_RightCorner":
                        southEast = objects[i];
                        southEast.transform.position = Bottom_Middle.position + Right_Middle.position;
                        break;
                    case "Bottom_LeftCorner":
                        southWest = objects[i];
                        southWest.transform.position = Bottom_Middle.position + Left_Middle.position;
                        break;
                    case "Top_LeftCorner":
                        northWest = objects[i];
                        northWest.transform.position = Top_Middle.position + Left_Middle.position;
                        break;


                    // floor object to control the position of the floor
                    case "PG_Floor":
                        roomFloor = objects[i];
                        roomFloor.transform.position = roomFloor.transform.position;
                        break;

                    default:
                        break;
                }

            }
        }


        roomFloor.layer = LayerMask.NameToLayer("PG_Room");
        roomBounds.gameObject.layer = LayerMask.NameToLayer("PG_Room");
    }
}
