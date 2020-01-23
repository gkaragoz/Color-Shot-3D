﻿using System;
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

    public Action<int> OnScoreAdded;

    [Header("Initializations")]
    [SerializeField]
    private PlayerController _playerController = null;
    [SerializeField]
    private TargetGenerator _targetGenerator = null;

    public Target[] Target {
        get;
        private set;
    }

    public int RemainingTargetsCount { get; private set; }

    private void Start() {
        ObjectPooler.instance.InitializePool("Projectile");
        ObjectPooler.instance.InitializePool("Target");

        GameObject[] targetBlueObjects = ObjectPooler.instance.GetGameObjectsOnPool("Target");
        Target = new Target[targetBlueObjects.Length];
        for (int ii = 0; ii < Target.Length; ii++) {
            Target[ii] = targetBlueObjects[ii].GetComponent<Target>();
        }

        RemainingTargetsCount = targetBlueObjects.Length;
        _targetGenerator.GenerateTargets();

        _playerController.SetFireCounter(RemainingTargetsCount);
    }

    public void AddScore(int value) {
        _playerController.AddScore(value);

        OnScoreAdded?.Invoke(_playerController.Score);
    }

}
