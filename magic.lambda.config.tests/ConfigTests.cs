/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
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
            var args = new Node("", "foo-value");
            signaler.Signal("config.get", args);
            Assert.Equal("bar-xx", args.Get<string>());
        }

        [Fact]
        public void CheckConfigurationSettingThrows()
        {
            var signaler = Common.Initialize();
            var args = new Node("");
            Assert.Throws<HyperlambdaException>(() => signaler.Signal("config.get", args));
        }
    }
}
