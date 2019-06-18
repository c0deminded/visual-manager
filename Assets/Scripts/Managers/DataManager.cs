using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Color buttonColor;
    public Color activeButtonColor;
    public Color[] dataColors;
    public Color[] dataColors2;
    public string[] dataValuesDescription;

    public static string[] randomNames = 
        { "Кирилл Петрович",
        "Иван Иванович",
        "Петр Кузьмич",
        "Валерий Леонович",
        "Александр Витальевич",
        "Владимир Борисович"};

    public static string[] driversJobs =
        {"Перевозит ценные документы",
        "Поставляет продукцию со склада",
        "Поставляет продукцию с завода",
            "Инкассация"};

    public string GetRandomName()
    {
        return randomNames[Random.Range(0, randomNames.Length-1)];
    }
    public string GetDriverDesc()
    {
        return driversJobs[Random.Range(0, driversJobs.Length - 1)];
    }
}
