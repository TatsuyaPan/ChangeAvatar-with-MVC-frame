using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    private ToggleGroup tg;
    private Toggle[] toggles;

    private void Awake()
    {
        tg = GetComponent<ToggleGroup>();
    }

    public void InitToggles(Dictionary<string, string> keys, System.Action<string> onToggleActive)
    {
        if (keys.Count == 0 || onToggleActive == null) return;

        Toggle toggle = Resources.Load<Toggle>("ChooseToggle");
        toggles = new Toggle[keys.Count];
        int i = 0;
        foreach (var key in keys)
        {
            toggles[i] = Instantiate(toggle, transform);
            toggles[i].isOn = false;
            toggles[i].onValueChanged.AddListener((x) => { if (x) onToggleActive(key.Value); });
            toggles[i].group = tg;
            Text text = toggles[i].GetComponentInChildren<Text>();
            text.text = key.Key;
            i++;
        }
        toggles[0].isOn = true;
    }

    public void ReleaseToggles()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].onValueChanged.RemoveAllListeners();
        }
    }
}
