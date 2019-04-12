using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaseSelector : MonoBehaviour
{
    public static FaseSelector FS = null;
    public KeyCode kNext = KeyCode.UpArrow;
    public KeyCode kReturn = KeyCode.DownArrow;
    public KeyCode selecter = KeyCode.Space;
    public List<GameObject> paths = null;
    public List<Vector3> pathsPosition = null;
    public List<string> scenePaths = null;
    public float speed = 3.0f;
    public float moveAjuster = 0.1f;
    MeshRenderer mr = null;

    private int thisIndex = 0;
    public int firstIndex = 0;
    private int endIndex;

    private bool isInMainScene = false;
    private bool isMoving = false;

    private Vector3 moveTo = new Vector3(0.0f, 0.0f, 0.0f);

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (FS == null)
        {
            mr = gameObject.GetComponent<MeshRenderer>();
            endIndex = paths.Count - 1;
            thisIndex = firstIndex;
            moveTo = paths[firstIndex].transform.position;
            pathsPosition = new List<Vector3>();
            foreach (GameObject go in paths)
            {
                pathsPosition.Add(go.transform.position);
                //Destroy(go);
            }
            paths = null;
            this.transform.position = moveTo;
            FS = this;
        }
        else
        {
            if (this != FaseSelector.FS)
            {
                Destroy(gameObject);
            }
        }
        returnToMainGame();
    }

    public void returnToMainGame()
    {
        isInMainScene = true;
        FS.gameObject.SetActive(true);
    }

    //Dada uma entrada decide o que deve ser feito
    void Decider()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(kNext) && endIndex > thisIndex)
            {
                isMoving = true;
                thisIndex++;
                Debug.Log(thisIndex);
                Debug.Log("Not Read To Go");

                moveTo = pathsPosition[thisIndex];
            }

            if (Input.GetKeyDown(kReturn) && 0 < thisIndex)
            {
                isMoving = true;
                thisIndex--;
                Debug.Log(thisIndex);
                Debug.Log("Not Read To Go");

                moveTo = pathsPosition[thisIndex];
            }

            if (Input.GetKeyDown(selecter))
            {
                isInMainScene = false;
                SceneManager.LoadScene(scenePaths[thisIndex], LoadSceneMode.Single);

                isInMainScene = false;
                FS.gameObject.SetActive(false);
            }
        }
    }

    void Mover()
    {
        Debug.Log(isInMainScene);
        if (isInMainScene)
        {
            if (isMoving)
            {
                Vector3 myPos = this.transform.position;
                Vector3 direction = Vector3.Normalize(moveTo - myPos);
                Vector3 pos = myPos + direction * speed * Time.deltaTime;
                float distance = Vector3.Distance(pos, moveTo);
                if (distance <= moveAjuster)
                {
                    pos = moveTo;
                    isMoving = false;
                    Debug.Log("Read To Go");
                }
                transform.position = pos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Decider();
        Mover();
    }
}
