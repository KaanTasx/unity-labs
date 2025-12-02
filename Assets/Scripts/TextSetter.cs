using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
    [SerializeField] private Text _text;
    private readonly string _apiUrl = "http://localhost:5237/weatherforecast";
    
    public void ShowWeather()
    {
        StartCoroutine(GetWeatherForecast());
    }

    private IEnumerator GetWeatherForecast()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(_apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                _text.text = "Error: " + webRequest.error;
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                WeatherForecast[] forecasts = JsonHelper.FromJson<WeatherForecast>(jsonResponse);

                _text.text = "Weather Forecast:\n\n";
                foreach (var forecast in forecasts)
                {
                    _text.text += $"{forecast.date}: {forecast.temperatureC}°C ({forecast.temperatureF}°F) - {forecast.summary}\n";
                }
            }
        }
    }
    
    [System.Serializable]
    public class WeatherForecast
    {
        public string date;
        public int temperatureC;
        public string summary;
        public int temperatureF;
    }

    // Допоміжний клас для парсингу JSON у масив
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            // Окремий випадок для JSON масиву
            json = "{\"array\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.array;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
}