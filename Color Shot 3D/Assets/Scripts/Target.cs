using System;
using UnityEngine;

public class Target : MonoBehaviour, IPooledObject {

    public Action<int> OnProjectileTriggered;
    
    public Color color = Color.blue;
    public int index = -1;
    public int score = 10;

    public void OnObjectReused() {
        this.gameObject.SetActive(true);
    }

    public void GoDown() {
        transform.Translate(new Vector3(0f, -transform.localScale.y, 0f));
    }

    public void SwitchColor(Color color) {
        this.color = color;

        var block = new MaterialPropertyBlock();
        block.SetColor("_BaseColor", color);

        GetComponent<Renderer>().SetPropertyBlock(block);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Projectile") {
            this.gameObject.SetActive(false);

            GameManager.instance.AddScore(score);

            OnProjectileTriggered.Invoke(index);
        }
    }

}
