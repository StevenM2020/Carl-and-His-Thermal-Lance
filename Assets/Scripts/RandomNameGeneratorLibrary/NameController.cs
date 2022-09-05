using RandomNameGeneratorLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class NameController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var personGenerator = new PersonNameGenerator();
            var name = personGenerator.GenerateRandomFirstAndLastName();
            Debug.Log(name.ToString());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

