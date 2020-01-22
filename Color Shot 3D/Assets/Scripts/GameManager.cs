using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton

    public static GameManager instance;
    private void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    #endregion

    [Header("Initializations")]
    [SerializeField]
    private PlayerController _playerController = null;

    private void Start() {
        ObjectPooler.instance.InitializePool("Projectile");
    }

}
