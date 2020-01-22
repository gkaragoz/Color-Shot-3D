using UnityEngine;

public class Projectile : MonoBehaviour, IPooledObject {

    [Header("Inializations")]
    [SerializeField]
    private float _movementSpeed = 1f;

    private void Update() {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }

    public void OnObjectReused() {
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "TargetBlue") {
            this.gameObject.SetActive(false);
        } else if (other.tag == "TargetRed") {
            this.gameObject.SetActive(false);
        } else if (other.tag == "TargetGreen") {
            this.gameObject.SetActive(false);
        } else {
            Debug.LogError("DEAD!");
        }
    }

}
