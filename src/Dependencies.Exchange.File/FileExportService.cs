using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Dependencies.Exchange.File
{
    internal class ExportModel
    {
        public AssemblyExchange Assembly { get; set; } = null!;
        public IList<AssemblyExchange> Dependencies { get; set; } = null!;

    }

    public class FileExportService : IExportAssembly
    {
        public string Name => "File";
        public bool IsReady => true;

        public Task<bool> ExportAsync(AssemblyExchange assembly,
                                      IList<AssemblyExchange> dependencies,
                                      Func<UserControl, IExchangeViewModel<bool>, Task<bool>> _)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var saveFileDialog = new SaveFileDialog()
            {
                FileName = assembly.ShortName,
                DefaultExt = ".json",
                Filter = "JavaScript Object Notation (.json)|*.json"
            };

            var result = saveFileDialog.ShowDialog();

            if (!(result ?? false))
                return Task.FromResult(false);

            var serializeObject = JsonConvert.SerializeObject(new ExportModel { Assembly = assembly, Dependencies = dependencies }, Formatting.Indented);

            System.IO.File.WriteAllText(saveFileDialog.FileName, serializeObject);

            return Task.FromResult(true);
        }
    }
}
