/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.contracts;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.config
{
    /// <summary>
    /// [config.get] slot for retrieving a configuration key.
    /// </summary>
    [Slot(Name = "config.get")]
    public class ConfigGet : ISlot, ISlotAsync
    {
        readonly IMagicConfiguration _configuration;

        /// <summary>
        /// Creates a new instance of your class.
        /// </summary>
        /// <param name="configuration">Configuration settings for your application.</param>
        public ConfigGet(IMagicConfiguration configuration)
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
            // Evaluating children as lambda.
            signaler.Signal("eval", input);

            // Returning value to caller, making sure we resort to default value if no config value is found.
            input.Value = _configuration[
                input.GetEx<string>() ??
                throw new HyperlambdaException("No value provided to [config.get]")] ??
                input.Children.FirstOrDefault()?.GetEx<string>();

            // House cleaning.
            input.Clear();
        }

        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler used to signal your slot.</param>
        /// <param name="input">Arguments to your slot.</param>
        /// <returns>Awaitable task</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            // Evaluating children as lambda.
            await signaler.SignalAsync("eval", input);

            // Returning value to caller, making sure we resort to default value if no config value is found.
            input.Value = _configuration[
                input.GetEx<string>() ??
                throw new HyperlambdaException("No value provided to [config.get]")] ??
                input.Children.FirstOrDefault()?.GetEx<string>();

            // House cleaning.
            input.Clear();
        }
    }
}
