using System.Collections;
using UnityEngine;

public class space_body_rotate : MonoBehaviour
{
    void Update()

    {
        if (Menu_Ui.menu_ui_alter.StartgameBool)

        {
            transform.Rotate(Vector3.forward * 5f);

            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetComponent<Renderer>().material.color =
                    Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1f));
        }
    }
}