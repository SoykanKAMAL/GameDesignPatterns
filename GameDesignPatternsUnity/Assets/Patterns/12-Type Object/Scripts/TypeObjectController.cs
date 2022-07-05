using System;
using UnityEngine;

namespace TypeObject
{
    public class TypeObjectController : MonoBehaviour
    {
        #region Unity methods

        private void Start()
        {
            var shyProgrammer = new Programmer(Faker.Name.FullName(), isShy: true);
            
            var talkativeProgrammer = new Programmer(Faker.Name.FullName(), isShy: false);
            
            shyProgrammer.Talk();
            talkativeProgrammer.Talk();
        }

        #endregion
    }
}