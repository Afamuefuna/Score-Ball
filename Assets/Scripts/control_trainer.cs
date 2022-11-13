using System.Collections;
using UnityEngine;

public class control_trainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("bestrec") >= 5)
        {
            Menu_Ui.menu_ui_alter.tap_hand_tutorial.GetComponent<Animator>().enabled = false;
            Menu_Ui.menu_ui_alter.tap_hand_tutorial.SetActive(false);
        }
        else
        {
            StartCoroutine(HandStop());
        }
    }

    IEnumerator HandStop()
    {
        yield return new WaitForSeconds(3.5f);
        Menu_Ui.menu_ui_alter.tap_hand_tutorial.GetComponent<Animator>().enabled = false;
        Menu_Ui.menu_ui_alter.tap_hand_tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}