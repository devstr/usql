using Microsoft.Analytics.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace DevStrADLExt.Extractors
{
    [SqlUserDefinedExtractor(AtomicFileProcessing = true)]
    public class FullFileTextExctractor : IExtractor
    {
        public override IEnumerable<IRow> Extract(IUnstructuredReader input, IUpdatableRow output)
        {
            using (TextReader reader = new StreamReader(input.BaseStream))
            {
                var content = reader.ReadToEnd();
                output.Set<string>(0, content);
                yield return output.AsReadOnly();
            }
        }
    }
}
