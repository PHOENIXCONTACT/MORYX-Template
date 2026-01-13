// Copyright (c) 2026, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.StateMachines;

namespace MyApplication.Resources;

internal class SpecificState(SomeCell context, StateBase.StateMap stateMap) : SomeStateBase(context, stateMap)
{
}
