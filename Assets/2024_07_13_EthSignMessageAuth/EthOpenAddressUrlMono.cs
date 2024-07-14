using UnityEngine;

public class EthOpenAddressUrlMono : MonoBehaviour
{

    public string m_urlToCall = "https://etherscan.io/address/";
    public string m_address;
    public void SetAddressToOpen(string address)
    {
        m_address = address;
    }
    public void OpenPage()
    {
        Application.OpenURL(m_urlToCall + m_address);
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
