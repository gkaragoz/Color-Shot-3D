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
    [SerializeField]
    private TargetGenerator _targetGenerator = null;

    public Target[] TargetBlues {
        get;
        private set;
    }
    public Target[] TargetReds {
        get;
        private set;
    }
    public Target[] TargetGreens {
        get;
        private set;
    }

    private void Start() {
        ObjectPooler.instance.InitializePool("Projectile");
        ObjectPooler.instance.InitializePool("TargetBlue");
        ObjectPooler.instance.InitializePool("TargetRed");
        ObjectPooler.instance.InitializePool("TargetGreen");

        GameObject[] targetBlueObjects = ObjectPooler.instance.GetGameObjectsOnPool("TargetBlue");
        TargetBlues = new Target[targetBlueObjects.Length];
        for (int ii = 0; ii < TargetBlues.Length; ii++) {
            TargetBlues[ii] = targetBlueObjects[ii].GetComponent<Target>();
        }

        GameObject[] targetRedObjects = ObjectPooler.instance.GetGameObjectsOnPool("TargetRed");
        TargetReds = new Target[targetRedObjects.Length];
        for (int ii = 0; ii < TargetReds.Length; ii++) {
            TargetReds[ii] = targetRedObjects[ii].GetComponent<Target>();
        }

        GameObject[] targetGreenObjects = ObjectPooler.instance.GetGameObjectsOnPool("TargetGreen");
        TargetGreens = new Target[targetGreenObjects.Length];
        for (int ii = 0; ii < TargetGreens.Length; ii++) {
            TargetGreens[ii] = targetGreenObjects[ii].GetComponent<Target>();
        }

        _targetGenerator.GenerateTargets();
    }

}
