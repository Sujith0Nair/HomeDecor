using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AssetInitializer : MonoBehaviour
{
    public GameObject[] assets;
    public GameObject assetViewer, deleteButton;
    public Transform initialzeHere;
    public Text warning;
    GameObject currentSelectedObject, temp;
    Renderer rend, highlightSelected;
    Shader sil, standard;

    private void Start()
    {
        if (assets == null)
        {
            //throw error toast
        }
        temp = null;
        currentSelectedObject = null;
        rend = GetComponent<Renderer>();
        sil = Shader.Find("Custom/Silhouette");
        standard = Shader.Find("Standard");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.tag != "furniture" && highlightSelected != null)
                {
                    highlightSelected.material.shader = standard;
                }
                else if (hit.transform.tag == "furniture")
                {
                    if (temp != null) highlightSelected.material.shader = standard;
                    currentSelectedObject = hit.transform.gameObject;
                    highlightSelected = currentSelectedObject.GetComponent<Renderer>();
                    highlightSelected.material.shader = sil;
                    temp = currentSelectedObject;
                    deleteButton.SetActive(true);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if (currentSelectedObject != null)
            {
                Destroy(currentSelectedObject);
            }
            else
            {
                StartCoroutine(Appear());
            }
        }
    }

    public void OnAssetSelected(int index)
    {
        currentSelectedObject = Instantiate(assets[index], initialzeHere);
        highlightSelected = currentSelectedObject.GetComponent<Renderer>();
        highlightSelected.material.shader = sil;
        temp = currentSelectedObject;
        assetViewer.SetActive(false);
        deleteButton.SetActive(true);
    }

    public void OnDelete()
    {
        if (currentSelectedObject != null)
        {
            Destroy(currentSelectedObject);
        }
        else
        {
            StartCoroutine(Appear());
        }
    }

    IEnumerator Appear()
    {
        Color color = warning.color;
        color.a = 255;
        warning.color = color;
        yield return new WaitForSeconds(2f);
        color.a = 0;
        warning.color = color;
    }
}