using UnityEngine;


public class Magnet : MonoBehaviour

{
    public float distance;

    public LayerMask layerint;


    void Update()
    {
        ExplosionDamage(transform.position, distance, layerint);
    }

    void ExplosionDamage(Vector3 center, float radius, LayerMask layerint)

    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, layerint);

        int i = 0;

        while (i < hitColliders.Length)

        {
            hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, transform.position,
                Time.deltaTime * 5f);

            i++;
        }
    }
}