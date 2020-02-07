using UnityEngine;

public class RotateToCam : MonoBehaviour
{

    public Camera cam;

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(-cam.transform.forward);
    }
}
