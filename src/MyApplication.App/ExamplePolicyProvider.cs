using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MyApplication.App;

public class ExamplePolicyProvider : DefaultAuthorizationPolicyProvider
{
    public ExamplePolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy == null)
        {
            policy = new AuthorizationPolicyBuilder()
                .RequireClaim("Permission", policyName)
                .Build();
        }
        return policy;
    }
}