using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemPopupUIParam : UIParam
{
    public string title = string.Empty;
    public string message = string.Empty;

    public SystemPopupUIParam(string title = "Alert", string message = "Message")
    {
        this.title = title;
        this.message = message;
    }
}

[WindowAttribute("TOP/SystemPopup.prefab")]
public class SystemPopup : UIPopup
{
    [SerializeField] TextMeshProUGUI alertText = null;
    [SerializeField] TextMeshProUGUI messageText = null;

    public override void Open(UIParam param)
    {
        if (param == null ||
            param is SystemPopupUIParam == false)
            return;

        base.Open(param);

        var _param = param as SystemPopupUIParam;

        alertText.text = _param.title;
        messageText.text = _param.message;
    }

}
