// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateDiskGrantAccessDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pDiskName = new RuntimeDefinedParameter();
            pDiskName.Name = "DiskName";
            pDiskName.ParameterType = typeof(string);
            pDiskName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pDiskName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("DiskName", pDiskName);

            var pAccess = new RuntimeDefinedParameter();
            pAccess.Name = "Access";
            pAccess.ParameterType = typeof(AccessLevel);
            pAccess.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false
            });
            pAccess.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Access", pAccess);

            var pDurationInSecond = new RuntimeDefinedParameter();
            pDurationInSecond.Name = "DurationInSecond";
            pDurationInSecond.ParameterType = typeof(int);
            pDurationInSecond.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 4,
                Mandatory = false
            });
            pDurationInSecond.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("DurationInSecond", pDurationInSecond);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 5,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteDiskGrantAccessMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string diskName = (string)ParseParameter(invokeMethodInputParameters[1]);
            var grantAccessData = new GrantAccessData();
            var pAccess = (AccessLevel) ParseParameter(invokeMethodInputParameters[2]);
            grantAccessData.Access = pAccess;
            var pDurationInSeconds = (int) ParseParameter(invokeMethodInputParameters[3]);
            grantAccessData.DurationInSeconds = pDurationInSeconds;

            var result = DisksClient.GrantAccess(resourceGroupName, diskName, grantAccessData);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateDiskGrantAccessParameters()
        {
            string resourceGroupName = string.Empty;
            string diskName = string.Empty;
            GrantAccessData grantAccessData = new GrantAccessData();

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "DiskName", "GrantAccessData" },
                 new object[] { resourceGroupName, diskName, grantAccessData });
        }
    }

    [Cmdlet(VerbsSecurity.Grant, "AzureRmDiskAccess", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessUri))]
    public partial class GrantAzureRmDiskAccess : ComputeAutomationBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.DiskName, VerbsSecurity.Grant))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string diskName = this.DiskName;
                    var grantAccessData = new GrantAccessData();
                    grantAccessData.Access = this.Access;
                    grantAccessData.DurationInSeconds = this.DurationInSecond;

                    var result = DisksClient.GrantAccess(resourceGroupName, diskName, grantAccessData);
                    var psObject = new PSAccessUri();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<AccessUri, PSAccessUri>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        [ResourceManager.Common.ArgumentCompleters.ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Alias("Name")]
        [AllowNull]
        public string DiskName { get; set; }


        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = false)]
        [AllowNull]
        public AccessLevel Access { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 4,
            Mandatory = false)]
        [AllowNull]
        public int DurationInSecond { get; set; }
    }
}
