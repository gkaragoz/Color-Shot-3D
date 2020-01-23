using UnityEngine;

public class TargetGenerator : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private Transform _targetSpawnPoint = null;
    [SerializeField]
    private Color[] _colors = null;

    [Header("Debug")]
    [SerializeField]
    [Utils.ReadOnly]
    private Target[] _target;

    public void GenerateTargets() {
        _target = GameManager.instance.Target;

        Vector3 positionOffset = new Vector3(_targetSpawnPoint.position.x, _target[0].transform.localScale.y * 0.5f, _targetSpawnPoint.position.z);

        for (int ii = 0; ii < _target.Length; ii++) {
            _target[ii].transform.position = positionOffset;
            _target[ii].gameObject.SetActive(true);
            _target[ii].SetIndex(ii);

            if (ii % 2 == 0) {
                _target[ii].SwitchColor(GetColorFromEnum(Enums.Colors.Red));
            }
            else {
                _target[ii].SwitchColor(GetColorFromEnum(Enums.Colors.Blue));
            }

            _target[ii].OnProjectileTriggered += OnProjectileTriggered;

            positionOffset += new Vector3(0f, _target[ii].transform.localScale.y, 0f);
        }
    }

    private void OnProjectileTriggered(int index) {
        for (int ii = index + 1; ii < _target.Length; ii++) {
            if (_target[ii] != null) {
                _target[ii].GoDown();
            }
        }
    }

    private Color GetColorFromEnum(Enums.Colors colorEnum) {
        return _colors[(int)colorEnum];
    }

}
