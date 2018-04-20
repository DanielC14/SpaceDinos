using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoGenerator : MonoBehaviour
{

    public GameObject[] dinos;
    public AnimationClip[] clips;
    public float dinoTime = 5f;
    private Transform player;
    public float[] dinoSpawns = new float[] { 163.9f, 170.02f, 175.08f, 180.78f, 186.42f };
    public static bool singleSpawn = false;
    private List<GameObject> dinoList;
    private int index = 0;

    // Use this for initialization
    void Start()
    {

        dinoList = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnDino());
    }

    void Update()
    {
        if (dinoTime > 0.4f)
        {
            dinoTime -= 0.0008f;
        }

    }

    IEnumerator spawnDino()
    {
        yield return new WaitForSeconds(dinoTime);

        spawnTwo();
        if (index > 4)
            DeleteDino();
        else
            index++;

    }

    void spawnTwo()
    {
        GameObject dino1;
        dino1 = Instantiate(dinos[0]) as GameObject;
        dino1.transform.SetParent(transform);
        int dino1SpawnX = UnityEngine.Random.Range(0, dinoSpawns.Length);
        dino1.transform.position = new Vector3(dinoSpawns[dino1SpawnX], -17.45f, player.position.z + 500);
    
        if (PlayerMove.isFast)
        {
            dino1.transform.GetComponent<Animation>().clip = clips[1];
            dino1.transform.GetComponent<Animation>().Play();
        }

        dinoList.Add(dino1);

        GameObject dino2;
        dino2 = Instantiate(dinos[0]) as GameObject;
        dino2.transform.SetParent(transform);
        int dino2SpawnX = UnityEngine.Random.Range(0, dinoSpawns.Length);
        dino2.transform.position = new Vector3(dinoSpawns[dino2SpawnX], -17.45f, player.position.z + 500);
        if (PlayerMove.isFast)
        {
            dino2.transform.GetComponent<Animation>().clip = clips[1];
            dino2.transform.GetComponent<Animation>().Play();
        }
        dinoList.Add(dino2);

        StartCoroutine(spawnDino());
    }

    void DeleteDino()
    {
        Destroy(dinoList[0]);
        dinoList.RemoveAt(0);
        Destroy(dinoList[0]);
        dinoList.RemoveAt(0);
    }
}
