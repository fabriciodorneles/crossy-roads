using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform startPos = null;

    //spawn time based
    public float delayMin = 1.5f;
    public float delayMax = 5;
    public float speedMin = 1;
    public float speedMax = 4;

    // spawn at start
    public bool useSpawnPlacement = false;
    public int spawnCountMin = 4;
    public int spawnCountMax = 20;

    private float lastTime = 0;
    private float delayTime = 0;
    private float speed = 0;
    
    [HideInInspector] public GameObject item = null; //é publica mas não aparece no inspector (no Unity)/onde vai sinalizar qual vai ser o item que vai entrar
    [HideInInspector] public bool goLeft = false; //idem acima. Checa a direção, se não for left é right..
    [HideInInspector] public float spawnLeftPos = 0;
    [HideInInspector] public float spawnRightPos = 0; // posições do Spawn

    void Start ()
    {
        if ( useSpawnPlacement ) //se é moeda ou arvore
        {
            int spawnCount = Random.Range(spawnCountMin, spawnCountMax);

            for (int i=0; i < spawnCount; i++)
            {
                SpawnItem();
            }
        }
        else
        {
            speed = Random.Range(speedMin, speedMax);
            //Debug.Log("setou speed para" + speed);
        }
    } 

    void Update ()
    {
        if (useSpawnPlacement) return; // Se é moeda já tá feito (ACHO)
        if (Time.time > lastTime + delayTime) // Time.time retorna o tempo em segundos desde o inicio do jogo
        {
            //Debug.Log("if do time");

            lastTime = Time.time; //Atualiza o Time

            delayTime = Random.Range(delayMin, delayMax);

            SpawnItem();

        }
    } 

    void SpawnItem ()
    {
        //Debug.Log("Spawn Item");

        GameObject obj = Instantiate(item) as GameObject;

        obj.transform.position = GetSpawnPosition();

        float direction = 0; if (goLeft) direction = 180; 

        if (!useSpawnPlacement)
        {
            obj.GetComponent<Mover>().speed = speed;
            obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);
        }

    }

    Vector3 GetSpawnPosition () //pra retornar na função um Vector3
    {
        if (useSpawnPlacement) //se usa é moeda (ou arvore será?)
        {
            int x = (int)Random.Range(spawnLeftPos, spawnRightPos);

            Vector3 pos = new Vector3(x, startPos.position.y, startPos.position.z); //(X,Y,Z) o x é randomico na range no caso de moedas. Y e Z acho que vai definir depois a medida em que for montando
            return pos;

        }
        else //carro/caminhão/trem
        {
            return startPos.position;
        }
    }
}
