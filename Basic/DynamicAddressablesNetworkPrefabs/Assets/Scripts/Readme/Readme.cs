using System;
using UnityEngine;

/// <remarks>
/// Custom readme class based on the readme created for URP. For more context, see:
/// https://github.com/Unity-Technologies/Graphics/tree/master/com.unity.template-universal
/// </remarks>

namespace Game.Readme
{
    [CreateAssetMenu]
    public class Readme : ScriptableObject
    {
        public Texture2D icon;
        public string title;
        public Section[] sections;
        public bool loadedLayout;

        [Serializable]
        public class Section
        {
            public string heading;
            public string text;
            public string linkText;
            public string url;
        }
    }
}


