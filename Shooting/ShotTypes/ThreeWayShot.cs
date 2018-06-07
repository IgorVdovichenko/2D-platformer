using UnityEngine;

[CreateAssetMenu]
public class ThreeWayShot : ShootingType
{
	[Range(10, 90)]
	public float angle;

	public override void Shoot(Vector3 direction, Vector3 point, Quaternion rotation)
	{
		InstantiateProjectile(direction, point, rotation);

		float x = direction.magnitude * Mathf.Cos(Mathf.Deg2Rad * angle);
		float y = direction.magnitude * Mathf.Sin(Mathf.Deg2Rad * angle);

		float ang = Vector3.Angle(projectile.transform.right, direction);

		if(ang <= 90)
		{
			Vector3 dir = new Vector3(x, y, 0);
			InstantiateProjectile(dir, point, rotation);

			dir = new Vector3(x, -y, 0);
			InstantiateProjectile(dir, point, rotation);
		}

		else
		{
			Vector3 dir = new Vector3(-x, y, 0);
			InstantiateProjectile(dir, point, rotation);

			dir = new Vector3(-x, -y, 0);
			InstantiateProjectile(dir, point, rotation);
		}
	}

	private void InstantiateProjectile(Vector3 direction, Vector3 point, Quaternion rotation)
	{
		GameObject bullet = Instantiate(projectile, point, rotation);
		bullet.GetComponent<Projectile>().Direction = direction;
	}
}
