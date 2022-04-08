using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    public Transform leftH;
    public Transform leftR;
    public Transform leftM;
    private Vector3 subtract;
    // Start is called before the first frame update
    void Start()
    {
        subtract = leftH.position + leftR.position;
        leftH.position = leftH.position-subtract; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
