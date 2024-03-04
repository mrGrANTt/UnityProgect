using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class AutoSave : MonoBehaviour
{
    [SerializeField] private string saveFileName = "saveData.json";

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void SaveGame()
    {
        // Сохранение данных игры
        // Например, сохранение текущего уровня, здоровья игрока, позиции и т.д.
        // В данном примере используем просто текстовый файл
        string saveData = "Level: 3\nHealth: 100\nPosition: (10, 5, 3)";
        File.WriteAllText(saveFileName, saveData);
    }
}
