﻿/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using Newtonsoft.Json.Linq;
using magic.node;
using magic.node.contracts;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.config
{
    /// <summary>
    /// [config.save] slot saving its value to your "appsettings.json" file.
    /// </summary>
    [Slot(Name = "config.save")]
    public class SaveAppSettings : ISlot
    {
        readonly IFileService _fileService;
        readonly IRootResolver _rootResolver;

        /// <summary>
        /// Creates an instance of your type.
        /// </summary>
        /// <param name="fileService">Needed to be able to save configuration settings.</param>
        /// <param name="rootResolver">Needed to be able to resolve root filename for configuration settings file.</param>
        public SaveAppSettings(
            IFileService fileService,
            IRootResolver rootResolver)
        {
            _fileService = fileService;
            _rootResolver = rootResolver;
        }

        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Retrieving appsettings JSON from input node as a string.
            var json = input.GetEx<string>();

            /*
             * This little bugger will validate that the JSON is actually valid JSON,
             * which prevents saving of non-valid JSON to configuration file.
             */
            var jObject = JObject.Parse(json);

            // Saving JSON as text to "appsettings.json" file.
            _fileService.Save(_rootResolver.RootFolder + "config/appsettings.json", jObject.ToString());
        }
    }
}
