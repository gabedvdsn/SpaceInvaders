using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;
using UnityEngine;

public static class Formations
{

    public static FormationData GetCircleFormation(FormationParameters parameters) => EquidistantRadially(parameters);
    
    // public static FormationData GetSquareAreaFormation(FormationParameters parameters) => ...;
    
    // public static FormationData GetCircleAreaFormation(FormationParameters parameters) => ...;
    
    private static FormationData EquidistantRadially(FormationParameters parameters)
    {
        Vector2[] vectors = new Vector2[parameters.size];
        int halfSize = Mathf.FloorToInt(parameters.size / 2f);
        float radiansCoef = parameters.size > 0 ? (Mathf.PI * 2f) / (parameters.size - 1) : 0f;
        
        for (int i = -halfSize; i < halfSize; i++)
        {
            vectors[i + halfSize] = new Vector2(Mathf.Cos(i * radiansCoef), Mathf.Sin(i * radiansCoef));
        }

        return new FormationData(parameters.size, vectors, FullMagnitudeFromVectorsRadial(parameters.size, parameters.magnitude));
    }

    /*private static FormationData EquidistantArea(FormationParameters parameters)
    {
        Vector2[] vectors = new Vector2[parameters.size];
        
        
    }*/
    
    private static float[] UnitMagnitude(int size) => Enumerable.Range(1, size).Select(i => (float)i).ToArray();
    private static float[] FullMagnitudeFromVectorsRadial(int size, int radius) => Enumerable.Range(1, size).Select(_ => (float)radius).ToArray();

}

public class FormationData
{
    public int size;
    public Vector2[] vectors;
    public float[] magnitudes;

    public FormationData(int size, Vector2[] vectors, float[] magnitudes)
    {
        this.size = size;
        this.vectors = vectors;
        this.magnitudes = magnitudes;
    }
}


public class FormationParameters
{
    public readonly int size;
    public readonly int magnitude;
    public readonly Dictionary<string, float> tags;

    public FormationParameters(int size, int magnitude, Dictionary<string, float> tags = null)
    {
        this.size = size;
        this.magnitude = magnitude;
        this.tags = tags;
    }
}