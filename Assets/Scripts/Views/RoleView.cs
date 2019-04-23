using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleView
{
    public RoleView(Transform parent)
    {
        LoadModels(parent);
        UpdateView();
    }


    private string curSex = RoleDefine.female;
    private string curPartName = RoleDefine.hair;
    private string curAssistantName = "1";


    private Character male;
    private Character female;

    private void LoadModels(Transform parent)
    {
        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("FemaleModel"), parent);
        female = go.AddComponent<Character>();

        go = GameObject.Instantiate(Resources.Load<GameObject>("MaleModel"), parent);
        male = go.AddComponent<Character>();

        female.InitCharacterParts();
        male.InitCharacterParts();
    }

    public void SetCharacter(string partName, string assistantName)
    {
        curPartName = partName;
        curAssistantName = assistantName;
    }

    public void SetSex(string sex)
    {
        curSex = sex;
    }

    public void UpdateView()
    {
        Character choosed;
        if (curSex == "male")
        {
            choosed = male;
            male.gameObject.SetActive(true);
            female.gameObject.SetActive(false);
        }
        else
        {
            choosed = female;
            male.gameObject.SetActive(false);
            female.gameObject.SetActive(true);
        }

        choosed.SetCharacter(curPartName, curAssistantName);
    }

}
