using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadSave : MonoBehaviour
{
    [SerializeField] private string saveFileName = "saveData.json";

    private void Start()
    {
        LoadGame();
    }

    private void LoadGame()
    {
        if (File.Exists(saveFileName))
        {
            // �������� ������ ����
            // ��������, �������� ������, �������� ������, ������� � �.�.
            // � ������ ������� ���������� ������ ��������� ����
            string saveData = File.ReadAllText(saveFileName);
            Debug.Log("Loaded save data: " + saveData);
        }
        else
        {
            Debug.Log("No save data found");
        }
    }
}

