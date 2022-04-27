using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class flapping : MonoBehaviour
{
    // phase & freq
    private float phi;
    private float freq;
    // bones
    private GameObject tail;
    private GameObject humL;
    private GameObject humR;
    private GameObject radL;
    private GameObject radR;
    private GameObject madL;
    private GameObject madR;

    // driver curves (in degrees)
    private float g1(float up, float down)
    {
        return (up - down) * (1 + Cos(phi)) / 2 + down;
    }
    private float g2(float up, float down)
    {
        if (phi < PI) return down;
        else return (up - down) * (1 - Cos(2 * phi)) / 2 + down;
    }
    // phase transform
    private float phase_tr(float ratio)
    {
        float a = ratio * 2 * PI;
        float b = (PI - a) / Pow(a * (a - 2 * PI), 2);
        return b * Pow(phi * (phi - 2 * PI), 2) + phi;
    }
    // update joints
    private void updateJoints()
    {
        // Find bones
        tail = GameObject.Find("Tail");
        humL = GameObject.Find("Humerus.L");
        humR = GameObject.Find("Humerus.R");
        radL = GameObject.Find("Radius.L");
        radR = GameObject.Find("Radius.R");
        madL = GameObject.Find("Madius.L");
        madR = GameObject.Find("Madius.R");

        // rotate joints
        // tail.transform.Rotate(g1(), 0f, 0f);
        humL.transform.Rotate(g2(30f, -20f) - 90f, g2(30f, -20f), g1(30f, -20f) - 90f);
        humR.transform.Rotate(g2(30f, -20f) - 90f, g2(30f, -20f), 90f - g1(30f, -20f));
    }

    // Start is called before the first frame update
    private void Start()
    {
        // init phi
        phi = 0f;
        // init freq (debug)
        freq = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {

        // increment phi
        phi = (phi + freq * 2 * PI) % (2 * PI);

        // update joints
        updateJoints();

        // locomotion


    }
}
