using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RoleDefine
{
    public const string female = "female";
    public const string male = "male";

    public const string hair = "hair";
    public const string eyes = "eyes";
    public const string top = "top";
    public const string pants = "pants";
    public const string shoes = "shoes";
}


public class RoleModel
{
    public RoleModel()
    {
        this.male = new RoleData(RoleDefine.male);
        this.female = new RoleData(RoleDefine.female);
        this.curData = female;
    }

    private RoleData male;
    private RoleData female;
    private RoleData curData;
    public RoleData CurData { get { return curData; } }

    public System.Action<string, string> onModeDataChange;
    public System.Action<string> onSexChange;

    public void ModelDressChange(string bodyPart, string assistantName)
    {
        curData.SetData(bodyPart, assistantName);

        if (onModeDataChange != null) onModeDataChange(bodyPart, assistantName);
    }

    public void ChangeSex(string sex)
    {
        if (sex == "male")
            curData = male;
        else
            curData = female;

        if (onSexChange != null) onSexChange(sex);
    }

}

public class RoleData : IEnumerable
{
    public RoleData(string sex)
    {
        this.sex = sex;
        hair = "1";
        eyes = "1";
        top = "1";
        pants = "1";
        shoes = "1";
    }
    public string sex { get; private set; }
    private string hair;
    private string eyes;
    private string top;
    private string pants;
    private string shoes;

    public void SetData(string bodyPart, string assistantName)
    {
        switch (bodyPart)
        {
            case RoleDefine.hair: hair = assistantName; break;
            case RoleDefine.eyes: eyes = assistantName; break;
            case RoleDefine.top: top = assistantName; break;
            case RoleDefine.pants: pants = assistantName; break;
            case RoleDefine.shoes: shoes = assistantName; break;
        }
    }

    public string GetData(string part)
    {
        switch (part)
        {
            case RoleDefine.hair: return hair;
            case RoleDefine.eyes: return eyes;
            case RoleDefine.top: return top;
            case RoleDefine.pants: return pants;
            case RoleDefine.shoes: return shoes;
        }
        return "";
    }

    public IEnumerator GetEnumerator()
    {
        Dictionary<string, string> dir = new Dictionary<string, string>();
        dir.Add(RoleDefine.hair, hair);
        dir.Add(RoleDefine.eyes, eyes);
        dir.Add(RoleDefine.top, top);
        dir.Add(RoleDefine.pants, pants);
        dir.Add(RoleDefine.shoes, shoes);
        return dir.GetEnumerator();
    }

}

