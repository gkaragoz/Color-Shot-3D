using System;
using UnityEngine;

public class Target : MonoBehaviour, IPooledObject {

    public enum Color {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    public Action<int> OnProjectileTriggered;
    
    public Color color = Color.Blue;
    public int index = -1;

    public void OnObjectReused() {
        this.gameObject.SetActive(true);
    }

    public void GoDown() {
        transform.Translate(new Vector3(0f, -transform.localScale.y, 0f));
    }

    public void SwitchColor(Color color) {
        this.color = color;

        var block = new MaterialPropertyBlock();

        switch (color) {
            case Color.Red:
                block.SetColor("_BaseColor", GameManager.instance.GetColor((int)color));
                break;
            case Color.Green:
                block.SetColor("_BaseColor", GameManager.instance.GetColor((int)color));
                break;
            case Color.Blue:
                block.SetColor("_BaseColor", GameManager.instance.GetColor((int)color));
                break;
        }

        GetComponent<Renderer>().SetPropertyBlock(block);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Projectile") {
            this.gameObject.SetActive(false);

            GameManager.instance.RemainingTargetsCount--;

            OnProjectileTriggered.Invoke(index);
        }
    }

}
