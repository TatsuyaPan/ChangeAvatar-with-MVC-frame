using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIView
{
    public System.Action<string> onSetPart;
    public System.Action<string> onSetChoose;
    public System.Action<string> onSetSex;
    private Dictionary<string, Dictionary<string, Sprite>>[] imageDatas;

    private ChooseArea chooseArea;
    private ChooseArea sexArea;
    private UIToggle uiToggle;
    public UIView(UIToggle uiToggle, ChooseArea chooseArea, ChooseArea sexArea, Dictionary<string, string> partKeys, Dictionary<string, Dictionary<string, Sprite>>[] imageDatas, Dictionary<string, Sprite> sexDatas)
    {
        this.imageDatas = imageDatas;
        this.uiToggle = uiToggle;
        this.chooseArea = chooseArea;
        this.sexArea = sexArea;

        sexArea.InitToggles(sexDatas, curSex, ActiveSex);
        uiToggle.InitToggles(partKeys, AcitvePart);


        foreach (var part in partKeys)
        {
            curPart = part.Value;
            chooseArea.InitToggles(imageDatas[0][part.Value], curAssitant, ActiveAssitant);
            break;
        }
    }

    private string curPart;
    public void SetPart(string part)
    {
        curPart = part;
    }

    private string curSex = RoleDefine.female;
    public void SetSex(string sex)
    {
        curSex = sex;
    }

    private string curAssitant = "1";
    public void SetAssitant(string assistant)
    {
        curAssitant = assistant;
    }


    private void ActiveAssitant(string assistant)
    {
        if (onSetChoose != null) onSetChoose(assistant);
    }

    private void AcitvePart(string part)
    {
        if (onSetPart != null) onSetPart(part);
    }

    private void ActiveSex(string sex)
    {
        if (onSetSex != null) onSetSex(sex);
    }

    public void UpdateView()
    {
        Dictionary<string, Sprite> datas;
        if (curSex == RoleDefine.female)
        {
            datas = imageDatas[0][curPart];
        }
        else
        {
            datas = imageDatas[1][curPart];
        }
        chooseArea.InitToggles(datas, curAssitant, ActiveAssitant);
    }
}
