using System.IO;
using AmcSubHelper.Models;
using Newtonsoft.Json;

namespace AmcSubHelper.Logic
{
    internal static class ProjectExportImport
    {
        public static SubProjectModel OpenProject(string filepath)
        {
            var json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<SubProjectModel>(json);
        }

        public static void ExportProject(string filepath, SubProjectModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            File.WriteAllText(filepath, json);
        }
    }
}
