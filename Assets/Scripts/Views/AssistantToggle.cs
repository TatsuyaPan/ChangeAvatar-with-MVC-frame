using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AssistantToggle : MonoBehaviour
{

    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Image map;

    public void InitToggle(ToggleGroup tg, Sprite sprite, bool state, UnityAction<bool> onToggleActive)
    {
        toggle.onValueChanged.RemoveAllListeners();
        toggle.group = tg;
        toggle.isOn = state;
        map.sprite = sprite;
        toggle.onValueChanged.AddListener(onToggleActive);
    }

}
