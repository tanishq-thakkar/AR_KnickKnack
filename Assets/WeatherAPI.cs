using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;

public class WeatherAPI : MonoBehaviour
{
    TMP_Text text;

    string apiKey = "a1726e02a23a5ee1836bdb7b652d0184";
    string city = "Taipei";

    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(GetWeather());
    }

    IEnumerator GetWeather()
    {
        string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + apiKey;

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            text.text = "Weather Error";
        }
        else
        {
            string json = request.downloadHandler.text;

            Debug.Log(json); // helps debug

            WeatherData data = JsonUtility.FromJson<WeatherData>(json);

            float temp = data.main.temp;
            string weather = data.weather[0].main;

            text.text = city + "\n" + temp + "°C\n" + weather;
        }
    }
}

[System.Serializable]
public class WeatherData
{
    public WeatherMain main;
    public Weather[] weather;
}

[System.Serializable]
public class WeatherMain
{
    public float temp;
}

[System.Serializable]
public class Weather
{
    public string main;
}