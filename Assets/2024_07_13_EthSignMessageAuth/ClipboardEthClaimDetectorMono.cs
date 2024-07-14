using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClipboardEthClaimDetectorMono : MonoBehaviour
{
    public string clipboardText;

    public string m_lastClipboardText = "";
    public UnityEvent<string> m_onClipboardContainsSignedMessage;
    public UnityEvent<STRUCT_EthSignMessageAuth> m_onClipboardContainsClaim;

    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            CheckForClipboardClaimContent();
        }
    }

    public STRUCT_EthSignMessageAuth m_lastFound;

    [ContextMenu("Check for clipboard content")]
    public void CheckForClipboardClaimContent()
    {
        string text = GUIUtility.systemCopyBuffer;
        if( text == m_lastClipboardText )
        {return;}

        m_lastClipboardText = text;
        if (text.Contains("|") && text.Contains("0x")) { 
            string [] parts = text.Split('|');
            if(parts.Length==3)
            {
                string message = parts[0];
                string address = parts[1];
                string signature = parts[2];
                STRUCT_EthSignMessageAuth auth = new STRUCT_EthSignMessageAuth();
                auth.m_claimingEthAddress.m_ethAddress = address;
                auth.m_messageAskToSigned.m_message = message;
                auth.m_signedMessage.m_signedMessage = signature;
                m_lastFound = auth;
                m_onClipboardContainsClaim.Invoke(auth);
            }
        }
        
    }
}
