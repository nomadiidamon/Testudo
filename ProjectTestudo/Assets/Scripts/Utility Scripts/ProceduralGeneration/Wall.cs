using UnityEngine;

public class Wall 
{
	public GameObject myWall;
    public Vector3 myPosition;
    public Transform myTransform;
    public bool isActive = true;
    private string direction = "";

    public Wall() 
    {    
        myWall = null;
        myPosition = Vector3.zero;
        myTransform = null;
    }

    public Wall(Vector3 pos, GameObject obj)
    {
        this.myWall = obj;
        this.myPosition = pos;
        this.direction = obj.name;
        this.myTransform = obj.transform;
    }


    public void SetActive(bool active) { isActive = active; }

    public string GetName() { return direction; }
    public void SetDirection(string direction)
    {
        this.direction = direction;
    }

    public void Deactivate() { isActive = false; }
    public void Activate() { isActive = true; }

    public void DeleteSelf()
    {
        if (myWall != null && !isActive)
        {
            UnityEngine.Object.Destroy(myWall);
        }
    }


    

}
