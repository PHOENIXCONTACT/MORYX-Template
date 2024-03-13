using Moryx.AbstractionLayer;
using Moryx.AbstractionLayer.Recipes;
using Moryx.ControlSystem.VisualInstructions;
using Moryx.Serialization;

namespace MyApplication.Activities.SomeStep
{
    public class SomeParameters : VisualInstructionParameters
    {
        /// <summary>
        /// Example of a parameter value as user input
        /// </summary>
        [EntrySerialize]
        public int UserInput { get; set; }

        /// <summary>
        /// Example of a parameter value as product input
        /// </summary>
        [EntrySerialize(EntrySerializeMode.Never)] // Redundant with the explicit declaration, just as a hint
        public int TwinAttribute { get; set; }

        protected override void Populate(IProcess process, Parameters instance)
        {
            base.Populate(process, instance);

            var parameters = (SomeParameters)instance;
            parameters.UserInput = UserInput; // Simply copy to activity instance

            var recipe = (IProductRecipe)process.Recipe;
            parameters.TwinAttribute = recipe.Product.Name.Length;
        }
    }
}