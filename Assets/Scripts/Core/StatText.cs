using System.Collections.Generic;
using UnityEngine;

namespace ProjectCustomer.Core
{
    [CreateAssetMenu(fileName = "NewStats", menuName = "Statistics Text/Stats Sequence", order = 0)]
    public class StatText : ScriptableObject
    {
        [System.Serializable]
        public class StatTextBox
        {
            [TextArea] public string textToDisplay;
        }

        public List<StatTextBox> statTextBoxes;
    }
}