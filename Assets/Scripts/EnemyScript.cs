using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	 public Transform playerPosition;
	 public SimpleObjectPool cartucho;
	 public Transform weaponBarrelEnd;
     public bool Alive = true;
     public SimpleObjectPool enemyCartucho;
     public Transform enemySpawn;

     private generateEnemys generateEnemys;
     // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToShootAgain());
    }

    // Update is called once per frame
    void Update()
    {
    	
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            Alive = false;
            StartCoroutine(WaitToReturnToObjectPool());
            generateEnemys.enemyspawn();
        }
    }
    
    

    IEnumerator WaitToShootAgain()
    {
        int secondsToWait = Random.Range(2, 5);
    	yield return new WaitForSeconds(secondsToWait);
        if (Alive)
        {
	        Shoot();
            StartCoroutine(WaitToShootAgain());
        }

    }

    public void Aim(Transform target)
    {
    	transform.LookAt(target);
    }

    public void Shoot()
    {
    	 Aim(playerPosition);
    	 GameObject newBullet = (GameObject) cartucho.GetObject();
    	 newBullet.GetComponent<BulletScript>().Shoot(weaponBarrelEnd, cartucho);
    }


    public void generateEnemy(Transform enemySpawn, SimpleObjectPool enemyCartucho, Transform playerPosition, generateEnemys generateEnemys)
    {
	    this.generateEnemys = generateEnemys;
	    var random = Random.Range(0, 4);
	    this.playerPosition = playerPosition;
	    this.enemyCartucho = enemyCartucho;
	    transform.SetParent(enemySpawn);
	    transform.position = new Vector3(enemySpawn.position.x + random , enemySpawn.position.y + 1, enemySpawn.position.z + random);
	    transform.rotation = enemySpawn.rotation;
	    WaitToShootAgain();
    }
    
    IEnumerator WaitToReturnToObjectPool()
    {
	    yield return new WaitForSeconds(5);
	    enemyCartucho.ReturnObject(gameObject);
    }
}
