using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public SimpleObjectPool bulletObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Shoot(Transform weaponBarrelEnd, SimpleObjectPool bulletObjectPool)
    {
        this.bulletObjectPool = bulletObjectPool;
        gameObject.transform.SetParent(null);
        transform.position = weaponBarrelEnd.position;
        transform.rotation = weaponBarrelEnd.rotation;
        GetComponent<Rigidbody>().velocity = transform.forward * 25;

        StartCoroutine(WaitToReturnToObjectPool());
    }

    IEnumerator WaitToReturnToObjectPool()
    {
        yield return new WaitForSeconds(5);
        
        //gameObject.SetActive(false);
        bulletObjectPool.ReturnObject(gameObject);
    }
}
