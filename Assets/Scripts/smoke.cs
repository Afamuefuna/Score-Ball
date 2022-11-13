using UnityEngine;
using PathgeneratorNS;

public class smoke : MonoBehaviour

{
    private float rnd_color;
    private Rigidbody transform_rigit;

    void Awake()

    {
        transform_rigit = GetComponent<Rigidbody>();
        Destroy(transform.gameObject, 1f);
    }

    void FixedUpdate()

    {
        if (PathGenerator.alter_addpath.Bounce_bool)
        {
            transform_rigit.AddForce(-transform.forward * Random.Range(5f, 10f), ForceMode.Impulse);
            transform.Translate(-transform.forward * 1f);
        }
    }
}