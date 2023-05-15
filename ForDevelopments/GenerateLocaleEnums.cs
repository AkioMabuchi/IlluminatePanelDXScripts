using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;

namespace ForDevelopments
{
    public class GenerateLocaleEnums : MonoBehaviour
    {
        [SerializeField] private StringTableCollection stringTableCollection;
        
        [ContextMenu("Generate Locale Key Enums")]
        private void GenerateLocaleKeyEnums()
        {
            var hashSet = new HashSet<string>();
            
            foreach (var stringTable in stringTableCollection.StringTables)
            {
                foreach (var stringTableEntry in stringTable.Values)
                {
                    hashSet.Add(stringTableEntry.Key);
                }
            }

            var code = "namespace Enums\n" +
                       "{\n" +
                       "    public enum LocaleKey\n" +
                       "    {\n" +
                       "        None,\n";
            foreach (var str in hashSet)
            {
                code += "        " + str + ",\n";
            }

            code += "    }\n" +
                    "}";

            File.WriteAllText("Assets/Scripts/Enums/LocaleKey.cs", code);
            AssetDatabase.Refresh();
        }
    }
}
