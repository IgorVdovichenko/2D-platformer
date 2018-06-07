using UnityEngine;

[CreateAssetMenu]
public class DirectShot : ShootingType
{
	public override void Shoot(Vector3 direction, Vector3 point, Quaternion rotation)
	{
		GameObject bullet = Instantiate(projectile, point, rotation);
		bullet.GetComponent<Projectile>().Direction = direction;
	}
}
