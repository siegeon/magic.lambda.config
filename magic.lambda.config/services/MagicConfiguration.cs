/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using Newtonsoft.Json.Linq;
using magic.node.contracts;

namespace magic.lambda.config.services
{
    /// <summary>
    /// Custom configuration class for Magic using the IFileService to save and load the "appsettings.json"
    /// configuration file.
    /// </summary>
    public class MagicConfiguration : IMagicConfiguration
    {
        readonly IFileService _fileService;
        readonly IRootResolver _rootService;
        readonly JObject _config;

        /// <summary>
        /// Creates an instance of your type.
        /// </summary>
        /// <param name="fileService">Needed to resolve configuration file.</param>
        /// <param name="rootService">Needed to namespace configuration file as we resolve it.</param>
        public MagicConfiguration(IFileService fileService, IRootResolver rootService)
        {
            _fileService = fileService;
            _rootService = rootService;
            var json = _fileService.Load(_rootService.RootFolder + "config/appsettings.json");
            _config = JObject.Parse(json);
        }

        /// <inheritdoc />
        public string this[string key]
        {
            get => Find(key)?.Value<string>();
            set
            {
                var jObject = Find(key);
                jObject.Value = value;
                _fileService.Save(_rootService.RootFolder + "config/appsettings.json", _config.ToString());
            }
        }

        #region [ -- Private helpers -- ]

        /*
         * Returns a JProperty given the specified "path".
         */
        JValue Find(string key)
        {
            var splits = key.Split(':');
            var current = _config;
            foreach (var idxEntity in splits.Take(splits.Length - 1))
            {
                current = current[idxEntity] as JObject;
                if (current == null)
                    return null;
            }
            return current[splits.Last()] as JValue;
        }

        #endregion
    }
}
