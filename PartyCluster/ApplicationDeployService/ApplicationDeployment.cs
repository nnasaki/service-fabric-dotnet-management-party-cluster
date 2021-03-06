﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace ApplicationDeployService
{
    using System;
    using System.Runtime.Serialization;
    using Domain;

    [DataContract]
    public struct ApplicationDeployment
    {
        public ApplicationDeployment(
            string cluster,
            ApplicationDeployStatus status,
            string imageStorePath,
            string applicationTypeName,
            string applicationTypeVersion,
            string applicationInstanceName,
            string packagePath,
            DateTimeOffset timestamp)
        {
            this.Cluster = cluster;
            this.Status = status;
            this.ImageStorePath = imageStorePath;
            this.ApplicationTypeName = applicationTypeName;
            this.ApplicationTypeVersion = applicationTypeVersion;
            this.ApplicationInstanceName = applicationInstanceName;
            this.PackagePath = packagePath;
            this.DeploymentTimestamp = timestamp;
        }

        public ApplicationDeployment(ApplicationDeployStatus status, ApplicationDeployment copyFrom)
            : this(
                copyFrom.Cluster,
                status,
                copyFrom.ImageStorePath,
                copyFrom.ApplicationTypeName,
                copyFrom.ApplicationTypeVersion,
                copyFrom.ApplicationInstanceName,
                copyFrom.PackagePath,
                copyFrom.DeploymentTimestamp)
        {
        }

        [DataMember]
        public string Cluster { get; private set; }

        [DataMember]
        public ApplicationDeployStatus Status { get; private set; }

        [DataMember]
        public string ImageStorePath { get; private set; }

        [DataMember]
        public string ApplicationTypeName { get; private set; }

        [DataMember]
        public string ApplicationTypeVersion { get; private set; }

        [DataMember]
        public string ApplicationInstanceName { get; private set; }

        [DataMember]
        public string PackagePath { get; private set; }

        [DataMember]
        public DateTimeOffset DeploymentTimestamp { get; private set; }
    }
}