using Moryx.ControlSystem.Cells;

namespace MyApplication.ControlSystem.CellSelector
{
    public class MyCellSelectorConfig : CellSelectorConfig
    {
        public override string PluginName
        {
            get => nameof(MyCellSelector);
            set { }
        }
    }
}