using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button unMutedButton;
    public Button mutedButton;
    public GameObject infoPanel;
    private void Update()
    {
        if (UIManager.isSoundsOpen)
        {
            unMutedButton.gameObject.SetActive(true);
            mutedButton.gameObject.SetActive(false);
        }
        else
        {
            unMutedButton.gameObject.SetActive(false);
            mutedButton.gameObject.SetActive(true);
        }
    }

    public void UnMutedButton()
    {
        unMutedButton.gameObject.SetActive(false);
        mutedButton.gameObject.SetActive(true);
        UIManager.isSoundsOpen = false;
    }

    public void MutedButton()
    {
        unMutedButton.gameObject.SetActive(true);
        mutedButton.gameObject.SetActive(false);
        UIManager.isSoundsOpen = true;
    }

    public void BackButton()
    {
        infoPanel.gameObject.SetActive(false);
    }

    public void InfoButton()
    {
        infoPanel.gameObject.SetActive(true);
    }
    
    //to Open Links
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/BasarEkinci");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/basar.ekincii/");
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://l24.im/N1E3ZGW");
    }
}
