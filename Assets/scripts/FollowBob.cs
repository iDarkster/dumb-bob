using UnityEngine;

public class FollowBob : MonoBehaviour
{
    [SerializeField] GameObject Bob;
    [SerializeField] float MinX = -1000;
    [SerializeField] float MaxX = 1000;

    void Start()
    {
        
    }
    void Update()
    {
        Vector3 BobPos = Bob.transform.position;
        float CamX = BobPos.x;
        float CamY = BobPos.y;
        CamX=Mathf.Clamp(CamX,MinX,MaxX); //will figure out the limits later
        float CamZ = transform.position.z;

        transform.position = new Vector3(CamX,CamY,CamZ);

    }
}
