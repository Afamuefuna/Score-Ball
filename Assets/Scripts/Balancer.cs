using UnityEngine;

public class Balancer : MonoBehaviour

{
    private bool _destroyMe;

    public GameObject ParentName;

    private void Awake()

    {
        _destroyMe = true;
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Obstacle") && other.transform.parent.gameObject == ParentName)

        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            _destroyMe = false;
        }

        if (_destroyMe)
            Destroy(transform.gameObject);
    }
}