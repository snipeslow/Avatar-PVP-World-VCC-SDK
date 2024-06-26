﻿#if !SAPVP_VRCSDK3_AVATARS && !SAPVP_VRCSDK3_WORLDS && VRC_SDK_VRCSDK3
#if UDON
#define SAPVP_VRCSDK3_WORLDS
#else
#define SAPVP_VRCSDK3_AVATARS
#endif
#endif
using UnityEngine;
#if SAPVP_VRCSDK3_WORLDS
using VRC.SDKBase;
using VRC.Udon;
using UdonSharp;
using UnityEngine.UI;

public class SAPVP_ClassSet : UdonSharpBehaviour
{
    public SAPVP_Manager Manager;
    public string ClassSetName = "";
    public string ClassSet = "";
    public Text ClassSetNameText;
    public Image ClassSetImage;
    public int ID = -1;
    public override void Interact()
    {
        if (!Manager)
            return;
        if (!Networking.IsMaster && !Networking.IsInstanceOwner) return;
        if (!Networking.LocalPlayer.IsValid()) return;
        Networking.SetOwner(Networking.LocalPlayer, Manager.gameObject);
        Manager.ClassSet = ClassSet;
        Manager.ActiveClassSet = ID;
        Manager.FormDatabase();
        Manager.RequestSerialization();
    }

    public void UpdateUI()
    {
        if(!ClassSetNameText)
            return;
        ClassSetNameText.text = ClassSetName;
    }
}
#else
public class SAPVP_ClassSet : MonoBehaviour
{
}
#endif