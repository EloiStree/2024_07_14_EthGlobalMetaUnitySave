using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.Events;

public class WsSignedMsgToPublicAddressMono : MonoBehaviour
{

    public VerifiedUserSignedClaimMono m_claim;
    public string m_webSocketFormatToAskValidation = "{0}|{1}";
    public UnityEvent<string> m_onPushRequest;
    public ConnectToServerTunnelingRsaMono m_tunnelingRsa;

    public string m_lastPushed;
    public string m_lastReceived;
    public string m_lastValideAddress;

    public UnityEvent m_onUnvalidateClaim;
    public UnityEvent<string> m_onValidatePublicAddress;

    public void PushInReceivedFromServer(string received)
    {
        m_lastReceived = received;
        if (received.ToLower().Trim().StartsWith("fail|"))
        {
            m_onUnvalidateClaim.Invoke();
        }
        if (received.ToLower().Trim().StartsWith("address|"))
        {
            string adr = received.Substring("address|".Length);
            m_lastValideAddress = adr;
            m_onValidatePublicAddress.Invoke(adr);
        }
    }


    public void FetchPublicAddress()
    {

        string address = m_claim.m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_claimingEthAddress.m_ethAddress;
        string message = m_claim.m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_messageAskToSigned.m_message;
        string signedMessage =
            m_claim.m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_signedMessage.m_signedMessage;

        if (message.Contains("|"))
        {
            message = message.Substring(message.IndexOf("|") + 1);
            m_lastPushed = message;
            m_onPushRequest.Invoke(message);
        }
        else { 
            string toPush = string.Format(m_webSocketFormatToAskValidation, message, signedMessage);
            m_lastPushed = toPush;
                m_onPushRequest.Invoke(toPush);
        }
    }


    [System.Serializable]
    public struct STRUCT_VerificationFailed {

        public string m_sent; 
    }
    [System.Serializable]
    public struct STRUCT_VerificationSuccess {
        public string m_address;
    }
}
