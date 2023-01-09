using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    public Transform leftHumurus;
    public Transform leftRadius;
    public Transform leftMadus;
    public Transform rightHumurus;
    public Transform rightRadius;
    public Transform rightMadus;
    public float _speed = 1f;

    public Transform root;
    public Transform tail;
    public Vector3 temp = new Vector3(180,180,0);
    public Vector3 temp2 = new Vector3(90,90,0);
    public Rigidbody _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_rigidBody.velocity.magnitude < _speed){
            float value = Input.GetAxis("Vertical");
            if(value !=0){
            rightHumurus.rotation = Quaternion.LookRotation(temp, temp);
            leftHumurus.rotation = Quaternion.LookRotation(temp, temp);

           }

        }
        rightHumurus.rotation = Quaternion.LookRotation(-temp2,-temp2);

    }
  
}
