using UnityEngine;

namespace Scripts.Utils
{
    public class GetCSVService : MonoBehaviour, IGetCSVService
    {
        [SerializeField] TextAsset textAsset;

        public string GetData()
        {

            return textAsset.text;

        }

    }
}