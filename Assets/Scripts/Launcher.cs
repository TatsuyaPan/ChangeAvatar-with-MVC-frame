using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Controller controller;

    public Transform roleParent;
    public ChooseArea chooseArea;
    public ChooseArea sexArea;
    public UIToggle uiToggle;

    void Start()
    {
        RoleView rv = new RoleView(roleParent);
        RoleModel rm = new RoleModel();

        UIView UIview = new UIView(uiToggle, chooseArea, sexArea, LoadPartKeys(), LoadSprite(), LoadSexSprites());
        controller = new Controller(rm, rv, UIview);
    }

    //载入UIView需要的数据信息，实际使用时可以通过数据库、XML、json等方式载入
    private Dictionary<string, Dictionary<string, Sprite>>[] LoadSprite()
    {
        //载入女性角色UI图
        Dictionary<string, Dictionary<string, Sprite>> female = new Dictionary<string, Dictionary<string, Sprite>>();
        female.Add("hair", new Dictionary<string, Sprite>());
        female["hair"].Add("1", Resources.Load<Sprite>("UISprites/girl/hair/hair_brown"));
        female["hair"].Add("2", Resources.Load<Sprite>("UISprites/girl/hair/hair_cyan"));
        female["hair"].Add("3", Resources.Load<Sprite>("UISprites/girl/hair/hair_dark"));
        female["hair"].Add("4", Resources.Load<Sprite>("UISprites/girl/hair/hair_pink"));
        female["hair"].Add("5", Resources.Load<Sprite>("UISprites/girl/hair/hair_red"));
        female["hair"].Add("6", Resources.Load<Sprite>("UISprites/girl/hair/hair_yellow"));

        female.Add("eyes", new Dictionary<string, Sprite>());
        female["eyes"].Add("1", Resources.Load<Sprite>("UISprites/girl/eyes/eyes_blue"));
        female["eyes"].Add("2", Resources.Load<Sprite>("UISprites/girl/eyes/eyes_brown"));
        female["eyes"].Add("3", Resources.Load<Sprite>("UISprites/girl/eyes/eyes_green"));


        female.Add("top", new Dictionary<string, Sprite>());
        female["top"].Add("1", Resources.Load<Sprite>("UISprites/girl/top/top_blue"));
        female["top"].Add("2", Resources.Load<Sprite>("UISprites/girl/top/top_green"));
        female["top"].Add("3", Resources.Load<Sprite>("UISprites/girl/top/top_green2"));
        female["top"].Add("4", Resources.Load<Sprite>("UISprites/girl/top/top_orange"));
        female["top"].Add("5", Resources.Load<Sprite>("UISprites/girl/top/top_pink"));
        female["top"].Add("6", Resources.Load<Sprite>("UISprites/girl/top/top_purple"));

        female.Add("pants", new Dictionary<string, Sprite>());
        female["pants"].Add("1", Resources.Load<Sprite>("UISprites/girl/pants/pants_black"));
        female["pants"].Add("2", Resources.Load<Sprite>("UISprites/girl/pants/pants_blue"));
        female["pants"].Add("3", Resources.Load<Sprite>("UISprites/girl/pants/pants_blue1"));
        female["pants"].Add("4", Resources.Load<Sprite>("UISprites/girl/pants/pants_dark"));
        female["pants"].Add("5", Resources.Load<Sprite>("UISprites/girl/pants/pants_green"));
        female["pants"].Add("6", Resources.Load<Sprite>("UISprites/girl/pants/pants_orange"));


        female.Add("shoes", new Dictionary<string, Sprite>());
        female["shoes"].Add("1", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_blue"));
        female["shoes"].Add("2", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_blue1"));
        female["shoes"].Add("3", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_green"));
        female["shoes"].Add("4", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_red"));
        female["shoes"].Add("5", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_yellow"));
        female["shoes"].Add("6", Resources.Load<Sprite>("UISprites/girl/shoes/shoes_yellow1"));

        //载入男性角色UI图
        Dictionary<string, Dictionary<string, Sprite>> male = new Dictionary<string, Dictionary<string, Sprite>>();
        male.Add("hair", new Dictionary<string, Sprite>());
        male["hair"].Add("1", Resources.Load<Sprite>("UISprites/boy/hair/hair_blond"));
        male["hair"].Add("2", Resources.Load<Sprite>("UISprites/boy/hair/hair_blond1"));
        male["hair"].Add("3", Resources.Load<Sprite>("UISprites/boy/hair/hair_brown"));
        male["hair"].Add("4", Resources.Load<Sprite>("UISprites/boy/hair/hair_brown1"));
        male["hair"].Add("5", Resources.Load<Sprite>("UISprites/boy/hair/hair_orange"));
        male["hair"].Add("6", Resources.Load<Sprite>("UISprites/boy/hair/hair_orange1"));

        male.Add("eyes", new Dictionary<string, Sprite>());
        male["eyes"].Add("1", Resources.Load<Sprite>("UISprites/boy/eyes/eyes_blue"));
        male["eyes"].Add("2", Resources.Load<Sprite>("UISprites/boy/eyes/eyes_brown"));
        male["eyes"].Add("3", Resources.Load<Sprite>("UISprites/boy/eyes/eyes_green"));

        male.Add("top", new Dictionary<string, Sprite>());
        male["top"].Add("1", Resources.Load<Sprite>("UISprites/boy/top/top_blue"));
        male["top"].Add("2", Resources.Load<Sprite>("UISprites/boy/top/top_gray"));
        male["top"].Add("3", Resources.Load<Sprite>("UISprites/boy/top/top_green"));
        male["top"].Add("4", Resources.Load<Sprite>("UISprites/boy/top/top_orange"));
        male["top"].Add("5", Resources.Load<Sprite>("UISprites/boy/top/top_pink"));
        male["top"].Add("6", Resources.Load<Sprite>("UISprites/boy/top/top_yellow"));

        male.Add("pants", new Dictionary<string, Sprite>());
        male["pants"].Add("1", Resources.Load<Sprite>("UISprites/boy/pants/pants_blue"));
        male["pants"].Add("2", Resources.Load<Sprite>("UISprites/boy/pants/pants_blue1"));
        male["pants"].Add("3", Resources.Load<Sprite>("UISprites/boy/pants/pants_dark"));
        male["pants"].Add("4", Resources.Load<Sprite>("UISprites/boy/pants/pants_green"));
        male["pants"].Add("5", Resources.Load<Sprite>("UISprites/boy/pants/pants_lillac"));
        male["pants"].Add("6", Resources.Load<Sprite>("UISprites/boy/pants/pants_purple"));


        male.Add("shoes", new Dictionary<string, Sprite>());
        male["shoes"].Add("1", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_black"));
        male["shoes"].Add("2", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_brown"));
        male["shoes"].Add("3", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_dark"));
        male["shoes"].Add("4", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_green"));
        male["shoes"].Add("5", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_red1"));
        male["shoes"].Add("6", Resources.Load<Sprite>("UISprites/boy/shoes/shoes_red2"));

        return new Dictionary<string, Dictionary<string, Sprite>>[] { female, male };
    }

    private Dictionary<string, string> LoadPartKeys()
    {
        Dictionary<string, string> partKeys = new Dictionary<string, string>();
        partKeys.Add("头发", RoleDefine.hair);
        partKeys.Add("眼睛", RoleDefine.eyes);
        partKeys.Add("上衣", RoleDefine.top);
        partKeys.Add("裤子", RoleDefine.pants);
        partKeys.Add("鞋子", RoleDefine.shoes);
        return partKeys;
    }

    private Dictionary<string, Sprite> LoadSexSprites()
    {
        Dictionary<string, Sprite> res = new Dictionary<string, Sprite>();
        res.Add(RoleDefine.female, Resources.Load<Sprite>("UISprites/sexSelect/girl"));
        res.Add(RoleDefine.male, Resources.Load<Sprite>("UISprites/sexSelect/boy"));
        return res;
    }
}

