using UnityEngine;

class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

	public Vector3 Direction { get; set; }
}
