using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scoreball : MonoBehaviour
{
    // Use this for initialization

    private Transform body, head;

    public float offset;

    List<GameObject> Bodies = new List<GameObject>();

    public float speed, Timer, misdis;

    private Vector3 firstPos, firstVelocity;

    public GameObject prefab_ball;

    private int cnt;

    private bool on_it;


    void CreateBall()
    {
        GameObject newball = Instantiate(prefab_ball, Bodies.ElementAt(Bodies.Count - 1).transform.localPosition,
            Quaternion.identity);
        newball.layer = 13;
        newball.GetComponent<Collider>().isTrigger = false;
        newball.GetComponent<Rigidbody>().isKinematic = false;

        Bodies.Add(newball);
    }

    private void FixedUpdate()

    {
//		Bodies.ElementAt(0).transform.Translate(-transform.right * 0.06f);
//		
//			for (int i = 1; i < Bodies.Count; i++)
//			
//			{
//				head = Bodies.ElementAt(i - 1).transform;
//				body = Bodies.ElementAt(i).transform;
//
//				offset = Vector3.Distance(body.position , head.position);
//
//				var newpos = head.position;
//
//				newpos.y = Bodies.ElementAt(i - 1).transform.position.y;
//                				
//				Timer = Time.deltaTime * offset / misdis * speed;
//
//				if (Timer > 0.5f)
//				{
//					Timer = 0.5f;
//				}
//				
//			if (offset >= misdis)
//				
//			{
//				body.position = Vector3.Lerp(body.position, newpos , Timer);
//				body.rotation = Quaternion.Lerp(body.rotation, head.rotation , Timer);
//			}
//
//			
//			}

        ///	this.GetComponent<Rigidbody>().AddForce(pos* speed,ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)

    {
//		if (other.gameObject.CompareTag("tail"))
//		{
//			Destroy(other.gameObject);
//			CreateBall();
//		}
    }
}