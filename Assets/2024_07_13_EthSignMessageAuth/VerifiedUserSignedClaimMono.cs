using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class VerifiedUserSignedClaimMono : MonoBehaviour
{

    public string m_guidToSignGiven;
    public VerifiedUserSignedClaim m_verifiedUserSignedClaim;
    public UnityEvent<string> m_onNewGuid;
    public UnityEvent<string> m_onMessageToSignChanged;
    public UnityEvent<string> m_onFoundAddressChanged;
    public UnityEvent<bool> m_onAddressFound;

    public void Awake()
    {
        GenerateNewGuid();
    }

    public void GenerateNewGuid() {

        m_guidToSignGiven = System.Guid.NewGuid().ToString();
        SetMessageToSign(m_guidToSignGiven);
    }

    [ContextMenu("Refresh with current value")]
    public void RefreshEventWithCurrentValue() { 
    
        SetAddressClaimedToBe(m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_claimingEthAddress.m_ethAddress);
        SetMessageToSign(m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_messageAskToSigned.m_message);
        SetReturnByUserSignedMessage(m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_signedMessage.m_signedMessage);

    }

    public void SetWithTriPartyPastableText(string text)
    {
        string[] parts = text.Split('|');
        if (parts.Length == 3)
        {
            if (m_guidToSignGiven.Trim() != parts[0].Trim()) ;
            SetWithTriPartyPastableText(parts[0], parts[1], parts[2]);
        }
    }
    public void SetWithTriPartyPastableText(STRUCT_EthSignMessageAuth auth)
    {
        SetWithTriPartyPastableText(auth.m_messageAskToSigned.m_message, auth.m_claimingEthAddress.m_ethAddress, auth.m_signedMessage.m_signedMessage);
    }
    public void SetWithTriPartyPastableText(string messageToSign, string ethPublicAddress, string signedMessage)
    {
        SetMessageToSign(messageToSign);
        SetAddressClaimedToBe(ethPublicAddress);
        SetReturnByUserSignedMessage(signedMessage);
    }

    public void SetMessageToSign(string messageToSigned)
    {
        m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_messageAskToSigned.m_message = messageToSigned;
        m_onNewGuid.Invoke(messageToSigned);
    }
    public void SetReturnByUserSignedMessage(string signedMessage)
    {
        m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_signedMessage.m_signedMessage = signedMessage;
        m_onMessageToSignChanged.Invoke(signedMessage);
    }
    public void SetAddressClaimedToBe(string address)
    {
        m_verifiedUserSignedClaim.m_ethSignMessageAuth.m_claimingEthAddress.m_ethAddress = address;
        m_onFoundAddressChanged.Invoke(address);
        m_onAddressFound.Invoke(IsValideEthereumAddress(address));
      
    }

    private bool IsValideEthereumAddress(string address)
    {
            // Step 1: Check if the address starts with "0x"
            if (!address.StartsWith("0x")) return false;
            // Step 2: Check the length of the address
            if (address.Length != 42) return false;
            // Step 3: Check if the address contains only valid hexadecimal characters
            string hexPart = address.Substring(2); // Remove "0x" prefix
            if (!Regex.IsMatch(hexPart, @"^[0-9a-fA-F]+$")) return false;
            return true;//IsChecksumValid(address);
    }
}
[System.Serializable]
public class VerifiedUserSignedClaim
{
    public STRUCT_EthSignMessageAuth m_ethSignMessageAuth;
}