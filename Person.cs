using System;
using UnityEngine;

[Serializable]
public class Person
{
    [SerializeField] private string id;
    public string Id { get { return id; } }

    [SerializeField] private string name;
    public string Name { get { return name; } }

    [SerializeField] private PersonImage images;
    public PersonImage Images { get { return images; } }
}