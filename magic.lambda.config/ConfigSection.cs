/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.config
{
    /// <summary>
    /// [config.section] slot for retrieving a configuration section.
    /// </summary>
    [Slot(Name = "config.section")]
    public class ConfigSection : ISlot
    {
        readonly IConfiguration _configuration;

        /// <summary>
        /// Creates a new instance of your class.
        /// </summary>
        /// <param name="configuration">Configuration settings for your application.</param>
        public ConfigSection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler used to signal your slot.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var section = _configuration.GetSection(input.GetEx<string>() ??
                throw new HyperlambdaException("No value provided to [config.section]"));
            var tmp = section
                .GetChildren()
                .ToDictionary(x => x.Key, x => x.Value);
            input.AddRange(tmp.Select(x => new Node(x.Key, x.Value)));
        }
    }
}
