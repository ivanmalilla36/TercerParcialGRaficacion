using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateEnemys : MonoBehaviour
{
    public SimpleObjectPool enemyCartucho;
    public Transform enemySpawn;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemyspawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void enemyspawn()
    {
        GameObject newEnemy = (GameObject) enemyCartucho.GetObject();
        newEnemy.GetComponent<EnemyScript>().generateEnemy(enemySpawn, enemyCartucho, playerPosition, this);
    }
}
