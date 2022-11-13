using UnityEngine;
using PathgeneratorNS;

public class body_Trash : MonoBehaviour

{
    public GameObject _forevermoveballPrf;


    void Update()

    {
        if (PathGenerator.alter_addpath.Bounce_bool)
            Invoke("path_track", 0.2f);
    }

    void path_track()
    {
        Instantiate(_forevermoveballPrf, transform.position, Quaternion.identity);
        _forevermoveballPrf.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        CancelInvoke();
    }
}