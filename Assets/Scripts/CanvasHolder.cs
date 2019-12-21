using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHolder : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject helpWindow, assetViewer, optionViewer;    
    int cameraDef = 0;
    bool helpPressed = false, assetVisible = false;
    public Text pathtoShow;

    private void Start()
    {
        cameras[cameraDef].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnChangeCamera();
        }
    }

    public void OnChangeCamera()
    {
        cameras[cameraDef].gameObject.SetActive(false);
        cameraDef++;
        if (cameraDef > 3)
        {
            cameraDef = 0;
        }
        cameras[cameraDef].gameObject.SetActive(true);
    }

    public void OnSnapshotClicked()
    {
        helpWindow.SetActive(false);
        assetViewer.SetActive(false);
        optionViewer.SetActive(false);
        try
        {
            string date = System.DateTime.Now.ToString();
            date = date.Replace("/", "-");
            date = date.Replace(" ", "_");
            date = date.Replace(":", "-");
            string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "HomeDecor_Screenshot" + date + ".png");
            ScreenCapture.CaptureScreenshot(path);
            pathtoShow.text = path;
            StartCoroutine(Appear());
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        StartCoroutine(Click());
    }

    IEnumerator Appear()
    {
        Color color = pathtoShow.color;
        color.a = 255;
        pathtoShow.color = color;
        yield return new WaitForSeconds(2f);
        color.a = 0;
        pathtoShow.color = color;
    }

    IEnumerator Click()
    {
        yield return new WaitForEndOfFrame();
        helpWindow.SetActive(false);
        assetViewer.SetActive(false);
        optionViewer.SetActive(true);
    }

    public void OnHelpClicked()
    {
        if(!assetVisible)
        if (!helpPressed)
        {
            helpWindow.SetActive(true);
            helpPressed = true;
        }
        else
        {
            helpWindow.SetActive(false);
            helpPressed = false;
        }
    }

    public void OnAssetViewClicked()
    {
        if(!helpPressed)
        if (!assetVisible)
        {
            assetViewer.SetActive(true);
            assetVisible = true;
        }
        else
        {
            assetViewer.SetActive(false);
            assetVisible = false;
        }
    }

    public void OnExitPressed()
    {
        pathtoShow.text = "Exiting";
        Application.Quit();
    }
}