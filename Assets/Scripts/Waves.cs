using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnPoints;
    int enemyCount=0;
    // Start is called before the first frame update
    void Start()
    {
        if(enemy==null){
            Debug.LogError("Enemy needs to be set!");
        }
        Debug.Log("Wave 1 starting");
        StartCoroutine(Wave1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDied(int count){
        enemyCount-=count;
    }
    IEnumerator SpawnEnemies(float number){
        while(number>0){
            //Spawn at all spawnpoints;
            for(int i = 0; i < spawnPoints.Length ; i++){
                if(number==0){
                    yield break;
                }
                GameObject e = Instantiate<GameObject>(enemy, new Vector3(spawnPoints[i].position.x,spawnPoints[i].position.y,spawnPoints[i].position.z),Quaternion.identity);
                number--;
            }
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator Wave1(){
        enemyCount = 4;
        StartCoroutine(SpawnEnemies(2));
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnEnemies(2));
        yield return new WaitUntil(()=>enemyCount==0);
        Debug.Log("Wave 2 starting");
        StartCoroutine(Wave2());
    }
    IEnumerator Wave2(){
        enemyCount = 7;
        StartCoroutine(SpawnEnemies(3));
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnEnemies(4));
        yield return new WaitUntil(()=>enemyCount==0);
        Debug.Log("Wave 3 starting");
        StartCoroutine(Wave3());
    }
    IEnumerator Wave3(){
        StartCoroutine(SpawnEnemies(4));
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnEnemies(5));
    }
    void Wave4(){

    }
    void Wave5(){

    }
}
