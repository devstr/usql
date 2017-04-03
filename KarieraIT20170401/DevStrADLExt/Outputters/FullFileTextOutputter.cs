using Microsoft.Analytics.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStrADLExt.Outputters
{
    public class FullFileTextOutputter : IOutputter
    {
        private string _outputLocation;
        public FullFileTextOutputter (string outputLocation)
        {
            _outputLocation = outputLocation;
        }
        public override void Output(IRow input, IUnstructuredWriter output)
        {
            var fileName = input.Get<string>(0);
            var content = input.Get<string>(1);
            File.WriteAllText(Path.Combine(_outputLocation, fileName), content);
            
        }
    }
}
