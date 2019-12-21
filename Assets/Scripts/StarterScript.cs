using UnityEngine;
using System.Collections;

public class StarterScript : MonoBehaviour
{
    public Animator anim;
    public GameObject introPage, mainPanel;

    private void Start()
    {
        anim.Play("FadeInAndOut");
        StartCoroutine(LoadMainPage());
    }

    IEnumerator LoadMainPage()
    {
        yield return new WaitForSeconds(4.5f);
        introPage.SetActive(false);
        mainPanel.SetActive(true);
    }
}