using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// ReSharper disable once CheckNamespace
public static class Config
{
    private static Dictionary<string, string> _configDict;

    private static int _curGameState = (int) GameState.NotRunning;
// ReSharper disable once UnusedMember.Local

    public static int CurGameState
    {
        get { return _curGameState; }
        set { _curGameState = value; }
    }

    public static IEnumerator LoadConfig()
    {
        _configDict = new Dictionary<string, string>();
        string configFile = "Config/config.xml";
        var parser = new XMLParser();

        if (!Application.isWebPlayer)
        {
            configFile = "file://" + Application.dataPath + "/../" + configFile;
        }
        else
        {
            configFile = Application.dataPath + "/" + configFile;
        }

        var www = new WWW(configFile);
        yield return www;

        XMLNode xml = parser.Parse(www.text);

        for (int i = 0; i < xml.GetNodeList("config>0>value").Count; i++)
        {
            var stringBuilder1 = new StringBuilder();
            stringBuilder1.Append("config>0>value>");
            stringBuilder1.Append(i);
            stringBuilder1.Append(">@name");

            var stringBuilder2 = new StringBuilder();
            stringBuilder2.Append("config>0>value>");
            stringBuilder2.Append(i);
            stringBuilder2.Append(">_text");

            _configDict.Add(xml.GetValue(stringBuilder1.ToString()), xml.GetValue(stringBuilder2.ToString()));
        }
    }

    public static String GetConfig(String configParam)
    {
        if (_configDict.ContainsKey(configParam))
        {
            return _configDict[configParam];
        }
        return null;
    }
}

public enum GameState
{
    NotRunning,
    Running
}