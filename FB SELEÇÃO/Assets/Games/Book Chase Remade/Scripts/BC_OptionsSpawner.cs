using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BC_OptionsSpawner : MonoBehaviour
{
    // Singleton
    public static BC_OptionsSpawner os = null;

    [Header("Question Related Variables:")]
    public Text text; // Canvas Text Object
    public string question = "starting"; // Question text
    public List<string> options = new List<string>(); // Options List
    public GameObject qPrefab;
    private List<GameObject> ansTemp = new List<GameObject>(); // Options object list

    [Header("Spawn Related Variables:")]
    public float minRadius = 15f;

    public List<Transform> tList = new List<Transform>();

    // Awake, Start & Update
    void Awake()
    {
        if (os == null) os = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
    }

    // Operation Creation Methods
    public void CreateOperation()
    {
        if (BC_Configuration.config.isAutomatic)
        {
            // NEVER USE
        }
        else
        {
            // Choose Question
            BC_SnL.snl.SetRandomQuest();
            question = BC_SnL.snl.actQuest.question;
            text.text = question;
            options = BC_SnL.snl.actQuest.options;

            List<Vector3> posList = SpawnPosition(options.Count);

            for (int i = 0; i < posList.Count; i++)
            {
                GameObject book = Object.Instantiate(qPrefab, posList[i], Quaternion.identity);
                ansTemp.Add(book);
                BC_Option cmp = book.GetComponent<BC_Option>();
                cmp.answer = options[i];
                if (i == 0)
                {
                    cmp.isCorrect = true;
                }
            }

            BC_Configuration.config.contQuest++;
        }
    }

    // Spawn Position Methods
    public bool isDistanceValid(Vector3 spawnPos, List<Vector3> oldPos)
    {
        foreach (Vector3 pos in oldPos)
        {
            if (Vector3.Distance(spawnPos, pos) < minRadius) { return false; }
        }
        return true;
    }
    public Vector3 SpawnPosition(List<Vector3> oldPos)
    {
        Vector3 newPos = new Vector3(0, 0, 0);
        int i = 0;
        do
        {
            //pode quebrar aqui!!!
            newPos.x = Random.Range(BC_Player.plyr.minPosXZ.x, BC_Player.plyr.maxPosXZ.x);
            newPos.y = Random.Range(BC_Player.plyr.minPosXZ.y, BC_Player.plyr.maxPosXZ.y);
            if(i > 80)
            {
                Debug.Log("BREAK!");
                break;
            }
            //Debug.Log(newPos);
            i++;
        } while (!isDistanceValid(newPos, oldPos));

        return newPos;
    }
    public List<Vector3> SpawnPosition(int nPos)
    {
        List<Vector3> listT = new List<Vector3>();

        List<Vector3> pos = new List<Vector3>();

        foreach(Transform t in tList)
        {
            listT.Add(t.position);
        }

        do
        {
            int index = Random.Range(0, listT.Count - 1);
            Debug.Log(index);
            Vector3 temp = listT[index];
            listT.RemoveAt(index);

            if (Vector3.Distance(temp, transform.position) < minRadius)
            {
                continue;
            }

            pos.Add(temp);
            nPos--;

        } while (nPos > 0);

        return pos;
    }

    //Destroy Methods
    public void Destroyer()
    {
        foreach(GameObject a in ansTemp)
        {
            Destroy(a.gameObject);
        }

        ansTemp = new List<GameObject>();
    }
}
