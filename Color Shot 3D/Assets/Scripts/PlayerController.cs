using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Transform _firePivot = null;
    [SerializeField]
    private float _fireRate = 1.0f;

    private float _nextFire = 0f;

    public int Score { get; private set; }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire) {
            _nextFire = Time.time + _fireRate;

            Fire();
        }
    }

    public void Fire() {
        if (GameManager.instance.RemainingTargetsCount > 0) {
            ObjectPooler.instance.SpawnFromPool("Projectile", _firePivot.position, Quaternion.identity);
        }
    }

    public void AddScore(int value) {
        Score += value;
    }

}
