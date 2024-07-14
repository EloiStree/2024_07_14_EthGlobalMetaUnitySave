using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ref_GeneratedBlocky {
    public Texture2D m_blockyAsTexture;
}

[System.Serializable]
public struct STRUCT_EthAddress 
{
    public string m_ethAddress;
}

[System.Serializable]
public struct STRUCT_MessageToSign 
{
    public string m_message;
}

[System.Serializable]
public struct STRUCT_SignedMessage 
{
    public string m_signedMessage;
}

[System.Serializable]
public struct STRUCT_EthSignMessageAuth 
{
    public STRUCT_EthAddress m_claimingEthAddress;
    public STRUCT_MessageToSign m_messageAskToSigned;
    public STRUCT_SignedMessage m_signedMessage;
}
