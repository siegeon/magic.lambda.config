/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda
{
    [Slot(Name = "config")]
    public class Config : ISlot
    {
        readonly IConfiguration _configuration;

        public Config(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Signal(ISignaler signaler, Node input)
        {
            if (input.Children.Any())
                throw new ApplicationException("[config] cannot handle children nodes");

            input.Value = _configuration[input.GetEx<string>()];
        }
    }
}
