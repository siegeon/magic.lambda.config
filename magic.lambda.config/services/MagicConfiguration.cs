/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using Microsoft.Extensions.Configuration;
using magic.node.contracts;

namespace magic.lambda.config.services
{
    /// <summary>
    /// Custom configuration class for Magic using the IFileService to save and load the "appsettings.json"
    /// configuration file.
    /// </summary>
    public class MagicConfiguration : IMagicConfiguration
    {
        readonly IConfiguration _configuration;

        /// <summary>
        /// Creates an instance of your type.
        /// </summary>
        /// <param name="configuration">Actual configuration object.</param>
        public MagicConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public string this[string key]
        {
            get => _configuration[key];
        }
    }
}
