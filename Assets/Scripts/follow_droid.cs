using UnityEngine;

public class follow_droid : MonoBehaviour

{
    void Update()

    {
        transform.Rotate(transform.right * Player.Player_alter.TranslateSpeed * 15f);
    }
}