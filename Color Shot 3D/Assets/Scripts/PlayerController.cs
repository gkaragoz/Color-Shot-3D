using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Transform _firePivot = null;
    [SerializeField]
    private float _fireRate = 1.0f;

    private float _nextFire = 0f;
    
    private void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire) {
            _nextFire = Time.time + _fireRate;

            Fire();
        }
    }

    public void Fire() {
        ObjectPooler.instance.SpawnFromPool("Projectile", _firePivot.position, Quaternion.identity);
    }

}
