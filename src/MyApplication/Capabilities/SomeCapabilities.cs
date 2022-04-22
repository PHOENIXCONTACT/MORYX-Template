using Moryx.AbstractionLayer.Capabilities;

namespace MyApplication.Capabilities
{
    public class SomeCapabilities : CapabilitiesBase
    {
        public int Value { get; set; }

        protected override bool ProvidedBy(ICapabilities provided)
        {
            var providedSome = provided as SomeCapabilities;
            if (providedSome == null)
                return false;

            if (providedSome.Value < Value) // Provided must be greater or equal
                return false;

            return true;
        }
    }
}