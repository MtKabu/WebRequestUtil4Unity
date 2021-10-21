using System;
using UnityEngine;

[Serializable]
public class PersonImage
{
    [SerializeField] private string iconUrl;
    public string IconUrl { get { return iconUrl; } }

    [SerializeField] private string fullUrl;
    public string FullUrl { get { return fullUrl; } }
}