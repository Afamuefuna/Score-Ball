using UnityEngine;

public class droid : MonoBehaviour

{
    void Update()

    {
        if (Menu_Ui.menu_ui_alter.StartgameBool)
            transform.GetChild(1).transform.Rotate(transform.right * Player.Player_alter.TranslateSpeed * 5f);
    }
}