using System.Linq;
using PathMakerDll;
using UnityEngine;
using PathgeneratorNS;

public class Player : MonoBehaviour

{
    public GameObject BallPlayer;

    public bool AllowToRoll, Camfix;
    public float TranslateSpeed, Shift;

    public int MoveBallLeftRight;

    private Vector3 _offsetCam;

    public static Player Player_alter;


    [Range(0, 30f)] public float camera_Up_look;

    [Range(0, 10f)] public float camera_behind_ball_z;

    public float right_amount = 0.24f;
    public float left_amount = -0.24f;


    public Animator Plr_ball_child_anim, Plr_ball_child_anim_1;
    public Rigidbody ball_palyer_rig;
    public SphereCollider ball_player_coll;

    public droid DroidComponent;

    public space_body_rotate SpaceshipComponent;

    public Camera MCamera;

    public Player PlayerComponent;

    //camera moshkel dare.

    void Start()

    {
        Invoke("ballpos", 0.5f);

        Camfix = true;

        ball_palyer_rig = BallPlayer.GetComponent<Rigidbody>();
        ball_player_coll = BallPlayer.GetComponent<SphereCollider>();


        MCamera = Camera.main;
    }

    void Awake()
    {
        Player_alter = this;

        PlayerComponent = GetComponent<Player>();
    }


    private void ballpos()

    {
        //sets the camera in right place
        _offsetCam =
            new Vector3(BallPlayer.transform.position.x, camera_Up_look,
                Camera.main.transform.position.z + camera_behind_ball_z) - BallPlayer.transform.position;
    }

    private void Update()


    {
#if UNITY_EDITOR // http://wiki.unity3d.com/index.php/OnTouch >> alternative.
        if (Menu_Ui.menu_ui_alter.StartgameBool && Input.GetMouseButtonDown(0)) // drives the ball by click

        {
            AllowToRoll = true;

            MoveBallLeftRight++;

            if (MoveBallLeftRight > 2)

            {
                MoveBallLeftRight = 1;
            }
        }

#endif

#if UNITY_ANDROID
		if (Menu_Ui.menu_ui_alter.StartgameBool && Input.touches.Any(x=>x.phase == TouchPhase.Began))
		{
	
		
			AllowToRoll = true;
			
			MoveBallLeftRight++;

			if (MoveBallLeftRight > 2)

			{
				MoveBallLeftRight = 1;
				
			}
			

		
		}

#endif

#if UNITY_IPHONE
		if (Menu_Ui.menu_ui_alter.StartgameBool && Input.touches.Any(x=>x.phase == TouchPhase.Began))
		{
	
			AllowToRoll = true;
			
			
			MoveBallLeftRight++;

			if (MoveBallLeftRight > 2)
				MoveBallLeftRight = 1;
			
		}

#endif

        if (AllowToRoll)

        {
            Shift = PathGenerator.alter_addpath.ShiftSpeed * Time.deltaTime;

            var indx = PlayerPrefs.GetInt("ch_indx");

            if (indx == 1)
            {
                right_amount = 0.25f;
                left_amount = -0.25f;
            }

            if (indx == 3)
            {
                right_amount = 0.26f;
                left_amount = -0.26f;
            }

            if (indx == 8)
            {
                right_amount = 0.26f;
                left_amount = -0.26f;
            }


            if (MoveBallLeftRight == 1 && BallPlayer.transform.position.x < right_amount)

            {
                BallPlayer.transform.Translate(transform.right * TranslateSpeed * Time.deltaTime);


                switch (indx)

                {
                    case 2:
                        Plr_ball_child_anim.Play("droid_left");
                        break;

                    case 13:
                        Plr_ball_child_anim.Play("ufo_right");
                        break;

                    case 14:
                        Plr_ball_child_anim.Play("P_left");
                        break;
                }
            }


            if (MoveBallLeftRight == 2 && BallPlayer.transform.position.x > left_amount)

            {
                BallPlayer.transform.Translate(-transform.right * TranslateSpeed * Time.deltaTime);


                switch (indx)

                {
                    case 2:
                        Plr_ball_child_anim.Play("droid_right");
                        break;

                    case 13:
                        Plr_ball_child_anim.Play("ufo_left");
                        break;

                    case 14:
                        Plr_ball_child_anim.Play("P_right");
                        break;
                }
            }

            IPath_collector_trasnlate();
        }
    }


    public void IPath_collector_trasnlate()

    {
        for (int i = 0; i < pathmaker.pathmaker_alter._path.Count; i++) // translate whole of the objects in the scene

            pathmaker.pathmaker_alter._path.ElementAt(i).transform
                .Translate(-pathmaker.pathmaker_alter._path.ElementAt(i).transform.forward * Shift);
    }

    private void LateUpdate() // camera will chase the ball in right and left direction

    {
        if (!Camfix)
            MCamera.transform.position = Vector3.Lerp(MCamera.transform.position,
                BallPlayer.transform.position + _offsetCam, Time.deltaTime * TranslateSpeed);
    }
}