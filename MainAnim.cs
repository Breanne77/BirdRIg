using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;


public class MainAnim : MonoBehaviour
{
    // phase & freq
    private float phi;
    private float phi_t;
    private float flap_speed;

    // bones
    public Transform root;
    public Transform tail;
    public Transform HumL;
    public Transform HumR;
    public Transform RadL;
    public Transform RadR;
    public Transform MadL;
    public Transform MadR;

    // params
    public float up_ratio;
    public (float up, float down) HumD = (20f, -20f);
    public (float up, float down) HumS = (0f, -20f);
    public (float up, float down) HumT = (0f, -20f);
    public (float up, float down) RadS = (20f, 0f);
    public (float up, float down) RadT = (20f, 0f);
    public (float up, float down) MadS = (20f, 0f);



    // Start is called before the first frame update
    // driver curves (in degrees)
    private float g1((float up, float down) p)
    {
        return (p.up - p.down) * (1 + Cos(phi_t)) / 2 + p.down;
    }
    private float g2((float up, float down) p)
    {
        if (phi_t > PI) return p.down;
        else return (p.up - p.down) * (1 - Cos(2 * phi_t)) / 2 + p.down;
    }
    // phase transform
    private void phase_tr(float ratio)
    {
        float a = ratio * 2 * PI;
        float b = (PI - a) / Pow(a * (a - 2 * PI), 2);
        phi_t = b * Pow(phi * (phi - 2 * PI), 2) + phi;
    }
    // update joints
    private void updateJoints()
    {
        // rotate joints
        tail.rotation = Quaternion.Euler(-90, 0, 0);
        HumL.rotation = Quaternion.Euler(-90, -180, 90);
        HumR.rotation = Quaternion.Euler(270, 0, 90);
        RadL.rotation = Quaternion.Euler(0, 0, -90);
        RadR.rotation = Quaternion.Euler(0, 0, 90);
        MadL.rotation = Quaternion.Euler(0, 0, -90);
        MadR.rotation = Quaternion.Euler(0, 0, 90);

        tail.Rotate(g1((5f, -5f)), 0f, 0f);
        HumL.Rotate(g1(HumS), -g2(HumD), -g2(HumT));
        HumR.Rotate(g1(HumS), g2(HumD), g2(HumT));
        RadL.Rotate(g2(RadS), -g2(RadT), 0);
        RadR.Rotate(g2(RadS), g2(RadT), 0);
        MadL.Rotate(g2(MadS), 0, 0);
        MadR.Rotate(g2(MadS), 0, 0);
    }

    // Start is called before the first frame update
    private void Start()
    {
        // init phi & freq
        phi = 0f;
        flap_speed = 0.005f;
        up_ratio = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        // process input
        flap_speed = 0.01f + 0.005f * Input.GetAxis("Vertical");


        // increment phi
        phi += flap_speed;
        if (phi > 2 * PI) Debug.Log($"flap");

        phi = phi % (2 * PI);

        // phase transform
        phase_tr(up_ratio);

        // update joints
        updateJoints();

        // locomotion


    }





}
