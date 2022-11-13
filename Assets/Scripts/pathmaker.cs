using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace PathMakerDll

{
    public class pathmaker : MonoBehaviour

    {
        public List<GameObject> _path = new List<GameObject>();
        // public List<GameObject> collectorlst = new List<GameObject>();

        public List<GameObject> _obstacle = new List<GameObject>();
        public List<GameObject> BallTail = new List<GameObject>();

        private readonly Vector3[] _pathSizeList = new Vector3[3]
            {new Vector3(1f, 40f, 40f), new Vector3(1f, 40f, 50f), new Vector3(1f, 40f, 60f)};

        private Vector3[] _obstSizeList = new Vector3[4];


        private int[] rnd_xpos_maker = new[] {1, 2, 3, 9, 5, 6, 9, 12, 22};

        public GameObject PrefabPath, PrefabObstacle;

        public GameObject Install_Ball;

        public float _zDirection = 0f;

        private float _yDirection = 0f;
        private float _yDirectionofball = 0f;

        private int _valOfXPoint, counter, _valOfObstSze;

        public float _xPoint, _zPoint, b_zPoint;

        public Camera MnCamera;

        private float DistanceOfPaths;


        float offsetOfPath;

        float offsetOfObstacle;

        public float lOfObstDistance = 0;

        private Color path_collector, obstacle_color;

        public int rnd_gate;

        public static pathmaker pathmaker_alter;

        public int Number_of_path;

        public Material path_mat_color, collector_mat_color, collector_mat_color_obstacle, obstacle_mat_color;

        public GameObject loading_panel;

        private int[] NumberOfPath = new[] {4, 5, 6, 8, 10};

        public Color32[] ball_color;

        void OnEnable()

        {
            MakePaths();

            StartCoroutine(BallSituation());

            _yDirectionofball = 20.075f;
        }

        void Awake()

        {
            pathmaker_alter = this;
        }

        public void MakePaths()

        {
            MnCamera = Camera.main;

            _valOfXPoint = Random.Range(0, 3);

            if (_valOfXPoint == 0)
                _xPoint = -0.3f;
            else
                _xPoint = 0.3f;


            if (PlayerPrefs.GetInt("cur_lvl_txt") == 0)
                Number_of_path = 4;
            else

            {
                if (PlayerPrefs.GetInt("cur_lvl_txt") < 20)
                    Number_of_path = NumberOfPath[Random.Range(0, 3)];
                else
                    Number_of_path = NumberOfPath[Random.Range(0, 5)];
            }

            //create and install the paths + obstacles   
            for (var path_icounter = 0; path_icounter < Number_of_path; path_icounter++)

            {
                var pathSze = 0;

                if (_path.Count == 0)
                    pathSze = 0;
                else
                    pathSze = Random.Range(0, 3);

                var RangeOfCycleInObstacle = 0;

                var RangeOfCycleInBallTail = 0;


                switch (pathSze)

                {
                    case 0:


                        RangeOfCycleInObstacle = Random.Range(8, 10);
                        RangeOfCycleInBallTail = RangeOfCycleInObstacle;


                        _obstSizeList[0] = new Vector3(0.35f, 0.006f, 0.05f);
                        _obstSizeList[1] = new Vector3(0.35f, 0.006f, 0.08f);
                        _obstSizeList[2] = new Vector3(0.35f, 0.006f, 0.10f);
                        _obstSizeList[3] = new Vector3(0.35f, 0.006f, 0.11f);

                        break;

                    case 1:


                        RangeOfCycleInObstacle = Random.Range(9, 11);
                        RangeOfCycleInBallTail = RangeOfCycleInObstacle;

                        _obstSizeList[0] = new Vector3(0.35f, 0.006f, 0.04f);
                        _obstSizeList[1] = new Vector3(0.35f, 0.006f, 0.07f);
                        _obstSizeList[2] = new Vector3(0.35f, 0.006f, 0.09f);
                        _obstSizeList[3] = new Vector3(0.35f, 0.006f, 0.1f);

                        break;

                    case 2:


                        RangeOfCycleInObstacle = Random.Range(10, 12);
                        RangeOfCycleInBallTail = RangeOfCycleInObstacle;

                        _obstSizeList[0] = new Vector3(0.35f, 0.006f, 0.03f);
                        _obstSizeList[1] = new Vector3(0.35f, 0.006f, 0.06f);
                        _obstSizeList[2] = new Vector3(0.35f, 0.006f, 0.09f);
                        _obstSizeList[3] = new Vector3(0.35f, 0.006f, 0.1f);

                        break;
                }


                if (_path.Count > 0)

                {
                    offsetOfPath = _path.ElementAt(_path.Count - 1).transform.localScale.z - _pathSizeList[pathSze].z;

                    _zDirection = _path.ElementAt(_path.Count - 1).transform.position.z +
                                  ((offsetOfPath + _pathSizeList[pathSze].z) - offsetOfPath / 2f) + 35f;
                }

                GameObject newPrefab = Instantiate(PrefabPath, new Vector3(0f, _yDirection, _zDirection),
                    Quaternion.identity);

                newPrefab.name += _path.Count.ToString();

                _path.Add(newPrefab);

                if (_path.Count > 0)

                {
                    newPrefab.transform.localScale = _pathSizeList[pathSze];

                    newPrefab.transform.GetChild(0).transform.GetComponent<Balancer>().ParentName =
                        _path.ElementAt(_path.Count - 1);

                    newPrefab.transform.GetChild(0).transform.parent = null;

                    _yDirection = _path.ElementAt(_path.Count - 1).transform.position.y - 1f;


                    for (int j = 0; j <= RangeOfCycleInObstacle; j++)

                    {
                        _valOfObstSze = Random.Range(0, 4);


                        var rnd = Random.Range(1, 9);

                        GameObject ObstacleObj = Instantiate(PrefabObstacle, Vector3.zero, Quaternion.identity,
                            _path.ElementAt(_path.Count - 1).transform);


                        if (rnd_xpos_maker[rnd] != 9)
                            ObstacleObj.transform.localScale = _obstSizeList[_valOfObstSze];
                        else
                            ObstacleObj.transform.localScale = _obstSizeList[0];

                        if (j == 0)
                            _path.ElementAt(_path.Count - 1).transform.GetChild(0).transform.localPosition =
                                new Vector3(_xPoint, 0.502f, -0.5f
                                                             + _path.ElementAt(_path.Count - 1).transform.GetChild(0)
                                                                 .transform.localScale.z / 2f);


                        if (rnd_xpos_maker[rnd] != 3)
                            if (j > 0 && _xPoint == _obstacle.ElementAt(_obstacle.Count - 1).transform.localPosition.x)
                                _xPoint = _xPoint * -1;


                        if (j >= 1)

                        {
                            switch (pathSze)

                            {
                                case 0:
                                    lOfObstDistance = 0.08f;
                                    break;

                                case 1:
                                    lOfObstDistance = 0.075f;
                                    break;

                                case 2:
                                    lOfObstDistance = 0.045f;
                                    break;
                            }


                            _zPoint = (_obstacle.ElementAt(_obstacle.Count - 1).transform.localPosition.z +
                                       (_obstacle.ElementAt(_obstacle.Count - 1).transform.localScale.z
                                        + ObstacleObj.transform.localScale.z) / 2f) + lOfObstDistance;


                            ObstacleObj.transform.localPosition = new Vector3(_xPoint, 0.502f, _zPoint);
                        }

                        _obstacle.Add(ObstacleObj);
                    }

                    _yDirectionofball = _path.ElementAt(_path.Count - 1).transform.GetChild(0).localPosition.y;


                    var ObtSzeAlter = 0;
                    var ChildCounter = 0;
                    var ChildCounterObstacle = 0;


                    //create orbs and place them on the path 
                    for (int Bt = 0; Bt <= RangeOfCycleInBallTail; Bt++)

                    {
                        for (ObtSzeAlter = 0; ObtSzeAlter < _obstSizeList.Length; ObtSzeAlter++)

                        {
                            if (_path.ElementAt(_path.Count - 1).transform.GetChild(ChildCounter).localScale.z ==
                                _obstSizeList[ObtSzeAlter].z)

                            {
                                ChildCounter++;
                                break;
                            }
                        }

                        for (int BallInTheRow = 0; BallInTheRow < 2; BallInTheRow++)
                        {
                            GameObject ballt = Instantiate(Install_Ball, Vector3.zero, Quaternion.identity);

                            ballt.transform.parent = _path.ElementAt(_path.Count - 1).transform;

                            BallTail.Add(ballt);

                            switch (ObtSzeAlter)

                            {
                                case 0:

                                    b_zPoint = _path.ElementAt(_path.Count - 1).transform.GetChild(ChildCounterObstacle)
                                        .localPosition.z + 0.09f;

                                    ChildCounterObstacle++;

                                    break;

                                case 1:


                                    b_zPoint = _path.ElementAt(_path.Count - 1).transform.GetChild(ChildCounterObstacle)
                                        .localPosition.z + 0.011f;

                                    ChildCounterObstacle++;

                                    break;

                                case 2:


                                    b_zPoint = _path.ElementAt(_path.Count - 1).transform.GetChild(ChildCounterObstacle)
                                        .localPosition.z + 0.07f;

                                    ChildCounterObstacle++;

                                    break;
                            }

                            var random_place_of_ball = Random.Range(0, 2);
                            var place_of_ball_LR = 0f;

                            if (random_place_of_ball == 0)
                                place_of_ball_LR = 0.25f;
                            else
                                place_of_ball_LR = -0.25f;

                            BallTail.ElementAt(BallTail.Count - 1).transform.localPosition =
                                new Vector3(place_of_ball_LR, _yDirectionofball, b_zPoint);
                        }
                    }
                }
            }

            path_mat_color = _path.ElementAt(0).GetComponent<Renderer>().material;
            obstacle_mat_color = _obstacle.ElementAt(0).GetComponent<Renderer>().material;

            for (int i = 0; i < _path.Count; i++)
                _path.ElementAt(i).GetComponent<Renderer>().material = path_mat_color;


            for (int j = 0; j < _obstacle.Count; j++)
            {
                _obstacle.ElementAt(j).GetComponent<Renderer>().material = obstacle_mat_color;
            }
        }


        IEnumerator BallSituation()

        {
            yield return new WaitForSeconds(0.1f);

            Player.Player_alter.BallPlayer.transform.position = new Vector3(_xPoint, 20.075f, -19.9f);
            MnCamera.transform.position = new Vector3(0f, 21.5f, -25f);


            #region ball situation

            #endregion


            var ballxpos = Player.Player_alter.BallPlayer.transform.position.x;

            if (ballxpos == -0.3f)

                Player.Player_alter.MoveBallLeftRight = 2;
            else
                Player.Player_alter.MoveBallLeftRight = 1;


            for (int i = 0; i < 2; i++)

            {
                _obstacle.ElementAt(i).GetComponent<Renderer>().enabled = false;
                _obstacle.ElementAt(i).GetComponent<BoxCollider>().enabled = false;
            }

            yield return new WaitForSeconds(0.4f);
            Destroy(loading_panel);
        }
    }
}