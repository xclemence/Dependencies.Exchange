﻿using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Dependencies.Exchange.File
{
    public class FileImportService : IImportAssembly
    {
        public string Name => "File";
        public bool IsReady => true;

        public string Version => typeof(FileImportService).Assembly.GetName().Version?.ToString() ?? string.Empty;

        public Task<AssemblyExchangeContent?> ImportAsync(Func<UserControl, IExchangeViewModel<AssemblyExchangeContent>, Task<AssemblyExchangeContent>> _)
        {
            var openFileDialog = new OpenFileDialog()
            {
                DefaultExt = ".json",
                Filter = "JavaScript Object Notation (.json)|*.json"
            };

            var result = openFileDialog.ShowDialog();

            if (!(result ?? false))
                return Task.FromResult<AssemblyExchangeContent?>(default);

            var serializeObject = System.IO.File.ReadAllText(openFileDialog.FileName);
            var model = JsonConvert.DeserializeObject<ExportModel>(serializeObject);

            return Task.FromResult<AssemblyExchangeContent?>(new AssemblyExchangeContent { Assembly = model.Assembly, Dependencies = model.Dependencies });
        }
    }
}
