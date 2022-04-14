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
    public Transform root;
    public Transform tail;
    private Vector3 subtract;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        subtract = leftHumurus.position + leftRadius.position;
        leftHumurus.position = leftHumurus.position-subtract; 
        
        leftHumurus.position = leftHumurus.position + subtract;
    }
}
