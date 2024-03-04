using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = Camera.main.pixelWidth / 8 - 20;
        int height = Camera.main.pixelHeight / 16 - 20;
        int buffer = 10;
        List<string> items = Managers.WhiteInventory.GetItemList();
        if (items.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No items");
        }
        foreach (string item in items)
        {
            int count = Managers.WhiteInventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent($"({count})", image));
            posX += width + buffer;
        }

        posX = Camera.main.pixelWidth - (width + buffer) - 10;
        posY = 10;
        items = Managers.BlueInventory.GetItemList();
        if (items.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No items");
        }
        foreach (string item in items)
        {
            int count = Managers.BlueInventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent($"({count})", image));
            posX += width + buffer;
        }
    }
}