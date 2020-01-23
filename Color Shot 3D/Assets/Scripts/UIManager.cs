using System;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private UIScore _UIScore = null;

    private void Start() {
        _UIScore.UpdateScore(0);

        GameManager.instance.OnScoreAdded += OnScoreAdded;
    }

    private void OnScoreAdded(int value) {
        _UIScore.UpdateScore(value);
    }
}
