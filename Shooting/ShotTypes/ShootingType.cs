using UnityEngine;

public abstract class ShootingType : ScriptableObject
{
	public GameObject projectile;
	public AudioClip sound;
	[SerializeField] int energyConsumption;

	public int EnergyConsumption
	{
		get { return energyConsumption; }
		set { energyConsumption = value; }
	}

	public abstract void Shoot(Vector3 direction, Vector3 point, Quaternion rotation);
}
