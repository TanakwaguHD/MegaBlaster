using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour 
{
	public enum ENEMY_TYPE { TOP_DOWN, LEFT_TO_RIGHT, RIGHT_TO_LEFT, DIAGONAL_LEFT,	DIAGONAL_RIGHT, TOTAL }

	private Vector3 destination;
    private float fireTimer;
    private ENEMY_TYPE enemyType;

    private float screenBoundWidth;
    private float screenBoundInWidth;
    private float screenBoundHeight;
    private float screenBoundInHeight;

	//-----------------------------------------------------------------
	// public static methods
	//-----------------------------------------------------------------

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
		Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		screenBoundWidth = p.x + (spriteRenderer.sprite.bounds.size.x/2*transform.localScale.x);
		screenBoundInWidth = p.x - (spriteRenderer.sprite.bounds.size.x/2*transform.localScale.x);
		screenBoundHeight = p.y + (spriteRenderer.sprite.bounds.size.y/2*transform.localScale.y);
		screenBoundInHeight = p.y - (spriteRenderer.sprite.bounds.size.y/2*transform.localScale.y);
		Respawn();
    }

    protected void OnTriggerEnter(Collider otherCollider)
    {
        /*if(otherCollider.CompareTag("Player"))
        {
            if ( otherCollider.GetComponent<BulletController>() )
            {
				otherCollider.gameObject.SetActive(false);
				// Drop power up
				//if(Random.Range(0, 10) == 0)
				//	ItemDropController.Spawn( transform.position );
            }

            PlayerController.scoreCount += 100;
            //DeathEffectController.Spawn( transform.position, "EnemyDeathEffect" );
			Respawn();
        }*/
    }

    protected void Update()
    {
		UpdateMove();
		CheckBoundary();
    }

    //-----------------------------------------------------------------
	// private methods
	//-----------------------------------------------------------------
    
    private void UpdateMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, 4.0f * Time.deltaTime);

        // Fire
        /*fireTimer -= Time.deltaTime;
        if(fireTimer <= 0.0f)
        {
            BulletController.Spawn(transform.position, Vector3.down, "EnemyBullet");
            fireTimer = Random.Range(0.5f, 1.0f);
        }*/
    }

	private void CheckBoundary()
	{
		if(Vector3.Distance(transform.position, destination) <= 0.1f)
		{
			Respawn();
		}
	}

	private void Respawn()
	{	
		enemyType = (ENEMY_TYPE)Random.Range(0, (int)ENEMY_TYPE.TOTAL);
		fireTimer = Random.Range(0.1f, 0.2f);

		if(enemyType == ENEMY_TYPE.TOP_DOWN)
		{
			transform.position = new Vector3(Random.Range(-screenBoundInWidth, screenBoundInWidth), screenBoundHeight, transform.position.z);
			destination = new Vector3(transform.position.x, -screenBoundHeight, transform.position.z);
		}
		else if(enemyType == ENEMY_TYPE.LEFT_TO_RIGHT)
		{
			transform.position = new Vector3(-screenBoundWidth, Random.Range(0, screenBoundInHeight), transform.position.z);
			destination = new Vector3(screenBoundWidth, transform.position.y, transform.position.z);
		}
		else if(enemyType == ENEMY_TYPE.RIGHT_TO_LEFT)
		{
			transform.position = new Vector3(screenBoundWidth, Random.Range(0, screenBoundInHeight), transform.position.z);
			destination = new Vector3(-screenBoundWidth, transform.position.y, transform.position.z);
		}
		else if(enemyType == ENEMY_TYPE.DIAGONAL_LEFT)
		{
			transform.position = new Vector3(-screenBoundWidth, screenBoundHeight, transform.position.z);
			destination = new Vector3(screenBoundWidth, -screenBoundHeight, transform.position.z);
		}
		else if(enemyType == ENEMY_TYPE.DIAGONAL_RIGHT)
		{
			transform.position = new Vector3(screenBoundWidth, screenBoundHeight, transform.position.z);
			destination = new Vector3(-screenBoundWidth, -screenBoundHeight, transform.position.z);
		}
	}
}


