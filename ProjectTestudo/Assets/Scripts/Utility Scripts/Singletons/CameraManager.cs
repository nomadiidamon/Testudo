using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Camera mainCamera;
    public CinemachineBrain brain;

    [Header("Player Camera")]
    public CinemachineVirtualCamera playerCamera;
    public Transform playerTransform;
    public Ray centerRay;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        centerRay = mainCamera.GetCenterRay();

        Debug.DrawRay(centerRay.origin, centerRay.direction, Color.green, 100.0f);
    }
}
