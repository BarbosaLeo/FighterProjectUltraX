﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomGradient
{
    public enum BlendMode { Linear, Discrete };
    public BlendMode blendMode;
    public bool randomizeColor;

    [SerializeField]
    List<ColorKey> keys = new List<ColorKey>();

    public CustomGradient()
    {
        AddKey(UnityEngine.Color.white, 0);
        AddKey(UnityEngine.Color.black, 1);
    }

    public UnityEngine.Color Evaluate(float time)
    {
        ColorKey keyLeft = keys[0];
        ColorKey keyRight = keys[keys.Count - 1];
        
        for(int i=0; i<keys.Count; i++)
        {
            if(keys[i].Time <= time)
            {
                keyLeft = keys[i];
            }
            if (keys[i].Time >= time)
            {
                keyRight = keys[i];
                break;
            }
        }

        if (blendMode == BlendMode.Linear)
        {
            float blendTime = Mathf.InverseLerp(keyLeft.Time, keyRight.Time, time);
            return UnityEngine.Color.Lerp(keyLeft.Color, keyRight.Color, blendTime);
        }
        return keyRight.Color;
    }

    public int AddKey(UnityEngine.Color color, float time)
    {
        ColorKey newKey = new ColorKey(color, time);
        for (int i = 0; i <keys.Count; i++)
        {
            if(newKey.Time < keys[i].Time)
            {
                keys.Insert(i, newKey);
                return i;
            }
        }

        keys.Add(newKey);
        return keys.Count - 1;
    }

    public void RemoveKey(int index)
    {
        if (keys.Count >= 2)
        {
            keys.RemoveAt(index);
        } 
    }

    public void UpdateKeyColor(int index, UnityEngine.Color col)
    {
        keys[index] = new ColorKey(col, keys[index].Time);
    }

    public int UpdateKeyTime(int index, float time)
    {
        UnityEngine.Color col = keys[index].Color;
        RemoveKey(index);
        return AddKey(col, time);
    }

    public int numKeys
    {
        get
        {
            return keys.Count;
        }
    }

    public ColorKey GetKey(int i)
    {
        return keys[i];
    }

    public Texture2D GetTexture(int width)
    {
        Texture2D texture = new Texture2D(width, 1);
        UnityEngine.Color[] colors = new UnityEngine.Color[width];
        for(int i = 0; i < width; i++)
        {
            colors[i] = Evaluate((float)i/(width-1));
        }

        texture.SetPixels(colors);
        texture.Apply();
        return texture;
    }

    [System.Serializable]
    public struct ColorKey
    {
        [SerializeField]
        UnityEngine.Color color;
        [SerializeField]
        float time;

        public ColorKey(UnityEngine.Color color, float time)
        {
            this.color = color;
            this.time = time;
        }

        public UnityEngine.Color Color
        {
            get
            {
                return color;
            }
        }

        public float Time
        {
            get
            {
                return time;
            }
        }
    }
}
