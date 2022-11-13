using System.Collections;
using System.Linq;
using UnityEngine;
using PathgeneratorNS;


public class Lose_menu_win : MonoBehaviour

{
    //public GameObject Retrybutton;

    private void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.CompareTag("Player"))

        {
            PathGenerator.alter_addpath.Bodies.ElementAt(0).GetComponent<Renderer>().enabled = false;


            FindObjectOfType<Player>().enabled = false;


            if (!PathGenerator.alter_addpath.LevelFinished)

            {
                GameObject.Find("Lose").GetComponent<AudioSource>().Play();

                //PathGenerator.alter_addpath.Retry_menu.GetComponent<Animator>().Play("Retry");

                PathGenerator.alter_addpath.Retry_menu.GetComponent<CanvasGroup>().alpha = 1;
                PathGenerator.alter_addpath.Retry_menu.GetComponent<CanvasGroup>().blocksRaycasts = true;

                PathGenerator.alter_addpath.move_loser_cam = true;

                StartCoroutine(PathGenerator.alter_addpath.dis_player_collider());

                PlayerPrefs.SetInt("cur_rec", PathGenerator.alter_addpath.Score_record);
                PathGenerator.alter_addpath.retry_current_reco_txt.text =
                    PathGenerator.alter_addpath.Score_record.ToString();


                PathGenerator.alter_addpath.retry_best_reco_txt.text = "Total: " + PlayerPrefs.GetInt("bestrec");
            }
        }
    }
}