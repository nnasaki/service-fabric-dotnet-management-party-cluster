﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace WebService
{
    using System;
    using System.Diagnostics;
    using System.Fabric;
    using System.Threading;
    using Microsoft.Diagnostics.EventListeners;
    using FabricEventListeners = Microsoft.Diagnostics.EventListeners.Fabric;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using (FabricRuntime fabricRuntime = FabricRuntime.Create())
                {
                    const string ElasticSearchEventListenerId = "ElasticSearchEventListener";
                    FabricEventListeners.FabricConfigurationProvider configProvider =
                        new FabricEventListeners.FabricConfigurationProvider(ElasticSearchEventListenerId);
                    ElasticSearchListener esListener = null;
                    if (configProvider.HasConfiguration)
                    {
                        esListener = new ElasticSearchListener(configProvider, new FabricEventListeners.FabricHealthReporter(ElasticSearchEventListenerId));
                    }

                    // This is the name of the ServiceType that is registered with FabricRuntime. 
                    // This name must match the name defined in the ServiceManifest. If you change
                    // this name, please change the name of the ServiceType in the ServiceManifest.
                    fabricRuntime.RegisterServiceType("WebServiceType", typeof(WebService));

                    ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(WebService).Name);

                    Thread.Sleep(Timeout.Infinite);
                    GC.KeepAlive(esListener);
                }
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e);
                throw;
            }
        }
    }
}