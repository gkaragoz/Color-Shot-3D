using System;
using UnityEngine;

public class Target : MonoBehaviour, IPooledObject {

    public Action<int> OnProjectileTriggered;
    
    public Color color = Color.blue;
    public int score = 10;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private int _index = -1;

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

    public void SetIndex(int index) {
        this._index = index;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Projectile") {
            this.gameObject.SetActive(false);

            GameManager.instance.AddScore(score);

            OnProjectileTriggered.Invoke(_index);
        }
    }

}
