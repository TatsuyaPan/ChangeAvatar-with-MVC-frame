using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseArea : MonoBehaviour
{

    private AssistantToggle toggleSample;
    private ToggleGroup tg;
    private List<AssistantToggle> toggles;

    private void Awake()
    {
        toggleSample = Resources.Load<AssistantToggle>("AssistantToggle");
        tg = GetComponent<ToggleGroup>();
        toggles = new List<AssistantToggle>();
    }

    public void InitToggles(Dictionary<string, Sprite> datas, string activeKey, System.Action<string> onToggleActive)
    {
        int index = 0;
        foreach (var data in datas)
        {
            if (index >= toggles.Count)
            {
                AssistantToggle toggle = Instantiate(toggleSample, transform);
                toggles.Add(toggle);
            }
            toggles[index].gameObject.SetActive(true);
            toggles[index].InitToggle(tg, data.Value, data.Key == activeKey, (x) => { if (x) onToggleActive(data.Key); });
            index++;
        }
        for (; index < toggles.Count; index++)
        {
            toggles[index].gameObject.SetActive(false);
        }
    }
}
