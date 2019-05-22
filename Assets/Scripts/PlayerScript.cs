using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private bool rotatingRight = false;
    private bool rotatingLeft = false;

    public Transform weaponBarrelEnd;
    public SimpleObjectPool cartucho;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || rotatingRight)
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || rotatingLeft)
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           shoot();
        }
    }

    public void shoot(){
        GameObject newBullet = (GameObject) cartucho.GetObject();
        newBullet.GetComponent<BulletScript>().Shoot(weaponBarrelEnd, cartucho);
    }
}
