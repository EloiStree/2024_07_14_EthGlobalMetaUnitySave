using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthOpenUrlToSignMessageMono : MonoBehaviour
{

    public string m_urlToCall = "https://eloistree.github.io/SignMetaMaskTextHere/index.html?q=";
    public string m_messageToSign;
    public void SetMessageToSign(string message)
    {
        m_messageToSign = message;
    }
    public void OpenPage()
    {
        Application.OpenURL(m_urlToCall + m_messageToSign);
    }
}
//public class EthOpenUrlMono : MonoBehaviour
//{

//    public string m_urlToCall = "https://www.eloistree.github.io/signMetaMaskTextHere/index.html?q=";

//    public void OpenPage()
//    {
//        Application.OpenURL(m_urlToCall);
//    }

//    public void OpenSpectificPage(string url)
//    {

//        Application.OpenURL(url);
//    }

//    public void OpenSigningPageWithKeywordToSign(string keywordToSign)
//    {

//        Application.OpenURL(m_urlToCall + keywordToSign);
//    }


//}
