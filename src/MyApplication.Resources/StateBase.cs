// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.StateMachines;

namespace MyApplication.Resources
{
    internal abstract class SomeStateBase : StateBase<SomeCell>
    {
        public SomeStateBase(SomeCell context, StateMap stateMap) : base(context, stateMap)
        {
        }
    }
}
