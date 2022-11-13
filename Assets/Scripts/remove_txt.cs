using System.Collections;
using UnityEngine;

public class remove_txt : MonoBehaviour

{
    private Renderer transform_rend;

    void Awake()
    {
        transform_rend = GetComponent<Renderer>();
    }

    void Update()

    {
        StartCoroutine(text_anim());
    }

    IEnumerator text_anim()

    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.7f, 1.7f, 1.7f), Time.deltaTime * 5f);
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, transform.position.y + 0.08f, transform.position.z), Time.deltaTime * 2f);


        yield return new WaitForSeconds(0.5f);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 5f);

        yield return new WaitForSeconds(0.5f);
        transform_rend.material.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0.3f, Time.deltaTime * 5f));
        Destroy(transform.gameObject);
    }
}