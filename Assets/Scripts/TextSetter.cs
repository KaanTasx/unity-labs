using System;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private int CountOfShows
    {
        get => PlayerPrefs.GetInt("CountOfShows", 0);
        set => PlayerPrefs.SetInt("CountOfShows", value);
    }

    private void OnEnable()
    {
        CountOfShows++;
        _text.text = $"Shows: {CountOfShows}";
    }
}