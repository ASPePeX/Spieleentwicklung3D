using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// ReSharper disable once CheckNamespace
public static class Config
{
    private static readonly Dictionary<string, string> ConfigDict;

// ReSharper disable once UnusedMember.Local
    static Config()
    {
        ConfigDict = new Dictionary<string, string>();
        const string configFile = "Assets/config.xml";
        var parser = new XMLParser();
        XMLNode xml = parser.Parse(File.ReadAllText(configFile));

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

            ConfigDict.Add(xml.GetValue(stringBuilder1.ToString()), xml.GetValue(stringBuilder2.ToString()));
        }
    }

    public static String GetConfig(String configParam)
    {
        if (ConfigDict.ContainsKey(configParam))
        {
            return ConfigDict[configParam];
        }
        return null;
    }
}