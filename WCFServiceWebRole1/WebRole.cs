using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Microsoft.ServiceBus;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WCFServiceWebRole1
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            ServiceHost sh = new ServiceHost(typeof(TurmaService));

            sh.AddServiceEndpoint(
                    typeof(ITurmaService),
                    new NetTcpRelayBinding(),
                    ServiceBusEnvironment.CreateServiceUri("sb", "demotestesb2", "turma"))
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "JK4Ds/evY1oTHUAlQJW5Pm8gM6zIxW0XeppmeXFQFOs=")
                });

            sh.Open();
            return base.OnStart();
        }
    }
}
