using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public enum BULLET_TYPE { SINGLE, DOUBLE, TRIPLE }

	public static BULLET_TYPE bulletType;
	public static int scoreCount;
	public static int lifeCount;

	public float speed = 2;
	
	private float screenBoundWidth;
	private float shotTimer;

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
		lifeCount = 5;
		scoreCount = 0;
		bulletType = BULLET_TYPE.SINGLE;
	}

	protected void Start()
	{
		Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.nearClipPlane));
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		screenBoundWidth = p.x + (spriteRenderer.sprite.bounds.size.x/2*transform.localScale.x);
	}

	protected void OnTriggerEnter(Collider otherCollider)
	{
		/*if(!otherCollider.CompareTag("Player"))
        {
        	if ( otherCollider.GetComponent<BulletController>() )
            	otherCollider.gameObject.SetActive(false);
        	//DeathEffectController.Spawn( transform.position, "PlayerDeathEffect" );

            lifeCount--;
            if(lifeCount <= 0)
			{
				gameObject.SetActive(false);
			}
        }*/
    }
	
	protected void Update()
	{
		// Keyboard Movement & Firing
		/*if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
		if(transform.position.x < -screenBoundWidth)
		{
			transform.position = new Vector3(screenBoundWidth, transform.position.y, transform.position.z);
		}
		else if(transform.position.x > screenBoundWidth)
		{
			transform.position = new Vector3(-screenBoundWidth, transform.position.y, transform.position.z);
		}*/
		
		// Shoot Bullet
		/*if(Input.GetKeyDown(KeyCode.Space) == true )
        {
        	if(bulletType == BULLET_TYPE.SINGLE)
			{
				BulletController.Spawn(transform.position, Vector3.up, "PlayerBullet");
			}
			else if(bulletType == BULLET_TYPE.DOUBLE)
			{
				BulletController.Spawn(transform.position, new Vector3(-0.3f, 1f, 0f), "PlayerBullet");
				BulletController.Spawn(transform.position, new Vector3(0.3f, 1f, 0f), "PlayerBullet");
			}
			else if(bulletType == BULLET_TYPE.TRIPLE)
			{
				BulletController.Spawn(transform.position, Vector3.up, "PlayerBullet");
				BulletController.Spawn(transform.position, new Vector3(-0.3f, 1f, 0f), "PlayerBullet");
				BulletController.Spawn(transform.position, new Vector3(0.3f, 1f, 0f), "PlayerBullet");
			}
        }*/
	}

	//-----------------------------------------------------------------
	// private methods
	//-----------------------------------------------------------------
}
