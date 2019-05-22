using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
	public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(){
    	player.GetComponent<PlayerScript>().shoot();
    }
    
    public void turnRight()
    {
	    transform.Rotate(Vector3.up, 90 * Time.deltaTime);
    }

    public void TurnLeft()
    {
	    transform.Rotate(Vector3.up, -90 * Time.deltaTime);
	}
}
