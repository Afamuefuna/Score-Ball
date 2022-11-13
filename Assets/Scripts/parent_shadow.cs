using System.Collections;
using UnityEngine;

public class parent_shadow : MonoBehaviour
{
    // Use this for initialization
    IEnumerator Start()

    {
        //transform.position = new Vector3(transform.position.x,transform.position.y,-0.08f);

        yield return new WaitForSeconds(0.2f);
        if (transform.parent.transform.localScale.z == 0.05f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.5F;
            transform.GetComponent<Projector>().orthographicSize = 1.091f;
        }
        else if (transform.parent.transform.localScale.z == 0.11f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.25F;
            transform.GetComponent<Projector>().orthographicSize = 2.35f;
        }

        else if (transform.parent.transform.localScale.z == 0.08f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.3F;
            transform.GetComponent<Projector>().orthographicSize = 1.8f;
        }

        else if (transform.parent.transform.localScale.z == 0.04f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.5F;
            transform.GetComponent<Projector>().orthographicSize = 0.86f;
        }

        else if (transform.parent.transform.localScale.z == 0.07f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.3F;
            transform.GetComponent<Projector>().orthographicSize = 1.6f;
        }

        else if (transform.parent.transform.localScale.z == 0.1f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.3F;
            transform.GetComponent<Projector>().orthographicSize = 2.2f;
        }

        else if (transform.parent.transform.localScale.z == 0.12f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.25f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.25F;
            transform.GetComponent<Projector>().orthographicSize = 2.6f;
        }
        else if (transform.parent.transform.localScale.z == 0.06f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.35F;
            transform.GetComponent<Projector>().orthographicSize = 1.33f;
        }
        else if (transform.parent.transform.localScale.z == 0.03f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.7F;
            transform.GetComponent<Projector>().orthographicSize = 0.68f;
        }
        else if (transform.parent.transform.localScale.z == 0.02f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 1F;
            transform.GetComponent<Projector>().orthographicSize = 0.46f;
        }
        else if (transform.parent.transform.localScale.z == 0.09f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.5f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.25F;
            transform.GetComponent<Projector>().orthographicSize = 2f;
        }

        if (transform.parent.transform.localScale.z == 0.13f)
        {
            transform.GetComponent<Projector>().nearClipPlane = 0.1f;
            transform.GetComponent<Projector>().farClipPlane = 0.25f;
            transform.GetComponent<Projector>().fieldOfView = 1f;
            transform.GetComponent<Projector>().aspectRatio = 0.2F;
            transform.GetComponent<Projector>().orthographicSize = 2.9f;
        }
    }
}