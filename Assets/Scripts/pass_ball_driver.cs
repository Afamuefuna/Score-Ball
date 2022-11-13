using UnityEngine;
using PathgeneratorNS;

public class pass_ball_driver : MonoBehaviour

{
    private float rnd_color;


    void Awake()

    {
        transform.GetComponent<TrailRenderer>().material.SetColor("_TintColor", Color.white);
        Destroy(transform.gameObject, 2f);
    }

    void FixedUpdate()

    {
        if (PathGenerator.alter_addpath.Bounce_bool)
            transform.Translate(-transform.forward * 3f);
        else
            transform.Translate(-transform.forward *
                                PathGenerator.alter_addpath.Speed_line); //Speed_line: how fast should air line moves
    }
}