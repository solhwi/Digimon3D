using SDDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttributeUtil
{
    public static string GetResourcePath<T>() where T : UnityEngine.Object
    {
        Type type = typeof(T);

        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            ResourceAttribute resourceAttr = attr as ResourceAttribute;

            if (resourceAttr != null)
            {
                return resourceAttr.GetPath();
            }
        }

        return string.Empty;
    }

    public static string GetResourcePath(Type type)
    {
        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            ResourceAttribute resourceAttr = attr as ResourceAttribute;

            if (resourceAttr != null)
            {
                return resourceAttr.GetPath();
            }
        }

        return string.Empty;
    }

    public static ENUM_DIGIMON_TYPE GetCharacterJob<T>() where T : Digimon
    {
        Type type = typeof(T);

        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            DigimonAttribute characterAttr = attr as DigimonAttribute;

            if (characterAttr != null)
            {
                return characterAttr.GetJob();
            }
        }

        return ENUM_DIGIMON_TYPE.None;
    }

    public static ENUM_DIGIMON_TYPE GetDigimonType(Type type)
    {
        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            DigimonAttribute characterAttr = attr as DigimonAttribute;

            if (characterAttr != null)
            {
                return characterAttr.GetJob();
            }
        }

        return ENUM_DIGIMON_TYPE.None;
    }

}
