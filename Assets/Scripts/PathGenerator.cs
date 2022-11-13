using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PathMakerDll;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace PathgeneratorNS

{
    public class PathGenerator : MonoBehaviour

    {
        public bool Bounce_bool, OpenTGate, LevelFinished;

        private GameObject PathName1, PathName2;

        public List<GameObject> Bodies = new List<GameObject>();


        public float Distance, ShiftSpeed, savedSpeed;

        public int bounceMode;


        public Vector3 DestroyBallPos;

        private bool red_head;
        private int time_colde;

        RaycastHit hit;

        public int emojichanceps, CurrentLevelNo, NextLevelNo;

        private GameObject cut_obstacle;


        public int Score_record, best_Record;


        public Color32 LerpedColor_pth_cltr = Color.white;
        public Color32 LerpedColor_pth_cltr1 = Color.white;

        public Color32 LerpedColor_obst_mat1 = Color.white;
        public Color32 LerpedColor_obst_mat2 = Color.white;


        public GameObject Score_anim;


        public GameObject Retry_menu, CompeleteLevel;

        public Camera Main_camera_to_right;

        public bool move_loser_cam;

        public GameObject floting_Score_txt,
            Retry_best_Score_txt,
            Retry_current_Score_txt,
            Tap_TP_currnet_Score,
            Tap_TP_best_Score;

        public int amount_ball_recive;

        public AudioSource Ball_gain;

        public GameObject emoji;


        public Sprite[] emojies = new Sprite[4];

        public float Speed_line, airSpeed_simulationspeed;


        public ParticleSystem CollisionEffect, AirSpeed;
        public ParticleSystem destroyballeffect;

        private bool deactive_raycast;

        public static PathGenerator alter_addpath;


        public Animator emoji_animator, score_anim_comp;

        private RectTransform emoji_rect;


        public TextMesh plus_score_txtmesh;

        public Image emoji_img;

        public Text emoji_txt,
            retry_best_reco_txt,
            retry_current_reco_txt,
            score_anim_txt,
            cur_lvl_txt_obj,
            nxt_lvl_txt_obj,
            Compelet_best_rec;

        public AudioSource jump_audio;
        public CanvasGroup emoji_canvas;

        private Renderer collector_rend, colletctor_rend1;

        public Color32[] PathColor;
        public Color32[] obstacleColor;

        void Awake()


        {
            //PlayerPrefs.SetInt("cur_lvl_txt",180);

            deactive_raycast = false;
            alter_addpath = this;

            bounceMode = 0;

            Bodies.Add(transform.gameObject);

            Distance = 1f;

            ColorOfPathObstacke();

            var main = AirSpeed.main;

            if (PlayerPrefs.GetInt("cur_lvl_txt") == 0)

            {
                ShiftSpeed = 5f; //speed of game

                main.simulationSpeed = 3f; // speed of air effect
                airSpeed_simulationspeed = main.simulationSpeed;
            }

            else

            {
                if (PlayerPrefs.GetInt("cur_lvl_txt") <= 3)
                {
                    ShiftSpeed = 7f;

                    main.simulationSpeed = 4f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 3 && PlayerPrefs.GetInt("cur_lvl_txt") <= 10)
                {
                    ShiftSpeed = 8f;

                    main.simulationSpeed = 4f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 10 && PlayerPrefs.GetInt("cur_lvl_txt") <= 15)
                {
                    ShiftSpeed = 9f;

                    main.simulationSpeed = 4f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 15 && PlayerPrefs.GetInt("cur_lvl_txt") <= 20)
                {
                    ShiftSpeed = 10f;

                    main.simulationSpeed = 4.5f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 20 && PlayerPrefs.GetInt("cur_lvl_txt") <= 25)
                {
                    ShiftSpeed = 11f;

                    main.simulationSpeed = 5f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 25 && PlayerPrefs.GetInt("cur_lvl_txt") <= 35)
                {
                    ShiftSpeed = 12f;

                    main.simulationSpeed = 5.5f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 35 && PlayerPrefs.GetInt("cur_lvl_txt") <= 45)
                {
                    ShiftSpeed = 12.5f;

                    main.simulationSpeed = 5f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 45 && PlayerPrefs.GetInt("cur_lvl_txt") <= 55)
                {
                    ShiftSpeed = 13f;

                    main.simulationSpeed = 6f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 55 && PlayerPrefs.GetInt("cur_lvl_txt") <= 100)
                {
                    ShiftSpeed = 15f;

                    main.simulationSpeed = 7f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 100 && PlayerPrefs.GetInt("cur_lvl_txt") <= 145)
                {
                    ShiftSpeed = 16f;

                    main.simulationSpeed = 8f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 145 && PlayerPrefs.GetInt("cur_lvl_txt") <= 200)
                {
                    ShiftSpeed = 17f;

                    main.simulationSpeed = 9f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 200 && PlayerPrefs.GetInt("cur_lvl_txt") <= 250)
                {
                    ShiftSpeed = 18f;

                    main.simulationSpeed = 10f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 250 && PlayerPrefs.GetInt("cur_lvl_txt") <= 375)
                {
                    ShiftSpeed = 18.5f;

                    main.simulationSpeed = 11f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
                else
                {
                    ShiftSpeed = 19f;

                    main.simulationSpeed = 12f;
                    airSpeed_simulationspeed = main.simulationSpeed;
                }
            }


            var rnd_color_path = Random.Range(0, 4);
            var rnd_color_obstacle = Random.Range(0, 4);

            while (rnd_color_path == rnd_color_obstacle)

            {
                rnd_color_path = Random.Range(0, 5);
                rnd_color_obstacle = Random.Range(0, 5);
            }

            var rnd_color_path_1 = Random.Range(0, 5);
            var rnd_color_obstacle_1 = Random.Range(0, 5);

            while (rnd_color_path_1 == rnd_color_obstacle_1)
            {
                rnd_color_path_1 = Random.Range(0, 5);
                rnd_color_obstacle_1 = Random.Range(0, 5);
            }

            // color of path / obstacle
            LerpedColor_pth_cltr = PathColor[rnd_color_path_1];
            LerpedColor_obst_mat1 = obstacleColor[rnd_color_obstacle_1];

            LerpedColor_pth_cltr1 = PathColor[rnd_color_path_1];
            LerpedColor_obst_mat2 = obstacleColor[rnd_color_obstacle_1];


            emojichanceps = 1;

            best_Record = PlayerPrefs.GetInt("bestrec");
            Score_record = PlayerPrefs.GetInt("cur_rec");


            if (Score_record > 0 | best_Record > 0)

            {
                Tap_TP_best_Score.GetComponent<Text>().text = "Total: " + best_Record.ToString();
                Tap_TP_currnet_Score.GetComponent<Text>().text = Score_record.ToString();
            }

            floting_Score_txt.GetComponent<TextMesh>().color = Color.white;
            floting_Score_txt.GetComponent<TextMesh>().text = "+1";

            amount_ball_recive = 15;


            retry_best_reco_txt = Retry_best_Score_txt.GetComponent<Text>();
            retry_current_reco_txt = Retry_current_Score_txt.GetComponent<Text>();


            plus_score_txtmesh = floting_Score_txt.GetComponent<TextMesh>();

            emoji_animator = emoji.GetComponent<Animator>();
            emoji_img = emoji.GetComponent<Image>();
            emoji_rect = emoji.GetComponent<RectTransform>();
            emoji_txt = emoji.transform.GetChild(0).GetComponent<Text>();

            emoji_canvas = emoji.GetComponent<CanvasGroup>();

            jump_audio = GameObject.Find("Jump").GetComponent<AudioSource>();


            score_anim_comp = Score_anim.GetComponent<Animator>();
            score_anim_txt = Score_anim.GetComponent<UnityEngine.UI.Text>();


            if (PlayerPrefs.GetInt("bestrec") == 0)

            {
                CurrentLevelNo = 1;
                NextLevelNo = 2;

                cur_lvl_txt_obj.text = CurrentLevelNo.ToString();
                nxt_lvl_txt_obj.text = NextLevelNo.ToString();

                PlayerPrefs.SetInt("cur_lvl_txt", CurrentLevelNo);
                PlayerPrefs.SetInt("nxt_lvl_txt", NextLevelNo);
            }

            else

            {
                cur_lvl_txt_obj.text = PlayerPrefs.GetInt("cur_lvl_txt").ToString();
                nxt_lvl_txt_obj.text = PlayerPrefs.GetInt("nxt_lvl_txt").ToString();

                CurrentLevelNo = PlayerPrefs.GetInt("cur_lvl_txt");
                NextLevelNo = PlayerPrefs.GetInt("nxt_lvl_txt");
            }
        }

        void ColorOfPathObstacke()

        {
            PathColor = new Color32[5];
            obstacleColor = new Color32[5];

            PathColor[0] = new Color32(230, 32, 32, 255);
            PathColor[1] = new Color32(49, 87, 241, 255);
            PathColor[2] = new Color32(174, 14, 224, 255);
            PathColor[3] = new Color32(143, 200, 64, 255);
            PathColor[4] = new Color32(80, 80, 80, 255);

            obstacleColor[0] = new Color32(230, 32, 32, 255);
            obstacleColor[1] = new Color32(49, 87, 241, 255);
            obstacleColor[2] = new Color32(174, 14, 224, 255);
            obstacleColor[3] = new Color32(143, 224, 64, 255);
            obstacleColor[4] = new Color32(80, 80, 80, 255);
        }


        private void FixedUpdate()

        {
            if (LevelFinished)
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50f);
        }

        void LateUpdate()
        {
            if (move_loser_cam)
                StartCoroutine(camera_lose());
        }

        void Update()

        {
            if (red_head)
            {
                StartCoroutine(colorlerpball_head());
            }

            if (Bounce_bool)

            {
                Player.Player_alter.ball_palyer_rig.velocity = new Vector3(0f, 0.8f, 0f);

                StartCoroutine(MakeFalseToMove(Distance));
            }

            if (pathmaker.pathmaker_alter.path_mat_color != null)

            {
                LerpedColor_pth_cltr = Color.Lerp(LerpedColor_pth_cltr, LerpedColor_pth_cltr1,
                    Mathf.PingPong(Time.deltaTime, 10f));
                LerpedColor_obst_mat1 = Color.Lerp(LerpedColor_obst_mat1, LerpedColor_obst_mat2,
                    Mathf.PingPong(Time.deltaTime, 10f));

                pathmaker.pathmaker_alter.path_mat_color.color = LerpedColor_pth_cltr;
                pathmaker.pathmaker_alter.obstacle_mat_color.color = LerpedColor_obst_mat1;
            }
        }


        IEnumerator camera_lose()

        {
            Main_camera_to_right.transform.position = Vector3.Lerp(Main_camera_to_right.transform.position,
                new Vector3(Main_camera_to_right.transform.position.x + 0.5f, Main_camera_to_right.transform.position.y,
                    Main_camera_to_right.transform.position.z - 1f), Time.deltaTime * 5f);

            Retry_menu.GetComponent<CanvasGroup>().alpha = 1;
            Retry_menu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            GameObject.Find("progress").GetComponent<CanvasGroup>().alpha = 0f;
            AirSpeed.Stop();
            yield return new WaitForSeconds(2f);
            move_loser_cam = false;
        }

        void OnCollisionEnter(Collision other)

        {
            if (other.gameObject.CompareTag("Touch") && bounceMode == 1)

            {
                Player.Player_alter.Camfix = false;


                Player.Player_alter.ball_player_coll.radius = 0.6f;

                var indx = PlayerPrefs.GetInt("ch_indx");

                if (indx == 1)

                {
                    Player.Player_alter.right_amount = 0.25f;
                    Player.Player_alter.left_amount = -0.25f;
                }

                if (indx == 3)

                {
                    Player.Player_alter.right_amount = 0.26f;
                    Player.Player_alter.left_amount = -0.26f;
                }

                if (indx != 3 | indx != 1)

                {
                    Player.Player_alter.right_amount = 0.24f;
                    Player.Player_alter.left_amount = -0.24f;
                }

                bounceMode = 2;

                Player.Player_alter.TranslateSpeed = 2f;


                ShiftSpeed = savedSpeed;


                var main_airsp = AirSpeed.main;
                var emi_as = AirSpeed.emission;

                main_airsp.simulationSpeed = airSpeed_simulationspeed;
                emi_as.rateOverTime = 3f;

                if (ShiftSpeed < 21f) //infinite game

                {
                    if (ShiftSpeed > 10f)

                    {
                        ShiftSpeed += 0.13f;

                        main_airsp.simulationSpeed += 0.13f;
                    }

                    else

                    {
                        ShiftSpeed += 0.5f;

                        main_airsp.simulationSpeed += 0.5f;
                    }
                }


                StartCoroutine(Handlethegame(1.5f));

                if (emojichanceps >= amount_ball_recive)

                {
                    emojichanceps = 1;
                }

                Ball_gain.pitch = 1f;

                emoji_animator.Rebind();


                if (transform.childCount > 0)
                    if (PlayerPrefs.GetInt("ch_indx") == 2)
                    {
                        Player.Player_alter.DroidComponent.enabled = true;
                        Player.Player_alter.Plr_ball_child_anim_1.Rebind();

                        Player.Player_alter.Plr_ball_child_anim.Play("jetofdroid");
                    }

                score_anim_txt.color = new Color(0.04f, 0.055f, 0.055f, 0.93f);

                CollisionEffect.transform.position =
                    new Vector3(transform.position.x, transform.position.y, transform.position.z);

                CollisionEffect.Play();
            }

            if (other.gameObject.CompareTag("Obstacle"))

            {
                if (Bodies.Count == 1)

                {
                    Player.Player_alter.ball_player_coll.enabled = false;
                    GameObject.Find("Lose").GetComponent<AudioSource>().Play();

                    if (Score_record > best_Record)
                    {
                        emoji_animator.Play("Emoji_emotion");
                        emoji_img.sprite = emojies[0];
                        emoji_txt.text = "OH! NO";
                    }

                    DestroyBallPos = transform.position;


                    Score_anim.SetActive(false);


                    PlayerPrefs.SetInt("cur_rec", Score_record);
                    retry_current_reco_txt.text = Score_record.ToString();


                    retry_best_reco_txt.text = "Total: " + PlayerPrefs.GetInt("bestrec");

                    FindObjectOfType<Player>().enabled = false;
                    Destroy(GameObject.Find("Speed_lines"));

                    Retry_menu.GetComponent<CanvasGroup>().alpha = 1;
                    Retry_menu.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    GameObject.Find("progress").GetComponent<CanvasGroup>().alpha = 0f;
                    move_loser_cam = true;

                    StartCoroutine(dis_player_collider());
                }
            }
        }


        public IEnumerator dis_player_collider()

        {
            yield return new WaitForSeconds(0.3f);
            Player.Player_alter.ball_player_coll.enabled = false;
        }

        private void OnCollisionExit(Collision other)

        {
            if (other.gameObject.CompareTag("Touch") && bounceMode == 0)

            {
                Player.Player_alter.Camfix = true;

                Player.Player_alter.right_amount = 0.3f;
                Player.Player_alter.left_amount = -0.3f;

                Player.Player_alter.ball_player_coll.radius = 0.5f;

                emoji_animator.Rebind();

                other.gameObject.SetActive(false);


                bounceMode = 1;

                Bounce_bool = true;

                savedSpeed = ShiftSpeed;
                ShiftSpeed = 22f;

                var main_airsp = AirSpeed.main;
                var emi_as = AirSpeed.emission;

                main_airsp.simulationSpeed = 15f;
                emi_as.rateOverTime = 10f;


                if (ShiftSpeed <= 22)

                {
                    Player.Player_alter.TranslateSpeed += 0.3f;
                }

                var rnd_color_path_1 = Random.Range(0, 5);
                var rnd_color_obstacle_1 = Random.Range(0, 5);

                if (rnd_color_path_1 == rnd_color_obstacle_1)
                {
                    rnd_color_path_1 = 1;
                    rnd_color_obstacle_1 = 2;
                }

                LerpedColor_pth_cltr1 = PathColor[rnd_color_path_1];

                LerpedColor_obst_mat2 = obstacleColor[rnd_color_obstacle_1];

                if (transform.childCount > 0)
                    if (PlayerPrefs.GetInt("ch_indx") == 2)

                    {
                        Player.Player_alter.DroidComponent.enabled = false;
                        Player.Player_alter.Plr_ball_child_anim_1.Rebind();
                        transform.GetChild(0).transform.GetChild(1).transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                        Player.Player_alter.Plr_ball_child_anim_1.speed = 1f;
                        Player.Player_alter.Plr_ball_child_anim_1.Play("jetofdroid");
                    }

                transform.rotation = Quaternion.identity;

                Menu_Ui.menu_ui_alter.Progress_anim();

                if (other.gameObject.name == pathmaker.pathmaker_alter._path
                    .ElementAt(pathmaker.pathmaker_alter._path.Count - 1).name)

                {
                    LevelFinished = OpenTGate = true;

                    CurrentLevelNo++;
                    NextLevelNo++;

                    PlayerPrefs.SetInt("cur_lvl_txt", CurrentLevelNo);
                    PlayerPrefs.SetInt("nxt_lvl_txt", NextLevelNo);

                    AirSpeed.Stop();

                    Player_won();
                }
            }
        }


        public void Player_won()

        {
            alter_addpath.CompeleteLevel.GetComponent<Animator>().Play("Comp_lvl");


            GameObject.Find("cards").transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GameObject.Find("cards").transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            GameObject.Find("cards").transform.GetChild(2).GetComponent<ParticleSystem>().Play();
            GameObject.Find("cards").transform.GetChild(3).GetComponent<ParticleSystem>().Play();

            StartCoroutine(alter_addpath.dis_player_collider());

            PlayerPrefs.SetInt("cur_rec", PathGenerator.alter_addpath.Score_record);
            alter_addpath.retry_current_reco_txt.text = PathGenerator.alter_addpath.Score_record.ToString();

            PlayerPrefs.SetInt("bestrec", PlayerPrefs.GetInt("bestrec") + PathGenerator.alter_addpath.Score_record);

            alter_addpath.retry_best_reco_txt.text = "Total: " + PlayerPrefs.GetInt("bestrec");

            alter_addpath.Compelet_best_rec.text = "Total: " + PlayerPrefs.GetInt("bestrec");

            StartCoroutine(load_new_level());
        }

        IEnumerator load_new_level()

        {
            yield return new WaitForSeconds(2f);
            GameObject.Find("restart_Game").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("restart_Game").GetComponent<CanvasGroup>().blocksRaycasts = true;

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene("Game");
        }

        void add_to_Queu()

        {
            var offsetOfPath = 0f;
            var Currnet_ZPoint = 0f;
            var New_ZPoint = 0f;
            var LastTZPoint = 0f;
            var LastZPoint = 0f;

            var YDirection = 0f;

            YDirection = pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 2).transform
                .position.y - 1f;

            LastTZPoint = pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 2).transform
                .position.z;

            LastZPoint = pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 2).transform
                .localScale.z;

            Currnet_ZPoint = pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 1)
                .transform.localScale.z;

            offsetOfPath = LastZPoint - Currnet_ZPoint;

            New_ZPoint = LastTZPoint + ((offsetOfPath + Currnet_ZPoint) - offsetOfPath / 2f) + 35f;

            pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 1).transform.position =
                new Vector3(0f, YDirection, New_ZPoint);

            if (!pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 1).transform
                .GetChild(0).GetComponent<Renderer>().enabled)

            {
                for (int i = 0; i < 2; i++)
                {
                    pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 1).transform
                        .GetChild(i)
                        .GetComponent<Renderer>().enabled = true;
                    pathmaker.pathmaker_alter._path.ElementAt(pathmaker.pathmaker_alter._path.Count - 1).transform
                        .GetChild(i)
                        .GetComponent<BoxCollider>().enabled = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)

        {
            if (other.gameObject.CompareTag("tail"))

            {
                if (PlayerPrefs.GetInt("ch_indx") == 11)
                {
                    Player.Player_alter.Plr_ball_child_anim.Play("heart_bit");
                    StartCoroutine(rebind_anim_charactor());
                }

                if (PlayerPrefs.GetInt("ch_indx") == 12)
                {
                    Player.Player_alter.Plr_ball_child_anim.Play("vlc_anim");
                    StartCoroutine(rebind_anim_charactor());
                }


                DestroyBallPos = other.gameObject.transform.position;

                destroyballeffect.transform.position = DestroyBallPos;
                destroyballeffect.Play();

                other.gameObject.SetActive(false);
                plus_score_txtmesh.color = Color.white;

                if (PlayerPrefs.GetInt("cur_lvl_txt") < 5)

                {
                    Score_record++;

                    plus_score_txtmesh.text = "+1";
                }

                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 5 && PlayerPrefs.GetInt("cur_lvl_txt") < 15)

                {
                    Score_record = Score_record + 2;

                    plus_score_txtmesh.text = "+2";

                    amount_ball_recive = 14;
                }

                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 15 && PlayerPrefs.GetInt("cur_lvl_txt") < 30)
                {
                    Score_record += 4;

                    plus_score_txtmesh.text = "+4";

                    amount_ball_recive = 13;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 30 && PlayerPrefs.GetInt("cur_lvl_txt") < 45)
                {
                    Score_record += 6;

                    plus_score_txtmesh.text = "+6";

                    amount_ball_recive = 12;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 45 && PlayerPrefs.GetInt("cur_lvl_txt") < 75)
                {
                    Score_record += 8;

                    plus_score_txtmesh.text = "+8";

                    amount_ball_recive = 11;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 75 && PlayerPrefs.GetInt("cur_lvl_txt") < 100)
                {
                    Score_record += 10;

                    plus_score_txtmesh.text = "+10";


                    amount_ball_recive = 10;
                }
                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 100 && PlayerPrefs.GetInt("cur_lvl_txt") < 130)
                {
                    Score_record += 15;
                    plus_score_txtmesh.text = "+15";
                    amount_ball_recive = 9;
                }

                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 130 && PlayerPrefs.GetInt("cur_lvl_txt") < 160)
                {
                    Score_record += 20;
                    plus_score_txtmesh.text = "+20";
                    amount_ball_recive = 8;
                }

                else if (PlayerPrefs.GetInt("cur_lvl_txt") >= 160 && PlayerPrefs.GetInt("cur_lvl_txt") < 200)
                {
                    Score_record += 30;
                    plus_score_txtmesh.text = "+30";
                    amount_ball_recive = 7;
                }

                else if (PlayerPrefs.GetInt("cur_lvl_txt") > 200)

                {
                    Score_record += 45;
                    plus_score_txtmesh.text = "+45";
                    amount_ball_recive = 7;
                }

                emojichanceps++;
                // notify the score of orb
                Instantiate(floting_Score_txt,
                    new Vector3(DestroyBallPos.x * -1.5f, DestroyBallPos.y, DestroyBallPos.z), Quaternion.identity);

                score_anim_comp.Rebind();
                score_anim_comp.Play("Score_crown");
                score_anim_txt.text = Score_record.ToString();


                Ball_gain.Play();

                Ball_gain.pitch += 0.2f;

                var rnd_emoji_select = 0;

                if (Score_record < 5)
                    rnd_emoji_select = Random.Range(2, 6);
                else
                    rnd_emoji_select = Random.Range(4, 10);


                if (emojichanceps == rnd_emoji_select && emoji_canvas.alpha == 0f && plus_score_txtmesh.text != "-1")

                {
                    emoji_animator.Rebind();
                    var rnd_emoj_face = Random.Range(Random.Range(1, 7), Random.Range(1, 7));

                    switch (rnd_emoj_face)

                    {
                        case 1:

                            emoji_img.sprite = emojies[1];
                            emoji_txt.text = "Nice!";
                            emoji_animator.Play("Emoji_emotion");

                            break;

                        case 2:

                            emoji_img.sprite = emojies[2];
                            emoji_txt.text = "WoW!";
                            emoji_animator.Play("Emoji_emotion");

                            break;

                        case 3:

                            emoji_img.sprite = emojies[3];
                            emoji_txt.text = "Amazing";
                            emoji_animator.Play("Emoji_emotion");
                            break;

                        case 4:

                            emoji_img.sprite = emojies[4];
                            emoji_txt.text = "Great";
                            emoji_animator.Play("Emoji_emotion");

                            break;

                        case 5:


                            emoji_img.sprite = emojies[4];
                            emoji_txt.text = "Super!";
                            emoji_animator.Play("Emoji_emotion");

                            break;

                        case 6:


                            emoji_img.sprite = emojies[4];
                            emoji_txt.text = "Fantastic!";
                            emoji_animator.Play("Emoji_emotion");

                            break;
                    }

                    jump_audio.Play();
                }
            }
        }


        IEnumerator rebind_anim_charactor()

        {
            yield return new WaitForSeconds(0.3f);


            if (PlayerPrefs.GetInt("ch_indx") == 11)
            {
                Player.Player_alter.BallPlayer.transform.GetChild(0).GetComponent<Animator>().Rebind();
            }


            if (PlayerPrefs.GetInt("ch_indx") == 12)
            {
                Player.Player_alter.BallPlayer.transform.GetChild(0).GetComponent<Animator>().Rebind();
            }
        }


        IEnumerator colorlerpball_head()
        {
            var indx = PlayerPrefs.GetInt("ch_indx");

            switch (indx)

            {
                case 0:

                    Bodies.ElementAt(0).transform.GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 1:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 2:

                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(new Color(0.95f, 0.7f, 0f), Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(Color.red, new Color(0.95f, 0.7f, 0f), Time.time);

                    break;

                case 3:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(new Color(0.8f, 0.36f, 0.026f), Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.red, new Color(0.8f, 0.36f, 0.026f), Time.time);

                    break;

                case 4:

                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[3].color =
                        Color.Lerp(new Color(0.9f, 0.9f, 0.2f), Color.black, Time.time);

                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().materials[3].color =
                        Color.Lerp(Color.black, new Color(0.9f, 0.9f, 0.2f), Time.time);

                    break;

                case 5:

                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 6:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 7:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(Color.white, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(Color.red, Color.white, Time.time);

                    break;


                case 8:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[1].color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 9:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.black, Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.red, Color.black, Time.time);

                    break;

                case 10:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(new Color(0.3f, 0.6f, 1f), Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.red, new Color(0.3f, 0.6f, 1f), Time.time);

                    break;

                case 11:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(new Color(0.735f, 0.17f, 0.17f), new Color(0.3f, 0.6f, 1f), Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().material.color =
                        Color.Lerp(new Color(0.3f, 0.6f, 1f), new Color(0.735f, 0.17f, 0.17f), Time.time);

                    break;

                case 12:

                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(new Color(0.9f, 0.4f, 0f), Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.red, new Color(0.9f, 0.4f, 0f), Time.time);

                    break;

                case 13:

                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(1).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(new Color(0.246f, 0.246f, 0.246f), Color.red, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(1).GetComponent<Renderer>().materials[0].color =
                        Color.Lerp(Color.red, new Color(0.246f, 0.246f, 0.246f), Time.time);

                    break;

                case 14:

                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(5).GetComponent<Renderer>().material.color =
                        Color.Lerp(new Color(0.83f, 0.15f, 0.15f), Color.black, Time.time);
                    yield return new WaitForSeconds(0.5f);
                    Bodies.ElementAt(0).transform.GetChild(0).GetChild(5).GetComponent<Renderer>().material.color =
                        Color.Lerp(Color.black, new Color(0.83f, 0.15f, 0.15f), Time.time);

                    break;
            }

            red_head = false;
        }

        IEnumerator MakeFalseToMove(float time)

        {
            yield return new WaitForSeconds(time);

            Bounce_bool = false;
        }


        IEnumerator Handlethegame(float T)

        {
            yield return new WaitForSeconds(T);
            bounceMode = 0;
        }
    }
}