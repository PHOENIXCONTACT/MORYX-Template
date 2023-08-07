using System;
using System.Collections.Generic;
using System.Linq;
using Moryx.AbstractionLayer;
using Moryx.Container;
using Moryx.ControlSystem.Cells;
using Moryx.ControlSystem.Processes;
using Moryx.Modules;

namespace MyApplication.ControlSystem.CellSelector
{
    [ExpectedConfig(typeof(MyCellSelectorConfig))]
    [Plugin(LifeCycle.Transient, typeof(ICellSelector), Name = nameof(MyCellSelector))]
    public class MyCellSelector : CellSelectorBase<MyCellSelectorConfig>
    {
        /// <summary>
        /// Access to currently running processes and activities
        /// </summary>
        public IActivityPool ActivityPool { get; set; }

        public override IReadOnlyList<ICell> SelectCells(IActivity activity, IReadOnlyList<ICell> availableCells)
        {
            // Random based load balancer
            var random = new Random();
            var cells = availableCells.OrderBy(cell => random.Next());
            return cells.ToList();
        }
    }
}