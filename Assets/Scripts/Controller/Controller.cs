using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{

    private RoleModel roleModel;
    private RoleView roleview;
    private UIView UIview;

    public Controller(RoleModel roleModel, RoleView roleview, UIView UIview)
    {
        this.roleModel = roleModel;
        this.roleview = roleview;
        this.UIview = UIview;
        curPart = RoleDefine.hair;

        //设定监听内容
        this.roleModel.onModeDataChange = OnRoleDataChange;
        this.roleModel.onSexChange = OnRoleSexChange;

        this.UIview.onSetSex = OnUIViewSetSex;
        this.UIview.onSetPart = OnUIViewSetPart;
        this.UIview.onSetChoose = OnUIViewSetChoose;
    }


    #region 视图（View）数据监听
    private string curPart;

    //监听UI点击part操作
    private void OnUIViewSetPart(string part)
    {
        //由于没有进行具体服装选择，所以此时缓存部位参数
        curPart = part;
        //UI切换部位选择，仅有UI服装部位视图发生改变和更新
        UIview.SetPart(part);
        //从模型中获取数据，获取当前模型对应部位的数据
        UIview.SetAssitant(roleModel.CurData.GetData(part));
        //刷新UI视图
        UIview.UpdateView();
    }

    //监听UI点击assistant操作
    private void OnUIViewSetChoose(string assistant)
    {
        //UI切换具体服装选择时，对模型数据进行修改
        roleModel.ModelDressChange(curPart, assistant);
    }

    //监听UI点击sex操作
    private void OnUIViewSetSex(string sex)
    {
        //UI切换性别选项时，对模型数据进行修改
        roleModel.ChangeSex(sex);
    }
    #endregion

    #region 模型（Model）数据监听

    //监听模型数据改动
    private void OnRoleDataChange(string part, string assistant)
    {
        //模型数据中Part和assistant发生修改时，需要对UI视图中part和assitant数据进行修改
        UIview.SetPart(part);
        UIview.SetAssitant(assistant);

        //与UI视图类似，要对RoleView数据也进行修改
        roleview.SetCharacter(part, assistant);

        //数据都修改完成后进行更新
        roleview.UpdateView();
        UIview.UpdateView();
    }

    //监听模型数据改动
    private void OnRoleSexChange(string sex)
    {
        //模型数据中sex发生修改，需要对UI视图中sex进行修改
        UIview.SetSex(sex);
        //Sex发生变化后，part还保持原来显示，assistant保持与数据同步
        UIview.SetAssitant(roleModel.CurData.GetData(curPart));
        //同样地对角色视图进行更新 
        roleview.SetSex(sex);

        //数据都修改完成后进行更新
        roleview.UpdateView();
        UIview.UpdateView();
    }
    #endregion

}
