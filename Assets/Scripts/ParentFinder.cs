using System.Collections;
using UnityEngine;

public class ParentFinder : MonoBehaviour


{
    private GameObject parent;
    private GameObject des_obj;
    private Quaternion rotation, alter_rotation;

    IEnumerator Start()

    {
        rotation = transform.rotation;

        yield return new WaitForSeconds(1f);

        if (parent == null)
        {
            Destroy(transform.gameObject);
        }

        alter_rotation = transform.rotation;

        if (rotation != alter_rotation) // for prevent of floating in space
            Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.CompareTag("Obstacle"))

        {
            Destroy(transform.gameObject);
        }

        if (other.gameObject.CompareTag("tail"))

        {
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }

        if (other.gameObject.CompareTag("Touch"))

        {
            parent = other.gameObject;
            transform.GetComponent<Renderer>().enabled = true;
            transform.GetComponent<Rigidbody>().useGravity = false;
            Destroy(GetComponent<Rigidbody>());
            transform.GetComponent<Collider>().isTrigger = true;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.08f, transform.position.z);
        }
    }
}