using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    internal enum Type { Pink, Blue };

   internal string Name { get; set; }
    internal Type CharType { get; set; }

    internal Player(string name, Type type)
    {
        Name = name;
        CharType = type;
    }

    
}
