using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform target;
    public float smooth;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() // Late update always comes last
    {
        if (transform.position != target.position){
            //Vector3.lerp gets the distance between the camera and the target and moves a percentage of the distance each frame
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x , minPos.x , maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y , minPos.y , maxPos.y);

            transform.position = Vector3.Lerp(transform.position , targetPosition , smooth);


        }
    }
}
