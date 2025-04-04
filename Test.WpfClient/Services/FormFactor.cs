using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Maui.Shared.Services;

namespace Test.WpfClient.Services
{
    public class FormFactor : IFormFactor
    {
        public string GetFormFactor()
        {
            return "Desktop";
        }

        public string GetPlatform()
        {
            return $"Windows - {Environment.OSVersion}";
        }
    }
}
