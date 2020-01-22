using UnityEngine;

public class TargetGenerator : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Transform _targetSpawnPoint;

    private Target[] _targetBlues;
    private Target[] _targetReds;
    private Target[] _targetGreens;

    public void GenerateTargets() {
        _targetBlues = GameManager.instance.TargetBlues;
        _targetReds = GameManager.instance.TargetReds;
        _targetGreens = GameManager.instance.TargetGreens;

        Vector3 positionOffset = new Vector3(_targetSpawnPoint.position.x, _targetBlues[0].transform.localScale.y * 0.5f, _targetSpawnPoint.position.z);

        for (int ii = 0; ii < _targetBlues.Length; ii++) {
            _targetBlues[ii].transform.position = positionOffset;
            _targetBlues[ii].gameObject.SetActive(true);
            _targetBlues[ii].index = ii;
            _targetBlues[ii].OnProjectileTriggered += OnProjectileTriggered;

            positionOffset += new Vector3(0f, _targetBlues[ii].transform.localScale.y, 0f);
        }
    }
    private void OnProjectileTriggered(int index) {
        for (int ii = index + 1; ii < _targetBlues.Length; ii++) {
            if (_targetBlues[ii] != null) {
                _targetBlues[ii].GoDown();
            }
        }
    }

}
