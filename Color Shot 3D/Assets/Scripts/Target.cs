using System;
using UnityEngine;

public class Target : MonoBehaviour, IPooledObject {

    public Action<int> OnProjectileTriggered;

    public int index = -1;

    public void OnObjectReused() {
        this.gameObject.SetActive(true);
    }

    public void GoDown() {
        transform.Translate(new Vector3(0f, -transform.localScale.y, 0f));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Projectile") {
            this.gameObject.SetActive(false);

            OnProjectileTriggered.Invoke(index);
        }
    }

}
