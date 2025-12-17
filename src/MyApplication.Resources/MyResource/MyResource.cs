// Copyright (c) 2025, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using System.Threading;
using System.Threading.Tasks;
using Moryx.AbstractionLayer.Resources;

namespace MyApplication.Resources.MyResource;

[ResourceRegistration] // Only necessary for dependency injection like logging or parallel operations
public class MyResource : Resource
{
    protected async override Task OnInitializeAsync(CancellationToken cancellationToken)
    {
        await base.OnInitializeAsync(cancellationToken);
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}
