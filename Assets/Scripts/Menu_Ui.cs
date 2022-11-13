using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PathgeneratorNS;
using PathMakerDll;


public class Menu_Ui : MonoBehaviour

{
    public GameObject Taptoplay, Music, Sound, Vibration, internal_score, suprise;

    public Sprite Music_on, Music_off, Sound_on, Sound_off, Vibartion_on, Vibration_off;

    public int snd, msc, vib, firstPlay;

    public bool StartgameBool;


    private bool move_cam;

    public GameObject[] Charactors = new GameObject[14];

    private int chk1, chk2, chk3, chk4, chk5;

    public static Menu_Ui menu_ui_alter;

    public GameObject player_ball;


    private RectTransform progress_rect_t;


    private int star_comment;

    public GameObject tap_hand_tutorial;

    public int options_open = 0;


    private void Start()

    {
//		PlayerPrefs.SetInt("cur_lvl_txt",75);
//		PlayerPrefs.SetInt("nxt_lvl_txt",76);
//	    PlayerPrefs.SetInt("bestrec",4500);
        progress_rect_t = GameObject.Find("progress_anim").GetComponent<RectTransform>();


        if (snd == 1)
        {
            Sound.GetComponent<Image>().sprite = Sound_on;
            GameObject.Find("Gain_catch").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Ball_explotion").GetComponent<AudioSource>().mute = false;

            GameObject.Find("Jump").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Gate").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Lose").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            Sound.GetComponent<Image>().sprite = Sound_off;
            GameObject.Find("Gain_catch").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Ball_explotion").GetComponent<AudioSource>().mute = true;

            GameObject.Find("Jump").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Gate").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Lose").GetComponent<AudioSource>().mute = true;
        }

        if (msc == 1)
        {
            Music.GetComponent<Image>().sprite = Music_on;
            GameObject.Find("Music").GetComponent<AudioSource>().mute = false;
        }
        else
        {
            Music.GetComponent<Image>().sprite = Music_off;
            GameObject.Find("Music").GetComponent<AudioSource>().mute = true;
        }
    }


    private void Awake()

    {
        menu_ui_alter = this;


        StartgameBool = false;

        firstPlay = PlayerPrefs.GetInt("frsply");

        if (PlayerPrefs.GetInt("bestrec") == 0) //locks all the balls 

        {
            PlayerPrefs.SetInt("chk1", 0);
            PlayerPrefs.SetInt("chk2", 0);
            PlayerPrefs.SetInt("chk3", 0);
            PlayerPrefs.SetInt("chk4", 0);
            PlayerPrefs.SetInt("chk5", 0);
            PlayerPrefs.SetInt("chk6", 0);
            PlayerPrefs.SetInt("chk7", 0);
            PlayerPrefs.SetInt("chk8", 0);
            PlayerPrefs.SetInt("chk9", 0);
            PlayerPrefs.SetInt("chk10", 0);
            PlayerPrefs.SetInt("chk11", 0);
            PlayerPrefs.SetInt("chk12", 0);
            PlayerPrefs.SetInt("chk13", 0);
            PlayerPrefs.SetInt("chk14", 0);
            PlayerPrefs.SetInt("chk15", 0);
        }

        if (firstPlay == 1)

        {
            snd = PlayerPrefs.GetInt("snd");
            msc = PlayerPrefs.GetInt("msc");
            vib = PlayerPrefs.GetInt("vib");
        }

        else

        {
            snd = msc = vib = 1;

            PlayerPrefs.SetInt("snd", snd);
            PlayerPrefs.SetInt("msc", msc);
            PlayerPrefs.SetInt("vib", vib);
        }


#if UNITY_IPHONE
		if (SystemInfo.graphicsMemorySize < 1024)
		{
			
		
	        QualitySettings.SetQualityLevel(1, true);
		}
		
		if (SystemInfo.graphicsMemorySize >= 1024)
		{
			QualitySettings.SetQualityLevel(2, true);
			
		}
#endif


#if UNITY_ANDROID
		if (SystemInfo.graphicsMemorySize < 1024)
		{
			QualitySettings.SetQualityLevel(1, true);
			
		}

		if (SystemInfo.graphicsMemorySize >= 1024)
		{
			QualitySettings.SetQualityLevel(2, true);
			
		}


#endif


        StartCoroutine(InstallCharactor()); // checks which ball should be available for selecting 

        if (PlayerPrefs.GetInt("bestrec") < 5)

        {
            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
        }


        if (PlayerPrefs.GetInt("cur_lvl_txt") >= 3)

        {
            if (PlayerPrefs.GetInt("chk1") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))
            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        if (PlayerPrefs.GetInt("cur_lvl_txt") >= 5 && PlayerPrefs.GetInt("cur_lvl_txt") < 15)

        {
            if (PlayerPrefs.GetInt("chk2") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);


                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 15 && PlayerPrefs.GetInt("cur_lvl_txt") < 25)

        {
            if (PlayerPrefs.GetInt("chk3") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);


                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }


        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 25 && PlayerPrefs.GetInt("cur_lvl_txt") < 35)

        {
            if (PlayerPrefs.GetInt("chk4") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 35 && PlayerPrefs.GetInt("cur_lvl_txt") < 45)
        {
            if (PlayerPrefs.GetInt("chk5") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }

            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);


                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 45 && PlayerPrefs.GetInt("cur_lvl_txt") < 55)
        {
            if (PlayerPrefs.GetInt("chk6") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 55 && PlayerPrefs.GetInt("cur_lvl_txt") < 70)
        {
            if (PlayerPrefs.GetInt("chk7") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //	frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 70 && PlayerPrefs.GetInt("cur_lvl_txt") < 90)
        {
            if (PlayerPrefs.GetInt("chk8") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 90 && PlayerPrefs.GetInt("cur_lvl_txt") < 110)
        {
            if (PlayerPrefs.GetInt("chk9") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 110 && PlayerPrefs.GetInt("cur_lvl_txt") < 125)
        {
            if (PlayerPrefs.GetInt("chk10") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Diamond")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_diamond")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 125 && PlayerPrefs.GetInt("cur_lvl_txt") < 150)
        {
            if (PlayerPrefs.GetInt("chk11") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Diamond")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Heart")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_diamond")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ht")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 150 && PlayerPrefs.GetInt("cur_lvl_txt") < 165)
        {
            if (PlayerPrefs.GetInt("chk12") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Diamond")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Heart")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "VLC")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                lock_ico.GetComponent<CanvasGroup>().alpha = 1;

                lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_diamond")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ht")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 165 && PlayerPrefs.GetInt("cur_lvl_txt") < 170)
        {
            if (PlayerPrefs.GetInt("chk13") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Diamond")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Heart")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "VLC")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "UFO")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                if (lock_ico.name == "Lock_VLC")
                    lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_diamond")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ht")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_VLC")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ufo")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }

        else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 170)
        {
            if (PlayerPrefs.GetInt("chk14") == 0)
                suprise.GetComponent<UnityEngine.UI.Image>().enabled = true;

            foreach (var frame_box in GameObject.FindGameObjectsWithTag("frame"))

            {
                //frame_box.GetComponent<CanvasGroup>().interactable = false;
                frame_box.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (frame_box.name == "Blackball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Droid")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Football")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Basketball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Ragbi")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "8ball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Lightwave")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Redlineball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Beeball")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Gem_stone")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }


                if (frame_box.name == "Diamond")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "Heart")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "VLC")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "UFO")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "PlaneToy")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                if (frame_box.name == "back_to_mmenu")
                {
                    frame_box.GetComponent<CanvasGroup>().interactable = true;
                    frame_box.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }
            }


            foreach (var lock_ico in GameObject.FindGameObjectsWithTag("lock"))

            {
                if (lock_ico.name == "Lock_VLC")
                    lock_ico.GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1);

                if (lock_ico.name == "Lock_dd")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_fb")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_basketball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ragbi")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_8ball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_lightwave")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_Redlineball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_beeball")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_sb")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_diamond")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ht")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_VLC")
                    lock_ico.GetComponent<Image>().color = Color.white;

                if (lock_ico.name == "Lock_ufo")
                    lock_ico.GetComponent<Image>().color = Color.white;


                if (lock_ico.name == "Lock_plane")
                    lock_ico.GetComponent<Image>().color = Color.white;
            }
        }
    }


    void LateUpdate()

    {
        if (StartgameBool && PlayerPrefs.GetInt("bestrec") <= 5)

        {
            tap_hand_tutorial.GetComponent<Animator>().Play("hand");
        }


        if (!StartgameBool)

        {
            if (move_cam)

                Camera.main.transform.position =
                    Vector3.Lerp(Camera.main.transform.position,
                        new Vector3(-253f, Camera.main.transform.position.y, Camera.main.transform.position.z),
                        Time.deltaTime * 8f);

            else

                Camera.main.transform.position =
                    Vector3.Lerp(Camera.main.transform.position,
                        new Vector3(0f, Camera.main.transform.position.y, Camera.main.transform.position.z),
                        Time.deltaTime * 8f);
        }
    }


    IEnumerator InstallCharactor()

    {
        yield return new WaitForEndOfFrame();
        var indx = PlayerPrefs.GetInt("ch_indx"); //ch_indx: charactor index.

        switch (indx)

        {
            case 0:

                player_ball.GetComponent<Renderer>().enabled = true;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);


                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_bb")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                break;

            case 1:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chr_fb = Instantiate(Charactors[0], Vector3.zero, Quaternion.identity);

                chr_fb.transform.parent = Player.Player_alter.BallPlayer.transform;
                chr_fb.transform.localPosition = Vector3.zero;
                chr_fb.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_fb")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                break;

            case 2:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chr_dd = Instantiate(Charactors[1], new Vector3(0f, -0.17f, 0.67f), Quaternion.identity);

                chr_dd.transform.parent = Player.Player_alter.BallPlayer.transform;
                chr_dd.transform.localPosition = new Vector3(0f, -0.17f, 0.67f);
                chr_dd.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_dd")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .transform.GetChild(0).GetComponent<Animator>();
                Player.Player_alter.Plr_ball_child_anim_1 = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .transform.GetChild(1).GetComponent<Animator>();

                Player.Player_alter.DroidComponent =
                    Player.Player_alter.BallPlayer.transform.GetChild(0).GetComponent<droid>();

                break;

            case 3:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chr_basketball = Instantiate(Charactors[2], Vector3.zero, Quaternion.identity);

                chr_basketball.transform.parent = Player.Player_alter.BallPlayer.transform;
                chr_basketball.transform.localPosition = Vector3.zero;
                chr_basketball.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_basketball")
                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                break;

            case 4:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chr_Ragbi = Instantiate(Charactors[3], new Vector3(0f, 0.3f, 0f), Quaternion.identity);

                chr_Ragbi.transform.parent = Player.Player_alter.BallPlayer.transform;

                chr_Ragbi.transform.localPosition = new Vector3(0f, 0.1f, 0f);
                chr_Ragbi.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);


                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_ragbi")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .GetComponent<Animator>();

                break;

            case 5:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);


                GameObject eightball = Instantiate(Charactors[4], Vector3.zero, Quaternion.identity);

                eightball.transform.parent = Player.Player_alter.BallPlayer.transform;

                eightball.transform.localPosition = new Vector3(0f, 0f, 0f);
                eightball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_8ball")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                break;

            case 6:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chr_lightwave = Instantiate(Charactors[5], Vector3.zero, Quaternion.identity);

                chr_lightwave.transform.parent = Player.Player_alter.BallPlayer.transform;
                chr_lightwave.transform.localPosition = Vector3.zero;
                chr_lightwave.transform.localScale = Vector3.one;

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_lightwave")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                break;

            case 7:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject ball_white_red = Instantiate(Charactors[6], Vector3.zero, Quaternion.identity);

                ball_white_red.transform.parent = Player.Player_alter.BallPlayer.transform;

                ball_white_red.transform.localPosition = new Vector3(0f, 0.1f, 0f);
                ball_white_red.transform.localScale = new Vector3(65f, 65f, 65f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_Redlineball")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                break;

            case 8:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject ball_bee = Instantiate(Charactors[7], Vector3.zero, Quaternion.identity);

                ball_bee.transform.parent = Player.Player_alter.BallPlayer.transform;

                ball_bee.transform.localPosition = new Vector3(0f, 0.1f, 0f);
                ball_bee.transform.localScale = new Vector3(65f, 65f, 65f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_beeball")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim =
                    Player.Player_alter.BallPlayer.transform.GetChild(0).GetComponent<Animator>();


                break;

            case 9:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chk_sp = Instantiate(Charactors[8], Vector3.zero, Quaternion.identity);

                chk_sp.transform.parent = Player.Player_alter.BallPlayer.transform;

                chk_sp.transform.localPosition = new Vector3(0f, 0f, 0f);
                chk_sp.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_sb")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                break;

            case 10:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject diamond = Instantiate(Charactors[9], Vector3.zero, Quaternion.Euler(-0f, 0f, 180f));

                diamond.transform.parent = Player.Player_alter.BallPlayer.transform;

                diamond.transform.localPosition = new Vector3(0f, 0.2f, 0f);
                diamond.transform.localScale = new Vector3(100, 100f, 100f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_diamond")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                break;

            case 11:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject chk_heart = Instantiate(Charactors[10], Vector3.zero, Quaternion.Euler(-90f, 0f, 0f));

                chk_heart.transform.parent = Player.Player_alter.BallPlayer.transform;

                chk_heart.transform.localPosition = new Vector3(0f, 0.2f, 0f);
                chk_heart.transform.localScale = new Vector3(1, 1f, 1f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_ht")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .GetComponent<Animator>();

                break;

            case 12:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);

                GameObject VLC = Instantiate(Charactors[11], Vector3.zero, Quaternion.Euler(-90f, 0f, 0f));

                VLC.transform.parent = Player.Player_alter.BallPlayer.transform;

                VLC.transform.localPosition = new Vector3(0f, 0f, 0f);
                VLC.transform.localScale = new Vector3(120f, 120f, 120f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_VLC")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }


                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .GetComponent<Animator>();

                break;

            case 13:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);


                GameObject chr_ufo = Instantiate(Charactors[12], Vector3.zero, Quaternion.identity);

                chr_ufo.transform.parent = Player.Player_alter.BallPlayer.transform;
                chr_ufo.transform.localPosition = Vector3.zero;
                chr_ufo.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_ufo")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .GetComponent<Animator>();
                Player.Player_alter.SpaceshipComponent = Player.Player_alter.BallPlayer.transform.GetChild(0)
                    .GetComponent<space_body_rotate>();


                break;

            case 14:

                player_ball.GetComponent<Renderer>().enabled = false;

                if (Player.Player_alter.BallPlayer.transform.childCount > 0)
                    Destroy(Player.Player_alter.BallPlayer.transform.GetChild(0).gameObject);


                GameObject Plane = Instantiate(Charactors[13], Vector3.zero, Quaternion.Euler(0f, -90f, 0f));

                Plane.transform.parent = Player.Player_alter.BallPlayer.transform;
                Plane.transform.localPosition = new Vector3(0f, 0.3f, 1.5f);
                Plane.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                foreach (var chk in GameObject.FindGameObjectsWithTag("chk_charactor"))

                {
                    chk.GetComponent<CanvasGroup>().alpha = 0f;
                    chk.GetComponent<CanvasGroup>().interactable = false;
                    chk.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    if (chk.gameObject.name == "chk_plane")

                    {
                        chk.GetComponent<CanvasGroup>().alpha = 1f;
                        chk.GetComponent<CanvasGroup>().interactable = true;
                        chk.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    }
                }

                yield return new WaitForEndOfFrame();
                Player.Player_alter.Plr_ball_child_anim =
                    Player.Player_alter.BallPlayer.transform.GetChild(0).GetComponent<Animator>();

                break;
        }
    }


    public void emojipixels_ws()
    {
        Application.OpenURL("https://www.emojione.com/");
    }

    public void black_ball()

    {
        PlayerPrefs.SetInt("ch_indx", 0);

        StartCoroutine(InstallCharactor());
    }


    public void droid()

    {
        PlayerPrefs.SetInt("ch_indx", 2);

        PlayerPrefs.SetInt("chk1", 1);

        StartCoroutine(InstallCharactor());
    }

    public void football()

    {
        PlayerPrefs.SetInt("ch_indx", 1);
        PlayerPrefs.SetInt("chk2", 1);
        StartCoroutine(InstallCharactor());
    }

    public void basketball()

    {
        PlayerPrefs.SetInt("ch_indx", 3);

        PlayerPrefs.SetInt("chk3", 1);

        StartCoroutine(InstallCharactor());
    }


    public void ragbi()

    {
        PlayerPrefs.SetInt("ch_indx", 4);

        PlayerPrefs.SetInt("chk4", 1);

        StartCoroutine(InstallCharactor());
    }


    public void eight_ball()

    {
        PlayerPrefs.SetInt("ch_indx", 5);

        PlayerPrefs.SetInt("chk5", 1);

        StartCoroutine(InstallCharactor());
    }

    public void Lightwave_ball()

    {
        PlayerPrefs.SetInt("ch_indx", 6);

        PlayerPrefs.SetInt("chk6", 1);

        StartCoroutine(InstallCharactor());
    }


    public void redline_ball()

    {
        PlayerPrefs.SetInt("ch_indx", 7);

        PlayerPrefs.SetInt("chk7", 1);

        StartCoroutine(InstallCharactor());
    }

    public void Bee_ball()

    {
        PlayerPrefs.SetInt("ch_indx", 8);

        PlayerPrefs.SetInt("chk8", 1);

        StartCoroutine(InstallCharactor());
    }

    public void gem_stone()

    {
        PlayerPrefs.SetInt("ch_indx", 9);
        PlayerPrefs.SetInt("chk9", 1);
        StartCoroutine(InstallCharactor());
    }

    public void Diamond()

    {
        PlayerPrefs.SetInt("ch_indx", 10);

        PlayerPrefs.SetInt("chk10", 1);

        StartCoroutine(InstallCharactor());
    }


    public void heart()

    {
        PlayerPrefs.SetInt("ch_indx", 11);
        PlayerPrefs.SetInt("chk11", 1);
        StartCoroutine(InstallCharactor());
    }


    public void VLC()

    {
        PlayerPrefs.SetInt("ch_indx", 12);

        PlayerPrefs.SetInt("chk12", 1);

        StartCoroutine(InstallCharactor());
    }

    public void ufo()

    {
        PlayerPrefs.SetInt("ch_indx", 13);
        PlayerPrefs.SetInt("chk13", 1);
        StartCoroutine(InstallCharactor());
    }

    public void Plane()

    {
        PlayerPrefs.SetInt("ch_indx", 14);

        PlayerPrefs.SetInt("chk14", 1);

        StartCoroutine(InstallCharactor());
    }


    public void options_close_open()

    {
        if (options_open == 0)

        {
            options_open = 1;

            GameObject.Find("Options_btn").GetComponent<Animator>().Play("options_new_anim");
        }

        else

        {
            options_open = 0;

            GameObject.Find("Options_btn").GetComponent<Animator>().Play("options_new_anim_back");
        }
    }


    public void StartGame()

    {
        Destroy(Taptoplay);


        internal_score.GetComponent<Text>().enabled = true;

        StartgameBool = true;

        Player.Player_alter.Camfix = false;

        GameObject.Find("Player").GetComponent<Player>().AllowToRoll = true;


        PathGenerator.alter_addpath.Score_record = 0;

        firstPlay = 1;

        PlayerPrefs.SetInt("frsply", firstPlay);

        GameObject.Find("progress").GetComponent<Animator>().Play("Progress_animation");

        PathGenerator.alter_addpath.AirSpeed.Play();
    }

    public void Progress_anim()

    {
        switch (pathmaker.pathmaker_alter._path.Count)

        {
            case 4:
                progress_rect_t.sizeDelta = new Vector2(progress_rect_t.sizeDelta.x + 11.5f, 100f);

                break;

            case 5:
                progress_rect_t.sizeDelta = new Vector2(progress_rect_t.sizeDelta.x + 9.5f, 100f);

                break;

            case 6:
                progress_rect_t.sizeDelta = new Vector2(progress_rect_t.sizeDelta.x + 8.5f, 100f);

                break;

            case 8:
                progress_rect_t.sizeDelta = new Vector2(progress_rect_t.sizeDelta.x + 6f, 100f);

                break;

            case 10:
                progress_rect_t.sizeDelta = new Vector2(progress_rect_t.sizeDelta.x + 4.5f, 100f);

                break;
        }
    }


    public void Retry()

    {
        if (PathGenerator.alter_addpath.Score_record < PathGenerator.alter_addpath.best_Record)
            PlayerPrefs.SetInt("bestrec", PathGenerator.alter_addpath.best_Record);
        else
            PlayerPrefs.SetInt("bestrec", PathGenerator.alter_addpath.Score_record);


        SceneManager.LoadScene("Game");
    }

    public void Sound_on_off()

    {
        if (snd == 0)

        {
            Sound.GetComponent<UnityEngine.UI.Image>().sprite = Sound_on;

            snd = 1;

            GameObject.Find("Gain_catch").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Ball_explotion").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Jump").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Gate").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Lose").GetComponent<AudioSource>().mute = false;

            PlayerPrefs.SetInt("snd", snd);
        }

        else

        {
            Sound.GetComponent<UnityEngine.UI.Image>().sprite = Sound_off;

            GameObject.Find("Gain_catch").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Ball_explotion").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Jump").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Gate").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Lose").GetComponent<AudioSource>().mute = true;

            snd = 0;

            PlayerPrefs.SetInt("snd", snd);
        }
    }


    public void Music_on_off()

    {
        if (msc == 0)

        {
            Music.GetComponent<UnityEngine.UI.Image>().sprite = Music_on;

            GameObject.Find("Music").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Music").GetComponent<AudioSource>().mute = false;

            msc = 1;

            PlayerPrefs.SetInt("msc", msc);
        }

        else

        {
            Music.GetComponent<UnityEngine.UI.Image>().sprite = Music_off;

            GameObject.Find("Music").GetComponent<AudioSource>().mute = true;
            GameObject.Find("Music").GetComponent<AudioSource>().mute = true;

            msc = 0;

            PlayerPrefs.SetInt("msc", msc);
        }
    }


    public void Select_Charactor()

    {
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().interactable = true;

        if (Taptoplay != null)

        {
            Taptoplay.GetComponent<CanvasGroup>().alpha = 0;
            Taptoplay.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void BackToMMenu()

    {
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("Charactor_panel").GetComponent<CanvasGroup>().interactable = false;

        if (Taptoplay != null)

        {
            Taptoplay.GetComponent<CanvasGroup>().alpha = 1;
            Taptoplay.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    IEnumerator show_charactor_frames(float t)

    {
        yield return new WaitForSeconds(t);

        foreach (var frames in GameObject.FindGameObjectsWithTag("frame"))
        {
            frames.GetComponent<CanvasGroup>().alpha = 1f;
            frames.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void load_game()
    {
        SceneManager.LoadScene("Game");
    }
}