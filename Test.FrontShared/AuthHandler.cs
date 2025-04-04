using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Test.FrontShared.Services;

namespace Test.FrontShared
{
    public class AuthHandler : DelegatingHandler
    {
        private readonly NavigationManager _navigationManager;

        public AuthHandler(NavigationManager navigationManager, IStorageWrapper storage)
        {
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/logout");
            }

            return response;
        }
    }
}
