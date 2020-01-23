using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour {

    [Header("Initializations")]
    [SerializeField]
    private TextMeshProUGUI _txtScore = null;

    public void UpdateScore(int value) {
        _txtScore.text = value.ToString();
    }

}
