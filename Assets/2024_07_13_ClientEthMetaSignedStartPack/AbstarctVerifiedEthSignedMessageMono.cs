using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstarctVerifiedEthSignedMessageMono : MonoBehaviour
{
    public void Verifiy(string claimingEthAddress, string messageAskToSigned, string signedMessage)
    {
        string addressInSignedMessage = GetAddressIn(messageAskToSigned, signedMessage);
    }

    private string GetAddressIn(string messageAskToSigned, string signedMessage)
    {
        throw new NotImplementedException();
    }
}
