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

    public static ENUM_CHARACTER GetCharacterJob<T>() where T : Character
    {
        Type type = typeof(T);

        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            CharacterAttribute characterAttr = attr as CharacterAttribute;

            if (characterAttr != null)
            {
                return characterAttr.GetJob();
            }
        }

        return ENUM_CHARACTER.None;
    }

    public static ENUM_CHARACTER GetCharacterJob(Type type)
    {
        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        foreach (Attribute attr in attributes)
        {
            CharacterAttribute characterAttr = attr as CharacterAttribute;

            if (characterAttr != null)
            {
                return characterAttr.GetJob();
            }
        }

        return ENUM_CHARACTER.None;
    }

}
