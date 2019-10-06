/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using Xunit;
using magic.node;
using magic.node.extensions;

namespace magic.lambda.config.tests
{
    public class ConfigTests
    {
        [Fact]
        public void CheckConfigurationSetting()
        {
            var signaler = Common.Initialize();
            var args = new Node("config.get", "foo-value");
            signaler.Signal("config.get", args);
            Assert.Equal("bar-xx", args.Get<string>());
        }
    }
}
