using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeUI : MonoBehaviour
{

    [SerializeField] private Text title;
    [SerializeField] private Image icon;

    private Action onApply;

    public void Setup(string title, Sprite icon, Action onApply)
    {
        this.title.text = title;
        this.icon.sprite = icon;
        this.onApply = onApply;
    }

    public void Apply()
    {
        onApply?.Invoke();
    }
}
