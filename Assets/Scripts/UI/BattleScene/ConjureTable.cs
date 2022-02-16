using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConjureTable : MonoBehaviour
{

    private PlayerController playerController;
    public GameObject PrimaryHolder;
    public GameObject SecondaryHolder;
    public GameObject FirePrefab;
    public GameObject WaterPrefab;
    public GameObject EarthPrefab;
    public GameObject AirPrefab;

    private bool shouldUpdateUI = false;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        HandleKeyInput();
        if (shouldUpdateUI)
        {
            UpdateUI();
        }
    }

    private void HandleKeyInput()
    {
        if (playerController.IsConjuredTableFull() && !Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerController.AppendElement(ElementType.Fire);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerController.AppendElement(ElementType.Water);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerController.AppendElement(ElementType.Air);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            playerController.AppendElement(ElementType.Earth);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.ClearConjuredElements();
        }
        shouldUpdateUI = true;
    }
    

    private void UpdateUI()
    {
        ClearPreviousUI();
        bool isFirstElement = true;
        GameObject newElement;

        foreach (ElementType element in playerController.GetConjuredElements())
        {
            switch (element)
            {
                case ElementType.Fire:
                    newElement = FirePrefab;
                    break;
                case ElementType.Water:
                    newElement = WaterPrefab;
                    break;
                case ElementType.Earth:
                    newElement = EarthPrefab;
                    break;
                case ElementType.Air:
                    newElement = AirPrefab;
                    break;
                default:
                    throw new System.Exception("Unknown ElementType");
            }

            if (true == isFirstElement)
            {
                Instantiate(newElement, PrimaryHolder.transform);
                isFirstElement = false;
            }
            else
            {
                Instantiate(newElement, SecondaryHolder.transform);
            }
        }
        shouldUpdateUI = false;
    }

    private void ClearPreviousUI()
    {
        foreach (Transform child in PrimaryHolder.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in SecondaryHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
