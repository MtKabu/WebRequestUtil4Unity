using System;
using UnityEngine;

[Serializable]
public class APIValue
{
    [SerializeField] private bool result;
    public bool Result { get { return result; } }

    [SerializeField] private Person[] personMatrix;
    public Person[] PersonMatrix { get { return personMatrix; } }
}