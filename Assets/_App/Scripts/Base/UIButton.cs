using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class UIButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI label;

    private System.Action OnClick;

    // Start is called before the first frame update
    void Awake()
    {
        button.onClick.AddListener(Click);
    }

    public void Setup(string label, System.Action onClick)
    {
        this.label.text = label;
        OnClick = onClick;
    }

    private void Click()
    {
        OnClick?.Invoke();
    }
}
