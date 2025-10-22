// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.AbstractionLayer.Resources;

namespace MyApplication.Resources.MyResource;

[ResourceRegistration] // Only necessary for dependency injection like logging or parallel operations
public class MyResource : Resource
{
    protected override void OnInitialize()
    {
        base.OnInitialize();
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}
