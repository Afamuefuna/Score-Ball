using UnityEngine;
using PathgeneratorNS;

public class ragbi_rotate : MonoBehaviour

{
    private int interval = 500;


    void Update()

    {
        if (Menu_Ui.menu_ui_alter.StartgameBool)
            transform.Rotate(transform.forward * PathGenerator.alter_addpath.ShiftSpeed * 1.5f);


        if (Time.frameCount % interval == 0)

        {
            transform.parent.rotation = Quaternion.identity;
            transform.rotation = Quaternion.identity;
        }
    }
}