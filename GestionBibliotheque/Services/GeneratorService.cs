using System;
using GestionBibliotheque.Services.Interfaces;

namespace GestionBibliotheque.Services
{
    public class GeneratorService : IGeneratorService
    {
        public string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

