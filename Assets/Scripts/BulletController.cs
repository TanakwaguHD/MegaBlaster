using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// class definition
//------------------------------------------------------------------------------
public class BulletController : MonoBehaviour 
{
    public float speed = 10.0f;
	public float deactivateTimer = 1.5f;

    private Vector3 direction;

    //-----------------------------------------------------------------
    // public static methods
    //-----------------------------------------------------------------

    public static void Spawn(Vector3 location, Vector3 shootDirection, string prefabName)
    {
        GameObject bulletGo = (GameObject)Instantiate(Resources.Load(prefabName));
        bulletGo.transform.position = location;
        BulletController bullet = bulletGo.GetComponent<BulletController>();
        bullet.direction = shootDirection;
    }

    //-----------------------------------------------------------------
    // public methods
    //-----------------------------------------------------------------

    //-----------------------------------------------------------------
    // protected mono methods
    //-----------------------------------------------------------------

    protected void Awake()
    {
        
    }

    protected void Start()
    {
        
    }

    protected void Update()
    {
        transform.position += direction * (Time.deltaTime * speed);

        deactivateTimer -= Time.deltaTime;
		if( deactivateTimer <= 0 )
        {
            gameObject.SetActive(false);
			DestroyImmediate(gameObject);
        }
    }

    protected void OnDisable()
    {
       Destroy(gameObject);
    }

    //-----------------------------------------------------------------
    // private methods
    //-----------------------------------------------------------------
}