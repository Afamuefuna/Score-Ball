using PathgeneratorNS;
using UnityEngine;

public class background_settings : MonoBehaviour

{
    void Start()

    {
        transform.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.93f, 0.94f, 0.95f));
    }

    void Update()
    {
        //if (GameObject.Find("restart_Game").GetComponent<CanvasGroup>().interactable)

        if (PathGenerator.alter_addpath.LevelFinished)
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color(0.93f, 0.94f, 0.95f),
                new Color(0.4f, 0.4f, 0.4f), Mathf.PingPong(Time.time, 8f));
    }
}