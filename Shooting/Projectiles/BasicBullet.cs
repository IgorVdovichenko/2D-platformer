using UnityEngine;

sealed class BasicBullet : Projectile
{
	private readonly float lifeTime = 7f;
	private readonly string enemyTag = "Enemy";

	SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
    {
        Destroy(gameObject, lifeTime);
		SetRotation();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position =
			Vector3.MoveTowards(transform.position, transform.position + Direction, Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
            enemy.GetDamage(Damage);
            Destroy(gameObject);
        }
    }

	private void SetRotation()
	{
		float angle = Vector3.Angle(transform.right, Direction);
		Vector3	rotation = new Vector3(0, 0, angle);

		if(angle > 90)
		{
			spriteRenderer.flipY = true;
		}

		transform.rotation = Quaternion.Euler(rotation);
	}
}
