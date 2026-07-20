using UnityEngine;
using System.Collections;

public class PistonController : MonoBehaviour
{
    [SerializeField] Transform movablePart;
    [SerializeField] private float travelDist=2.5f;
    [SerializeField] private float waitDown;
    [SerializeField] private float waitUp;
    [SerializeField] private float downSpeed;
    [SerializeField] private float upSpeed;
    void Awake()
    {
        
    }
    void Start()
    {
        StartCoroutine(PistonLoop());
    }
    void Update()
    {
        
    }
    IEnumerator PistonLoop()
    {
        while (true)
        {
            //move down
            yield return MoveTo(-travelDist,downSpeed);
            yield return new WaitForSeconds(waitDown);

            //move up 
            yield return MoveTo(0,upSpeed);
            yield return new WaitForSeconds(waitUp);
        }
    }
    IEnumerator MoveTo(float finalY,float speed)
    {
        while (movablePart.localPosition.y != finalY)
        {
            movablePart.localPosition=new Vector3(movablePart.localPosition.x,Mathf.MoveTowards(movablePart.localPosition.y,finalY,speed*Time.deltaTime),movablePart.localPosition.z);
            yield return null;
        }
    }
}
