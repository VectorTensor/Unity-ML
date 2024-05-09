using UnityEngine;

namespace Utils.Services
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