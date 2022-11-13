using System.Collections;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using UnityEngine;
using PathgeneratorNS;

public class Plane_rotate : MonoBehaviour

{
    private Animator plane_anim;

    void Awake()

    {
        plane_anim = GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    void Update()

    {
        if (PathGenerator.alter_addpath.Bounce_bool && !PathGenerator.alter_addpath.OpenTGate)

        {
            StartCoroutine(rotate_plane());
            plane_anim.enabled = false;
        }

//		if (PathGenerator.alter_addpath.OpenTGate && Player.Player_alter.MoveBallLeftRight == 0)
//		{
//		
//			plane_anim.Play("360_plane_rotate");
//		}
    }


    IEnumerator rotate_plane()

    {
        if (transform.parent.position.x < 0)

        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, -90f, 0f), Time.deltaTime * 10f);

            yield return new WaitForSeconds(1f);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90f, 0f), Time.deltaTime * 10f);

            yield return new WaitForSeconds(0.5f);
            plane_anim.enabled = true;
        }

        if (transform.parent.position.x > 0)

        {
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(90f, -90f, 0f), Time.deltaTime * 10f);

            yield return new WaitForSeconds(1f);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90f, 0f), Time.deltaTime * 10f);

            yield return new WaitForSeconds(0.5f);
            plane_anim.enabled = true;
        }
    }
}