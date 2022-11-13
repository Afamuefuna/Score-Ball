using UnityEngine;

public class ShootBall : MonoBehaviour, PooledObject

{
    public void OnObjectSpwan()

    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(0.5f, 1f), ForceMode.Impulse);
    }
}